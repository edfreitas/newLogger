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

namespace newLogger
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.mtRecords = new MetroFramework.Controls.MetroLabel();
            this.mtClean = new MetroFramework.Controls.MetroTile();
            this.mtSave = new MetroFramework.Controls.MetroTile();
            this.mtStop = new MetroFramework.Controls.MetroTile();
            this.mtStart = new MetroFramework.Controls.MetroTile();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.dataGridSearch = new System.Windows.Forms.DataGridView();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.saveWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(20, 60);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.mtRecords);
            this.splitContainer.Panel1.Controls.Add(this.mtClean);
            this.splitContainer.Panel1.Controls.Add(this.mtSave);
            this.splitContainer.Panel1.Controls.Add(this.mtStop);
            this.splitContainer.Panel1.Controls.Add(this.mtStart);
            this.splitContainer.Panel1.Controls.Add(this.tbSearch);
            this.splitContainer.Panel1MinSize = 45;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dataGridSearch);
            this.splitContainer.Panel2.Controls.Add(this.dataGridView);
            this.splitContainer.Size = new System.Drawing.Size(812, 342);
            this.splitContainer.SplitterDistance = 60;
            this.splitContainer.TabIndex = 9;
            // 
            // mtRecords
            // 
            this.mtRecords.AutoSize = true;
            this.mtRecords.Location = new System.Drawing.Point(395, 32);
            this.mtRecords.Name = "mtRecords";
            this.mtRecords.Size = new System.Drawing.Size(17, 20);
            this.mtRecords.TabIndex = 14;
            this.mtRecords.Text = "0";
            // 
            // mtClean
            // 
            this.mtClean.Location = new System.Drawing.Point(93, 28);
            this.mtClean.Name = "mtClean";
            this.mtClean.Size = new System.Drawing.Size(109, 28);
            this.mtClean.TabIndex = 13;
            this.mtClean.Text = "Clear View";
            this.mtClean.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mtClean.Click += new System.EventHandler(this.mtClean_Click);
            // 
            // mtSave
            // 
            this.mtSave.Location = new System.Drawing.Point(3, 28);
            this.mtSave.Name = "mtSave";
            this.mtSave.Size = new System.Drawing.Size(84, 28);
            this.mtSave.TabIndex = 12;
            this.mtSave.Text = "Save";
            this.mtSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mtSave.Click += new System.EventHandler(this.mtSave_Click_1);
            // 
            // mtStop
            // 
            this.mtStop.Location = new System.Drawing.Point(298, 28);
            this.mtStop.Name = "mtStop";
            this.mtStop.Size = new System.Drawing.Size(84, 28);
            this.mtStop.TabIndex = 11;
            this.mtStop.Text = "Stop";
            this.mtStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mtStop.Click += new System.EventHandler(this.mtStop_Click_1);
            // 
            // mtStart
            // 
            this.mtStart.Location = new System.Drawing.Point(208, 28);
            this.mtStart.Name = "mtStart";
            this.mtStart.Size = new System.Drawing.Size(84, 28);
            this.mtStart.TabIndex = 10;
            this.mtStart.Text = "Start";
            this.mtStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mtStart.Click += new System.EventHandler(this.mtStart_Click_1);
            // 
            // tbSearch
            // 
            this.tbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbSearch.Location = new System.Drawing.Point(0, 0);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(812, 22);
            this.tbSearch.TabIndex = 9;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // dataGridSearch
            // 
            this.dataGridSearch.AllowUserToAddRows = false;
            this.dataGridSearch.AllowUserToDeleteRows = false;
            this.dataGridSearch.AllowUserToOrderColumns = true;
            this.dataGridSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridSearch.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridSearch.GridColor = System.Drawing.Color.LightSkyBlue;
            this.dataGridSearch.Location = new System.Drawing.Point(0, 0);
            this.dataGridSearch.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridSearch.Name = "dataGridSearch";
            this.dataGridSearch.ReadOnly = true;
            this.dataGridSearch.Size = new System.Drawing.Size(812, 278);
            this.dataGridSearch.TabIndex = 6;
            this.dataGridSearch.VirtualMode = true;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.GridColor = System.Drawing.Color.LightSkyBlue;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(812, 278);
            this.dataGridView.TabIndex = 5;
            this.dataGridView.VirtualMode = true;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // saveWorker
            // 
            this.saveWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.saveWorker_DoWork);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 422);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(526, 362);
            this.Name = "Main";
            this.Text = "Event Inspector";
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Load += new System.EventHandler(this.OnLoadForm);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer;
        private MetroFramework.Controls.MetroTile mtSave;
        private MetroFramework.Controls.MetroTile mtStop;
        private MetroFramework.Controls.MetroTile mtStart;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Timer timer;
        private MetroFramework.Controls.MetroTile mtClean;
        private MetroFramework.Controls.MetroLabel mtRecords;
        private System.ComponentModel.BackgroundWorker saveWorker;
        private System.Windows.Forms.DataGridView dataGridSearch;
    }
}

