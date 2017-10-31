namespace process_note
{
    partial class ProcessNoteWindow
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
            this.processes = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.processGrid = new System.Windows.Forms.DataGridView();
            this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.processGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // processes
            // 
            this.processes.AutoSize = true;
            this.processes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.processes.Location = new System.Drawing.Point(46, 32);
            this.processes.Name = "processes";
            this.processes.Size = new System.Drawing.Size(110, 25);
            this.processes.TabIndex = 0;
            this.processes.Text = "Processes:";
            this.processes.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1095, 701);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Make a comment";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // processGrid
            // 
            this.processGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.processGrid.Location = new System.Drawing.Point(51, 76);
            this.processGrid.Name = "processGrid";
            this.processGrid.RowTemplate.Height = 24;
            this.processGrid.Size = new System.Drawing.Size(1184, 607);
            this.processGrid.TabIndex = 2;
            // 
            // ProcessNoteWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.processGrid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.processes);
            this.Name = "ProcessNoteWindow";
            this.Text = "                  ";
            ((System.ComponentModel.ISupportInitialize)(this.processGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label processes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource programBindingSource;
        private System.Windows.Forms.DataGridView processGrid;
    }
}