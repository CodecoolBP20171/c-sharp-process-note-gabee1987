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
            Process[] localAll = Process.GetProcesses();

            processGrid.ColumnCount = 3;
            processGrid.Columns[0].Name = "Process ID";
            processGrid.Columns[1].Name = "Process Name";
            processGrid.Columns[2].Name = "Memory usage";


            foreach (var process in localAll)
            {
                string[] rowName = { process.Id.ToString(),  process.ProcessName, (process.WorkingSet64 / 1048576).ToString() + " MB" };
                processGrid.Rows.Add(rowName);
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
