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
using System.Text.RegularExpressions;

namespace process_note
{
    public partial class ProcessNoteWindow : Form
    {
        private int selectedProcessId;
        private Dictionary<int, string> savedCommentsDict = new Dictionary<int, string>();

        public ProcessNoteWindow()
        {
            InitializeComponent();
            this.Text = "Running processes";
            SelectedProcessDetails.View = View.List;

            loadProcesses(null, null);
        }

        void loadProcesses(object sender, EventArgs e)
        {
            BindingSource source = new BindingSource();
            var processTable = new DataTable("Process List");

            Process[] localProcesses = Process.GetProcesses();

            
            processTable.Columns.Add("Process ID");
            processTable.Columns.Add("Process Name");
            processTable.Columns.Add("Memory Usage (MB)");
            processTable.Columns.Add("Peak Memory Usage (MB)");
            processTable.Columns.Add("Process Start Time");
            processTable.Columns.Add("Process Time");
            processTable.Columns.Add("Threads");

            foreach (var process in localProcesses)
            {
                try
                {
                    object[] rowCellDatas = {
                    process.Id.ToString(),
                    process.ProcessName,
                    (process.WorkingSet64 / 1048576),
                    (process.PeakWorkingSet64 / 1048576),
                    process.StartTime.ToShortTimeString(),
                    process.TotalProcessorTime.Duration().Hours.ToString() + " h:" + process.TotalProcessorTime.Duration().Minutes.ToString() + " m:"+process.TotalProcessorTime.Duration().Seconds.ToString() + " s",
                    process.Threads.Count.ToString()
                };
                    processTable.Rows.Add(rowCellDatas);
                }
                catch (Win32Exception we)
                {
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

        private void RefreshSelectedButton_Click(object sender, EventArgs e)
        {
            Process selectedProcess = Process.GetProcessById(selectedProcessId);
            selectedProcess.Refresh();

            string selectedProcessID = selectedProcess.Id.ToString();
            string selectedProcessName = selectedProcess.ProcessName;
            string selectedProcessMemoryUsage = (selectedProcess.WorkingSet64 / 1048576).ToString();
            string selectedProcessPeakMemoryUsage = (selectedProcess.PeakWorkingSet64 / 1048576).ToString();
            string selectedProcessStartTime = selectedProcess.StartTime.ToShortTimeString();
            string selectedProcessTime = selectedProcess.TotalProcessorTime.Duration().Hours.ToString() + " h:" + selectedProcess.TotalProcessorTime.Duration().Minutes.ToString() + " m:" + selectedProcess.TotalProcessorTime.Duration().Seconds.ToString() + " s";
            string selectedProcessThreads = selectedProcess.Threads.Count.ToString();

            SelectedProcessDetails.Items.Clear();
            this.SelectedProcessDetails.Items.Add(String.Format("Process ID: {0}", selectedProcessID));
            this.SelectedProcessDetails.Items.Add(String.Format("Process Name: {0}", selectedProcessName));
            this.SelectedProcessDetails.Items.Add(String.Format("Memory Usage (MB): {0}", selectedProcessMemoryUsage));
            this.SelectedProcessDetails.Items.Add(String.Format("Peak Memory Usage (MB): {0}", selectedProcessPeakMemoryUsage));
            this.SelectedProcessDetails.Items.Add(String.Format("Process Start Time: {0}", selectedProcessStartTime));
            this.SelectedProcessDetails.Items.Add(String.Format("Process Time: {0}", selectedProcessTime));
            this.SelectedProcessDetails.Items.Add(String.Format("Threads: {0}", selectedProcessThreads));
        }

        private void SaveCommentButton_Click(object sender, EventArgs e)
        {
            string savedComment = "";
            savedComment = this.CommentBox.Text;
            savedCommentsDict[selectedProcessId] = savedComment;
            SaveCommentButton.BackColor = Color.Aquamarine;

        }

        private void CommentBox_TextChanged(object sender, EventArgs e)
        {
            SaveCommentButton.BackColor = Color.LightSalmon;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProcessNoteWindow_Load(object sender, EventArgs e)
        {

        }

        private void processGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SelectedProcessDetails.Items.Clear();
            selectedProcessId = Convert.ToInt32(processGrid.Rows[e.RowIndex].Cells["Process ID"].Value);
            string processId = processGrid.Rows[e.RowIndex].Cells["Process ID"].Value.ToString();
            string processName = processGrid.Rows[e.RowIndex].Cells["Process Name"].Value.ToString();
            string processMemoryUsage = processGrid.Rows[e.RowIndex].Cells["Memory Usage (MB)"].Value.ToString();
            string processPeakMemoryUsage = processGrid.Rows[e.RowIndex].Cells["Peak Memory Usage (MB)"].Value.ToString();
            string processStartTime = processGrid.Rows[e.RowIndex].Cells["Process Start Time"].Value.ToString();
            string processTime = processGrid.Rows[e.RowIndex].Cells["Process Time"].Value.ToString();
            string processThreads = processGrid.Rows[e.RowIndex].Cells["Threads"].Value.ToString();

            this.SelectedProcessDetails.Items.Add(String.Format("Process ID: {0}", processId));
            this.SelectedProcessDetails.Items.Add(String.Format("Process Name: {0}", processName));
            this.SelectedProcessDetails.Items.Add(String.Format("Memory Usage (MB): {0}", processMemoryUsage));
            this.SelectedProcessDetails.Items.Add(String.Format("Peak Memory Usage (MB): {0}", processPeakMemoryUsage));
            this.SelectedProcessDetails.Items.Add(String.Format("Process Start Time: {0}", processStartTime));
            this.SelectedProcessDetails.Items.Add(String.Format("Process Time: {0}", processTime));
            this.SelectedProcessDetails.Items.Add(String.Format("Threads: {0}", processThreads));

            string selectedProcessComment;
            try
            {
                bool hasValue = savedCommentsDict.TryGetValue(selectedProcessId, out selectedProcessComment);
                if (hasValue)
                {
                    CommentBox.Text = selectedProcessComment;
                }
                else
                {
                    CommentBox.Text = String.Empty;
                }
            } catch
            {

            }

            SaveCommentButton.BackColor = DefaultBackColor;
        }

        private void AlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = this.AlwaysOnTop.Checked;
        }

        private void processGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (processGrid.Columns[e.ColumnIndex].Name.Equals("Memory Usage (MB)"))
            {
                Int32 intLowValue;
                if (Int32.TryParse((String)e.Value, out intLowValue) && (intLowValue > 50))
                {
                    e.CellStyle.BackColor = Color.Moccasin;
                    e.CellStyle.SelectionBackColor = Color.Moccasin;
                }
            }
            if (processGrid.Columns[e.ColumnIndex].Name.Equals("Memory Usage (MB)"))
            {
                Int32 intMediumValue;
                if (Int32.TryParse((String)e.Value, out intMediumValue) && (intMediumValue > 100))
                {
                    e.CellStyle.BackColor = Color.Orange;
                    e.CellStyle.SelectionBackColor = Color.Orange;
                }
            }
            if (processGrid.Columns[e.ColumnIndex].Name.Equals("Memory Usage (MB)"))
            {
                Int32 intHighValue;
                if (Int32.TryParse((String)e.Value, out intHighValue) && (intHighValue > 150))
                {
                    e.CellStyle.BackColor = Color.LightSalmon;
                    e.CellStyle.SelectionBackColor = Color.LightSalmon;
                }
            }
            if (processGrid.Columns[e.ColumnIndex].Name.Equals("Memory Usage (MB)"))
            {
                Int32 intVeryHighValue;
                if (Int32.TryParse((String)e.Value, out intVeryHighValue) && (intVeryHighValue > 200))
                {
                    e.CellStyle.BackColor = Color.OrangeRed;
                    e.CellStyle.SelectionBackColor = Color.OrangeRed;
                }
            }
        }
    }
}
