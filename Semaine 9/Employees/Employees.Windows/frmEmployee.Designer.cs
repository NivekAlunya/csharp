namespace Employees.Windows
{
    partial class frmEmployee
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblSeniority = new System.Windows.Forms.Label();
            this.lblEmployedAt = new System.Windows.Forms.Label();
            this.tsEmployee = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbValidate = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.dtDOB = new System.Windows.Forms.DateTimePicker();
            this.dtEmployedAt = new System.Windows.Forms.DateTimePicker();
            this.lblService = new System.Windows.Forms.Label();
            this.lblChief = new System.Windows.Forms.Label();
            this.lblServiceValue = new System.Windows.Forms.Label();
            this.cmbChief = new System.Windows.Forms.ComboBox();
            this.navBar = new MyCompany.Controls.NavigationBar();
            this.serviceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblSalary = new System.Windows.Forms.Label();
            this.nudSalary = new System.Windows.Forms.NumericUpDown();
            this.tsEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSalary)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // txtFirstname
            // 
            this.txtFirstname.Location = new System.Drawing.Point(65, 36);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(100, 20);
            this.txtFirstname.TabIndex = 10;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(171, 36);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(100, 20);
            this.txtSurname.TabIndex = 11;
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new System.Drawing.Point(14, 65);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(30, 13);
            this.lblDOB.TabIndex = 3;
            this.lblDOB.Text = "DOB";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(171, 65);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(0, 13);
            this.lblAge.TabIndex = 8;
            // 
            // lblSeniority
            // 
            this.lblSeniority.AutoSize = true;
            this.lblSeniority.Location = new System.Drawing.Point(171, 91);
            this.lblSeniority.Name = "lblSeniority";
            this.lblSeniority.Size = new System.Drawing.Size(0, 13);
            this.lblSeniority.TabIndex = 9;
            // 
            // lblEmployedAt
            // 
            this.lblEmployedAt.AutoSize = true;
            this.lblEmployedAt.Location = new System.Drawing.Point(14, 91);
            this.lblEmployedAt.Name = "lblEmployedAt";
            this.lblEmployedAt.Size = new System.Drawing.Size(50, 13);
            this.lblEmployedAt.TabIndex = 4;
            this.lblEmployedAt.Text = "Entrance";
            // 
            // tsEmployee
            // 
            this.tsEmployee.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbDel,
            this.toolStripSeparator1,
            this.tsbValidate,
            this.tsbCancel,
            this.toolStripSeparator2,
            this.tsbClose});
            this.tsEmployee.Location = new System.Drawing.Point(0, 0);
            this.tsEmployee.Name = "tsEmployee";
            this.tsEmployee.Size = new System.Drawing.Size(292, 25);
            this.tsEmployee.TabIndex = 0;
            // 
            // tsbAdd
            // 
            this.tsbAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(32, 22);
            this.tsbAdd.Text = "ADD";
            this.tsbAdd.ToolTipText = "Add employee";
            // 
            // tsbDel
            // 
            this.tsbDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tsbDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(29, 22);
            this.tsbDel.Text = "DEL";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbValidate
            // 
            this.tsbValidate.BackColor = System.Drawing.Color.Lime;
            this.tsbValidate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbValidate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbValidate.Name = "tsbValidate";
            this.tsbValidate.Size = new System.Drawing.Size(59, 22);
            this.tsbValidate.Text = "VALIDATE";
            this.tsbValidate.ToolTipText = "VALIDATE";
            // 
            // tsbCancel
            // 
            this.tsbCancel.BackColor = System.Drawing.Color.Red;
            this.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(50, 22);
            this.tsbCancel.Text = "CANCEL";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbClose
            // 
            this.tsbClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(37, 22);
            this.tsbClose.Text = "Close";
            // 
            // dtDOB
            // 
            this.dtDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDOB.Location = new System.Drawing.Point(65, 65);
            this.dtDOB.Name = "dtDOB";
            this.dtDOB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtDOB.Size = new System.Drawing.Size(100, 20);
            this.dtDOB.TabIndex = 12;
            // 
            // dtEmployedAt
            // 
            this.dtEmployedAt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEmployedAt.Location = new System.Drawing.Point(65, 91);
            this.dtEmployedAt.Name = "dtEmployedAt";
            this.dtEmployedAt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtEmployedAt.Size = new System.Drawing.Size(100, 20);
            this.dtEmployedAt.TabIndex = 13;
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Location = new System.Drawing.Point(14, 123);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(43, 13);
            this.lblService.TabIndex = 5;
            this.lblService.Text = "Service";
            // 
            // lblChief
            // 
            this.lblChief.AutoSize = true;
            this.lblChief.Location = new System.Drawing.Point(14, 151);
            this.lblChief.Name = "lblChief";
            this.lblChief.Size = new System.Drawing.Size(31, 13);
            this.lblChief.TabIndex = 6;
            this.lblChief.Text = "Chief";
            // 
            // lblServiceValue
            // 
            this.lblServiceValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblServiceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceValue.Location = new System.Drawing.Point(65, 120);
            this.lblServiceValue.Name = "lblServiceValue";
            this.lblServiceValue.Size = new System.Drawing.Size(206, 22);
            this.lblServiceValue.TabIndex = 14;
            this.lblServiceValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbChief
            // 
            this.cmbChief.FormattingEnabled = true;
            this.cmbChief.Location = new System.Drawing.Point(65, 148);
            this.cmbChief.Name = "cmbChief";
            this.cmbChief.Size = new System.Drawing.Size(206, 21);
            this.cmbChief.TabIndex = 15;
            // 
            // navBar
            // 
            this.navBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navBar.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBar.LinkColor = System.Drawing.Color.Black;
            this.navBar.LinkEnabled = true;
            this.navBar.LinkFirst = "1";
            this.navBar.LinkLast = "n";
            this.navBar.LinkNext = "+";
            this.navBar.LinkPrevious = "-";
            this.navBar.Location = new System.Drawing.Point(0, 211);
            this.navBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.navBar.Name = "navBar";
            this.navBar.Size = new System.Drawing.Size(292, 30);
            this.navBar.TabIndex = 1;
            // 
            // serviceBindingSource
            // 
            this.serviceBindingSource.DataSource = typeof(Employees.Model.Service);
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Location = new System.Drawing.Point(14, 178);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(36, 13);
            this.lblSalary.TabIndex = 7;
            this.lblSalary.Text = "Salary";
            // 
            // nudSalary
            // 
            this.nudSalary.Location = new System.Drawing.Point(65, 178);
            this.nudSalary.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudSalary.Name = "nudSalary";
            this.nudSalary.Size = new System.Drawing.Size(206, 20);
            this.nudSalary.TabIndex = 17;
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 241);
            this.Controls.Add(this.nudSalary);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.cmbChief);
            this.Controls.Add(this.lblServiceValue);
            this.Controls.Add(this.lblChief);
            this.Controls.Add(this.lblService);
            this.Controls.Add(this.dtEmployedAt);
            this.Controls.Add(this.dtDOB);
            this.Controls.Add(this.navBar);
            this.Controls.Add(this.tsEmployee);
            this.Controls.Add(this.lblSeniority);
            this.Controls.Add(this.lblEmployedAt);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtFirstname);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmEmployee";
            this.Text = "frmEmployee";
            this.tsEmployee.ResumeLayout(false);
            this.tsEmployee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSalary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblSeniority;
        private System.Windows.Forms.Label lblEmployedAt;
        private System.Windows.Forms.ToolStrip tsEmployee;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private MyCompany.Controls.NavigationBar navBar;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbValidate;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.DateTimePicker dtDOB;
        private System.Windows.Forms.DateTimePicker dtEmployedAt;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.Label lblChief;
        private System.Windows.Forms.Label lblServiceValue;
        private System.Windows.Forms.ComboBox cmbChief;
        private System.Windows.Forms.BindingSource serviceBindingSource;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.NumericUpDown nudSalary;
    }
}