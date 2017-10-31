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
            loadProcesses();   
        }

        private void loadProcesses()
        {

            Process[] localAll = null;
            try
            {
                localAll = Process.GetProcesses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
                return;
            }

            int threadscount = 0;

            processGrid.ColumnCount = 7;
            processGrid.Columns[0].Name = "Process ID";
            processGrid.Columns[1].Name = "Process Name";
            processGrid.Columns[2].Name = "Memory Usage";
            processGrid.Columns[3].Name = "Peak Memory Usage";
            processGrid.Columns[4].Name = "Process Start Time";
            processGrid.Columns[5].Name = "Process Time";
            processGrid.Columns[6].Name = "Threads";






            foreach (var process in localAll)
            {
                try
                {
                string[] rowName = {
                    process.Id.ToString(),
                    process.ProcessName,
                    (process.WorkingSet64 / 1048576).ToString() + " MB",
                    (process.PeakWorkingSet / 1048576).ToString() + "MB",
                    process.StartTime.ToShortTimeString(),
                    process.TotalProcessorTime.Duration().Hours.ToString()+":"+process.TotalProcessorTime.Duration().Minutes.ToString()+":"+process.TotalProcessorTime.Duration().Seconds.ToString(),
                    process.Threads.Count.ToString()
                };
                processGrid.Rows.Add(rowName);
                } catch (Win32Exception e){
                    MessageBox.Show(e.Message);
                }
            }

        }

        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
