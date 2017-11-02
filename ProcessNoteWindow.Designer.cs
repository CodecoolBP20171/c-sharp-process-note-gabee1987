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
            this.SaveCommentButton = new System.Windows.Forms.Button();
            this.processGrid = new System.Windows.Forms.DataGridView();
            this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RefreshAllButton = new System.Windows.Forms.Button();
            this.ProcessDetails = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SelectedProcessDetails = new System.Windows.Forms.ListView();
            this.RefreshSelectedButton = new System.Windows.Forms.Button();
            this.CommentBox = new System.Windows.Forms.TextBox();
            this.AlwaysOnTop = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.processGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveCommentButton
            // 
            this.SaveCommentButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SaveCommentButton.Location = new System.Drawing.Point(894, 655);
            this.SaveCommentButton.Name = "SaveCommentButton";
            this.SaveCommentButton.Size = new System.Drawing.Size(140, 40);
            this.SaveCommentButton.TabIndex = 1;
            this.SaveCommentButton.Text = "Save comment";
            this.SaveCommentButton.UseVisualStyleBackColor = false;
            this.SaveCommentButton.Click += new System.EventHandler(this.SaveCommentButton_Click);
            // 
            // processGrid
            // 
            this.processGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.processGrid.BackgroundColor = System.Drawing.SystemColors.Info;
            this.processGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.processGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.processGrid.GridColor = System.Drawing.SystemColors.WindowFrame;
            this.processGrid.Location = new System.Drawing.Point(12, 12);
            this.processGrid.Name = "processGrid";
            this.processGrid.RowHeadersVisible = false;
            this.processGrid.RowHeadersWidth = 30;
            this.processGrid.RowTemplate.Height = 24;
            this.processGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.processGrid.Size = new System.Drawing.Size(873, 683);
            this.processGrid.TabIndex = 2;
            this.processGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.processGrid_CellFormatting);
            this.processGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.processGrid_CellMouseDoubleClick);
            // 
            // RefreshAllButton
            // 
            this.RefreshAllButton.Location = new System.Drawing.Point(894, 47);
            this.RefreshAllButton.Name = "RefreshAllButton";
            this.RefreshAllButton.Size = new System.Drawing.Size(140, 40);
            this.RefreshAllButton.TabIndex = 3;
            this.RefreshAllButton.Text = "Refresh All";
            this.RefreshAllButton.UseVisualStyleBackColor = true;
            this.RefreshAllButton.Click += new System.EventHandler(this.RefreshAllButton_Click);
            // 
            // ProcessDetails
            // 
            this.ProcessDetails.AutoSize = true;
            this.ProcessDetails.Location = new System.Drawing.Point(891, 90);
            this.ProcessDetails.Name = "ProcessDetails";
            this.ProcessDetails.Size = new System.Drawing.Size(118, 17);
            this.ProcessDetails.TabIndex = 5;
            this.ProcessDetails.Text = "Selected Process";
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(1098, 655);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(140, 40);
            this.CloseButton.TabIndex = 7;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SelectedProcessDetails
            // 
            this.SelectedProcessDetails.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SelectedProcessDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SelectedProcessDetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.SelectedProcessDetails.Location = new System.Drawing.Point(894, 110);
            this.SelectedProcessDetails.Name = "SelectedProcessDetails";
            this.SelectedProcessDetails.Size = new System.Drawing.Size(344, 168);
            this.SelectedProcessDetails.TabIndex = 8;
            this.SelectedProcessDetails.UseCompatibleStateImageBehavior = false;
            // 
            // RefreshSelectedButton
            // 
            this.RefreshSelectedButton.Location = new System.Drawing.Point(1098, 47);
            this.RefreshSelectedButton.Name = "RefreshSelectedButton";
            this.RefreshSelectedButton.Size = new System.Drawing.Size(140, 40);
            this.RefreshSelectedButton.TabIndex = 10;
            this.RefreshSelectedButton.Text = "Refresh Selected";
            this.RefreshSelectedButton.UseVisualStyleBackColor = true;
            this.RefreshSelectedButton.Click += new System.EventHandler(this.RefreshSelectedButton_Click);
            // 
            // CommentBox
            // 
            this.CommentBox.Location = new System.Drawing.Point(894, 478);
            this.CommentBox.Multiline = true;
            this.CommentBox.Name = "CommentBox";
            this.CommentBox.Size = new System.Drawing.Size(344, 162);
            this.CommentBox.TabIndex = 11;
            this.CommentBox.TextChanged += new System.EventHandler(this.CommentBox_TextChanged);
            // 
            // AlwaysOnTop
            // 
            this.AlwaysOnTop.AutoSize = true;
            this.AlwaysOnTop.Location = new System.Drawing.Point(1113, 20);
            this.AlwaysOnTop.Name = "AlwaysOnTop";
            this.AlwaysOnTop.Size = new System.Drawing.Size(125, 21);
            this.AlwaysOnTop.TabIndex = 12;
            this.AlwaysOnTop.Text = "Always On Top";
            this.AlwaysOnTop.UseVisualStyleBackColor = true;
            this.AlwaysOnTop.CheckedChanged += new System.EventHandler(this.AlwaysOnTop_CheckedChanged);
            // 
            // ProcessNoteWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 711);
            this.Controls.Add(this.AlwaysOnTop);
            this.Controls.Add(this.CommentBox);
            this.Controls.Add(this.RefreshSelectedButton);
            this.Controls.Add(this.SelectedProcessDetails);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ProcessDetails);
            this.Controls.Add(this.RefreshAllButton);
            this.Controls.Add(this.processGrid);
            this.Controls.Add(this.SaveCommentButton);
            this.Name = "ProcessNoteWindow";
            this.Text = "                  ";
            this.Load += new System.EventHandler(this.ProcessNoteWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.processGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SaveCommentButton;
        private System.Windows.Forms.BindingSource programBindingSource;
        private System.Windows.Forms.DataGridView processGrid;
        private System.Windows.Forms.Button RefreshAllButton;
        private System.Windows.Forms.Label ProcessDetails;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.ListView SelectedProcessDetails;
        private System.Windows.Forms.Button RefreshSelectedButton;
        private System.Windows.Forms.TextBox CommentBox;
        private System.Windows.Forms.CheckBox AlwaysOnTop;
    }
}