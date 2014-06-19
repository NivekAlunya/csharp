namespace Employees.Windows
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiEntries = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsmiEntriesService = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEntriesEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiApplicationQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEntries,
            this.tsmiApplication});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(966, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiEntries
            // 
            this.tsmiEntries.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEntriesService,
            this.tsmiEntriesEmployee});
            this.tsmiEntries.Name = "tsmiEntries";
            this.tsmiEntries.Size = new System.Drawing.Size(52, 20);
            this.tsmiEntries.Text = "Entries";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(966, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsmiEntriesService
            // 
            this.tsmiEntriesService.CheckOnClick = true;
            this.tsmiEntriesService.Name = "tsmiEntriesService";
            this.tsmiEntriesService.Size = new System.Drawing.Size(152, 22);
            this.tsmiEntriesService.Text = "Service";
            this.tsmiEntriesService.Click += new System.EventHandler(this.tsmiEntriesService_Click);
            // 
            // tsmiEmployee
            // 
            this.tsmiEntriesEmployee.Name = "tsmiEntriesEmployee";
            this.tsmiEntriesEmployee.Size = new System.Drawing.Size(152, 22);
            this.tsmiEntriesEmployee.Text = "Employee";
            this.tsmiEntriesEmployee.Click += new System.EventHandler(this.tsmiEntriesEmployee_Click);
            // 
            // tsmiApplication
            // 
            this.tsmiApplication.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiApplicationQuit});
            this.tsmiApplication.Name = "tsmiApplication";
            this.tsmiApplication.Size = new System.Drawing.Size(71, 20);
            this.tsmiApplication.Text = "Application";
            // 
            // tsmiApplicationQuit
            // 
            this.tsmiApplicationQuit.Name = "tsmiApplicationQuit";
            this.tsmiApplicationQuit.Size = new System.Drawing.Size(152, 22);
            this.tsmiApplicationQuit.Text = "Quit";
            this.tsmiApplicationQuit.Click += new System.EventHandler(this.tsmiApplicationQuit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 669);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiEntries;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiEntriesService;
        private System.Windows.Forms.ToolStripMenuItem tsmiEntriesEmployee;
        private System.Windows.Forms.ToolStripMenuItem tsmiApplication;
        private System.Windows.Forms.ToolStripMenuItem tsmiApplicationQuit;
    }
}