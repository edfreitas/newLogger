# newLogger
A Simpler Windows Event Viewer

Before running the .exe, open with Notepad the file: newLogger.exe.config and change:

<add key="loggerName" value="Windows PowerShell"/>

to

<add key="loggerName" value="<< the name of your app on the Windows Event Viewer >>"/>

Save the newLogger.exe.config and run the .exe


This setting: <add key="loggerName" value="Windows PowerShell"/>

Means that this newLogger can be configured to work with any application that writes to the Event Viewer.

There are 4 buttons: Start, Stop, Save and Clear View.

Start is enabled by default and it means that the newLogger is checking for any updates on the Event Viewer and if it finds any it inserts it as the last row of the data grid (item highlighted and at the bottom of the screen).

The Stop button as it's name implies it means that the newLogger is stopped and not monitoring for new Events within the Event Viewer.

Note that the items on the grid are order by default based on the date they were written to the Event Viewer (oldest on the top) and newest in the bottom.

You can also order by each column Ascending or Descending.

You can Save the items selected to a text file (even when filtering with a search). The output of the file is nicely organised for easy ready. It is exported in the same order that the items are listed on the Grid.

In order to filter, there is a TextBox at the very top and all you need to do it to type a keyword of what you want to search and the results will be limited to what it finds based on that keyword. When the TextBox contains text, the Start and Stop buttons are hidden, as the grid view is limited to the items searched only. If the TextBox is cleared, Start and Stop buttons are shown again (even during when search is displayed, if the "Start" button is greyed out & and the Stop button Enabled, active monitoring for new events will take place, but new events will not be part of the search until a new search is done).

Please note that all the events are pulled from the Event Viewer only the first time the application loads and after it is running it only pulls the most recent event of the Event Viewer (if monitoring is taking place =  "Start" button is greyed out & and the Stop button Enabled - not greyed out). The last event is always added to the Grid as the last row of the grid.

During a file save the monitoring of new events is temporarily disabled (if the "Start" button is greyed out & and the Stop button Enabled).

The newLogger has a Windows 10 look and feel and was compiled against .NET 4.5.

The file saving and even monitoring operations run on background threads so that they do not block the GUI of the application.

License: MIT.
