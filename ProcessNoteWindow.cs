using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace process_note
{
    public partial class ProcessNoteWindow : Form
    {
        public ProcessNoteWindow()
        {
            InitializeComponent();
            this.Text = "Running processes";
            SelectedProcessDetails.View = View.List;

            loadProcesses(null, null);
            /*
            Timer ticker = new Timer();
            ticker.Interval = 250;
            ticker.Tick += loadProcesses;
            ticker.Start();
            */
        }

        void loadProcesses(object sender, EventArgs e)
        {
            BindingSource source = new BindingSource();
            var processTable = new DataTable("Process List");

            Process[] localProcesses = Process.GetProcesses();

            
            processTable.Columns.Add("Process ID");
            //processTable.Columns.Add("Application name");
            processTable.Columns.Add("Process Name");
            processTable.Columns.Add("Memory Usage");
            processTable.Columns.Add("Peak Memory Usage");
            processTable.Columns.Add("Process Start Time");
            processTable.Columns.Add("Process Time");
            processTable.Columns.Add("Threads");

            foreach (var process in localProcesses)
            {
                try
                {
                    object[] rowCellDatas = {
                    process.Id.ToString(),
                    //Path.GetFileName(process.MainModule.FileName),
                    process.ProcessName,
                    (process.WorkingSet64 / 1048576).ToString() + " MB",
                    (process.PeakWorkingSet64 / 1048576).ToString() + " MB",
                    process.StartTime.ToShortTimeString(),
                    process.TotalProcessorTime.Duration().Hours.ToString() + " h:" + process.TotalProcessorTime.Duration().Minutes.ToString() + " m:"+process.TotalProcessorTime.Duration().Seconds.ToString() + " s",
                    process.Threads.Count.ToString()
                };
                    processTable.Rows.Add(rowCellDatas);
                }
                catch (Win32Exception we)
                {
                    //MessageBox.Show(we.Message);
                }
            }
            processTable.AcceptChanges();
            source.DataSource = processTable;
            processGrid.DataSource = source;

            DataGridViewColumn processIdColumn = processGrid.Columns[0];
            DataGridViewColumn processNameColumn = processGrid.Columns[1];
            DataGridViewColumn processMemoryUsageColumn = processGrid.Columns[2];
            DataGridViewColumn processPeakMemoryUsageColumn = processGrid.Columns[3];
            DataGridViewColumn processStartTimeColumn = processGrid.Columns[4];
            DataGridViewColumn processTimeColumn = processGrid.Columns[5];
            DataGridViewColumn threadsColumn = processGrid.Columns[6];

            processIdColumn.FillWeight = 40;
            processNameColumn.FillWeight = 100;
            processMemoryUsageColumn.FillWeight = 50;
            processPeakMemoryUsageColumn.FillWeight = 50;
            processStartTimeColumn.FillWeight = 50;
            processTimeColumn.FillWeight = 50;
            threadsColumn.FillWeight = 30;

        }

        private void RefreshAllButton_Click(object sender, EventArgs e)
        {
            processGrid.DataSource = null;
            //processGrid.Refresh();
            loadProcesses(null, null);
        }

        private void SaveCommentButton_Click(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {

        }

        private void ProcessNoteWindow_Load(object sender, EventArgs e)
        {

        }

        private void processGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedProcessDetails.Items.Clear();
            string processId = processGrid.Rows[e.RowIndex].Cells["Process ID"].Value.ToString();
            string processName = processGrid.Rows[e.RowIndex].Cells["Process Name"].Value.ToString();
            string processMemoryUsage = processGrid.Rows[e.RowIndex].Cells["Memory Usage"].Value.ToString();
            string processPeakMemoryUsage = processGrid.Rows[e.RowIndex].Cells["Peak Memory Usage"].Value.ToString();
            string processStartTime = processGrid.Rows[e.RowIndex].Cells["Process Start Time"].Value.ToString();
            string processTime = processGrid.Rows[e.RowIndex].Cells["Process Time"].Value.ToString();
            string processThreads = processGrid.Rows[e.RowIndex].Cells["Threads"].Value.ToString();

            this.SelectedProcessDetails.Items.Add(String.Format("Process ID: {0}", processId));
            this.SelectedProcessDetails.Items.Add(String.Format("Process Name: {0}", processName));
            this.SelectedProcessDetails.Items.Add(String.Format("Memory Usage: {0}", processMemoryUsage));
            this.SelectedProcessDetails.Items.Add(String.Format("Peak Memory Usage: {0}", processPeakMemoryUsage));
            this.SelectedProcessDetails.Items.Add(String.Format("Process Start Time: {0}", processStartTime));
            this.SelectedProcessDetails.Items.Add(String.Format("Process Time: {0}", processTime));
            this.SelectedProcessDetails.Items.Add(String.Format("Threads: {0}", processThreads));
        }
    }
}
