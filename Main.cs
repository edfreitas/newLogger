/*
    Copyright (c) 2015 <a href="http://edfreitas.me">Ed Freitas</a>
 
    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Timers;
using System.Diagnostics.Eventing.Reader;
using System.Threading;
using System.Configuration;

using MetroFramework;
using System.IO;

namespace newLogger
{
    public partial class Main : MetroFramework.Forms.MetroForm
    {
        private int lastLogCount = 0;
        private bool changed = false;

        private string saveFileName = String.Empty;
        private List<string> settings = new List<string>();

        public static DataTable dtLogger = new DataTable();      
        public static DataGridView dgv = new DataGridView();

        public static DataTable dtSearch = new DataTable();
        public static DataGridView dgvSearch = new DataGridView();

        public Main()
        {
            InitializeComponent();
        }

        private void OrganiseGrid()
        {
            try
            {
                dataGridSearch.Visible = false;

                dgvSearch = dataGridSearch;
                dgv = dataGridView;

                dtLogger.Columns.Add("Message", typeof(string));
                dtLogger.Columns.Add("Logged", typeof(string));
                dtLogger.Columns.Add("Level", typeof(string));
                dtLogger.Columns.Add("User", typeof(string));

                dtSearch.Columns.Add("Message", typeof(string));
                dtSearch.Columns.Add("Logged", typeof(string));
                dtSearch.Columns.Add("Level", typeof(string));
                dtSearch.Columns.Add("User", typeof(string));

                dtLogger.Rows.Clear();
                dtSearch.Rows.Clear();

                dgv.Refresh();
            }
            catch { }
        }

        private void LoadSettings()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (config != null)
                {
                    foreach (string key in ConfigurationManager.AppSettings)
                    {
                        settings.Add(ConfigurationManager.AppSettings[key]);
                    }
                }
            }
            catch { }
        }

        private void AddRow(EventLogEntry entry)
        {
            try
            {
                object[] dr = new object[] { entry.Message, entry.TimeGenerated.ToString(), entry.EntryType.ToString(),
                (entry.UserName != null) ? entry.UserName : "n/a" };

                dtLogger.Rows.Add(dr);
            }
            catch { }
        }

        private void ReadLogger()
        {
            try
            {
                if (settings != null && settings.Count > 0)
                {
                    using (EventLog demoLog = new EventLog(settings.ToArray()[0]))
                    {
                        if (demoLog != null)
                        {
                            EventLogEntryCollection entries = demoLog.Entries;

                            if (entries != null && entries.Count > 0)
                            {
                                if (entries.Count > 0 && entries.Count != lastLogCount)
                                {
                                    if (lastLogCount == 0)
                                    {
                                        foreach (EventLogEntry entry in entries)
                                        {
                                            AddRow(entry);
                                        }
                                    }
                                    else
                                    {
                                        EventLogEntry entry = entries[entries.Count - 1];
                                        AddRow(entry);
                                    }

                                    changed = true;
                                    lastLogCount = entries.Count;
                                }
                                else
                                    changed = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void OnLoadForm(object sender, EventArgs e)
        {
            try
            {
                disableStartStop(false, true);
                LoadSettings();
                OrganiseGrid();

                RunEntries();
            }
            catch { }
        }

        private void RunEntries()
        {
            if (!backgroundWorker.IsBusy && !saveWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ReadLogger();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (changed)
            {
                mtRecords.Text = lastLogCount.ToString();

                dgv.DataSource = dtLogger;
                dgv.Columns[0].Width = this.Width;

                if (dgv.Rows.Count > 0)
                {
                    dgv.Rows[0].Cells[0].Selected = false;
                    dgv.Rows[dgv.Rows.Count - 1].Cells[0].Selected = true;
                    dgv.FirstDisplayedScrollingRowIndex = dgv.Rows.Count - 1;

                    dgv.Refresh();
                }
            }

            RunEntries();
        }

        private void mtClean_Click(object sender, EventArgs e)
        {
            dtLogger.Rows.Clear();
            lastLogCount = 0;
            mtRecords.Text = lastLogCount.ToString();
        }

        private void disableStartStop(bool start, bool stop)
        {
            mtStart.Enabled = start;
            mtStop.Enabled = stop;
        }

        private void mtStart_Click_1(object sender, EventArgs e)
        {
            timer.Start();

            disableStartStop(false, true);
        }

        private void mtStop_Click_1(object sender, EventArgs e)
        {
            timer.Stop();

            disableStartStop(true, false);
        }

        private void SaveFile()
        {
            try
            {
                DataGridView dg = (dataGridSearch.Visible) ? dgvSearch : dgv;
                DataTable dt = (dataGridSearch.Visible) ? dtSearch : dtLogger;

                using (StreamWriter str = new StreamWriter(Path.Combine(Path.GetDirectoryName(saveFileName), 
                    Path.GetFileNameWithoutExtension(saveFileName)) + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm") + ".txt"))
                {
                    for (int i = 0; i <= dg.Rows.Count - 1; i++)
                    {
                        if (dg.Rows[i].Cells[0].Selected == true)
                        {
                            str.WriteLine(">>>> LogEntry Start ---> " + str.NewLine +
                                str.NewLine + "DateTime: " + dt.Rows[i][1] + 
                                str.NewLine + "Type: " + dt.Rows[i][2] + 
                                str.NewLine + "User: " + dt.Rows[i][3] + 
                                str.NewLine + "Message: " + dt.Rows[i][0] + 
                                str.NewLine + str.NewLine + "<--- LogEntry End <<<<" + 
                                str.NewLine + str.NewLine);
                        }
                    }

                    str.Close();
                }
            }
            catch { }
        }

        private void saveWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            SaveFile();
        }

        private void mtSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                int count = (dataGridSearch.Visible) ? dgvSearch.RowCount : dgv.RowCount;

                if (dgv != null && dgvSearch != null && count > 0)
                {
                    using (SaveFileDialog dialog = new SaveFileDialog())
                    {
                        dialog.Filter = "txt files (*.txt)|*.txt";
                        dialog.RestoreDirectory = true;

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            saveFileName = dialog.FileName;

                            if (!saveWorker.IsBusy)
                                saveWorker.RunWorkerAsync();
                        }
                    }
                }
            }
            catch { }
        }

        private void SearchGrid(string txt)
        {
            try
            {
                dtSearch.Rows.Clear();

                for (int i = 0; i <= dgv.Rows.Count - 1; i++)
                {
                    if (dtLogger.Rows[i][0].ToString().ToUpper().Contains(txt.ToUpper()) ||
                        dtLogger.Rows[i][1].ToString().ToUpper().Contains(txt.ToUpper()) ||
                        dtLogger.Rows[i][2].ToString().ToUpper().Contains(txt.ToUpper()) ||
                        dtLogger.Rows[i][3].ToString().ToUpper().Contains(txt.ToUpper()))
                    {
                        object[] dr = new object[] { dtLogger.Rows[i][0].ToString(),
                            dtLogger.Rows[i][1].ToString(), dtLogger.Rows[i][2].ToString(),
                            dtLogger.Rows[i][3].ToString() };

                        
                        dtSearch.Rows.Add(dr);
                    }
                }

                dgvSearch.DataSource = dtSearch;
                dgvSearch.Columns[0].Width = this.Width;

                if (dgvSearch.Rows.Count > 0)
                {
                    dataGridSearch.Visible = true;
                    mtRecords.Text = dgvSearch.Rows.Count.ToString();

                    dgvSearch.Rows[0].Cells[0].Selected = false;
                    dgvSearch.Rows[dgvSearch.Rows.Count - 1].Cells[0].Selected = true;

                    dgvSearch.FirstDisplayedScrollingRowIndex = dgvSearch.Rows.Count - 1;
                    dgvSearch.Refresh();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void GetStartStopState()
        {
            mtStart.Visible = false;
            mtStop.Visible = false;
        }

        private void SetStartStopState()
        {
            mtStart.Visible = true;
            mtStop.Visible = true;
        }

        private void DoSearch()
        {
            if (tbSearch.Text != String.Empty)
            {
                mtClean.Enabled = false;
                GetStartStopState();

                SearchGrid(tbSearch.Text);
            }
            else
            {
                dataGridSearch.Visible = false;
                mtRecords.Text = dgv.Rows.Count.ToString();

                SetStartStopState();
                mtClean.Enabled = true;
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            DoSearch();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (dataGridView.Visible)
            {
                if (dgv.RowCount > 0)
                {
                    dgv.FirstDisplayedScrollingRowIndex = dgv.Rows.Count - 1;
                }
            }
            else
            {
                if (dgvSearch.RowCount > 0)
                {
                    dgvSearch.FirstDisplayedScrollingRowIndex = dgvSearch.Rows.Count - 1;
                }
            }
        }
    }
}
