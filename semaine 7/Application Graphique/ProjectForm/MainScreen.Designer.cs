namespace ProjectForm
{
    partial class MainScreen
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
            this.btnPeople = new System.Windows.Forms.Button();
            this.chklistPeople = new System.Windows.Forms.CheckedListBox();
            this.btnAddPeopleDelegate = new System.Windows.Forms.Button();
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDeletePeople = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPeople
            // 
            this.btnPeople.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPeople.Font = new System.Drawing.Font("Verdana", 7F);
            this.btnPeople.Location = new System.Drawing.Point(1, 2);
            this.btnPeople.Name = "btnPeople";
            this.btnPeople.Size = new System.Drawing.Size(208, 25);
            this.btnPeople.TabIndex = 0;
            this.btnPeople.Text = "Enter People";
            this.btnPeople.UseVisualStyleBackColor = true;
            // 
            // chklistPeople
            // 
            this.chklistPeople.FormattingEnabled = true;
            this.chklistPeople.Location = new System.Drawing.Point(1, 129);
            this.chklistPeople.Name = "chklistPeople";
            this.chklistPeople.Size = new System.Drawing.Size(208, 228);
            this.chklistPeople.TabIndex = 0;
            // 
            // btnAddPeopleDelegate
            // 
            this.btnAddPeopleDelegate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPeopleDelegate.Font = new System.Drawing.Font("Verdana", 7F);
            this.btnAddPeopleDelegate.Location = new System.Drawing.Point(1, 33);
            this.btnAddPeopleDelegate.Name = "btnAddPeopleDelegate";
            this.btnAddPeopleDelegate.Size = new System.Drawing.Size(208, 25);
            this.btnAddPeopleDelegate.TabIndex = 1;
            this.btnAddPeopleDelegate.Text = "Enter People Delegate";
            this.btnAddPeopleDelegate.UseVisualStyleBackColor = true;
            this.btnAddPeopleDelegate.Click += new System.EventHandler(this.btnAddPeopleDelegate_Click);
            // 
            // dgvPeople
            // 
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.Location = new System.Drawing.Point(215, 2);
            this.dgvPeople.MultiSelect = false;
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeople.Size = new System.Drawing.Size(840, 355);
            this.dgvPeople.TabIndex = 2;
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Verdana", 7F);
            this.btnUpdate.Location = new System.Drawing.Point(1, 64);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(208, 25);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update People Delegate";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDeletePeople
            // 
            this.btnDeletePeople.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePeople.Font = new System.Drawing.Font("Verdana", 7F);
            this.btnDeletePeople.Location = new System.Drawing.Point(1, 95);
            this.btnDeletePeople.Name = "btnDeletePeople";
            this.btnDeletePeople.Size = new System.Drawing.Size(208, 25);
            this.btnDeletePeople.TabIndex = 4;
            this.btnDeletePeople.Text = "Delete People";
            this.btnDeletePeople.UseVisualStyleBackColor = true;
            this.btnDeletePeople.Click += new System.EventHandler(this.btnDeletePeople_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 619);
            this.Controls.Add(this.btnDeletePeople);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dgvPeople);
            this.Controls.Add(this.btnAddPeopleDelegate);
            this.Controls.Add(this.chklistPeople);
            this.Controls.Add(this.btnPeople);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainScreen";
            this.Text = "MainScreen";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPeople;
        private System.Windows.Forms.CheckedListBox chklistPeople;
        private System.Windows.Forms.Button btnAddPeopleDelegate;
        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDeletePeople;
    }
}