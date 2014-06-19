namespace Employees.Windows
{
    partial class frmService
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.lstService = new System.Windows.Forms.ListBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.grpAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(61, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "A";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(90, 8);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(23, 23);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "D";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(148, 8);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(23, 23);
            this.btnValidate.TabIndex = 2;
            this.btnValidate.Text = "V";
            this.btnValidate.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(32, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(23, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(3, 8);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(23, 23);
            this.btnPrevious.TabIndex = 4;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(177, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(23, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "C";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(235, 8);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(23, 23);
            this.btnQuit.TabIndex = 6;
            this.btnQuit.Text = "Q";
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // lstService
            // 
            this.lstService.FormattingEnabled = true;
            this.lstService.Location = new System.Drawing.Point(0, 0);
            this.lstService.Name = "lstService";
            this.lstService.Size = new System.Drawing.Size(258, 225);
            this.lstService.TabIndex = 7;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(0, 230);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(92, 20);
            this.txtCode.TabIndex = 8;
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(98, 230);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(136, 20);
            this.txtLabel.TabIndex = 9;
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.btnQuit);
            this.grpAction.Controls.Add(this.btnAdd);
            this.grpAction.Controls.Add(this.btnDel);
            this.grpAction.Controls.Add(this.btnValidate);
            this.grpAction.Controls.Add(this.btnNext);
            this.grpAction.Controls.Add(this.btnCancel);
            this.grpAction.Controls.Add(this.btnPrevious);
            this.grpAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpAction.Location = new System.Drawing.Point(-1, 252);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(261, 34);
            this.grpAction.TabIndex = 10;
            this.grpAction.TabStop = false;
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Location = new System.Drawing.Point(2, 292);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.Size = new System.Drawing.Size(256, 234);
            this.dgvEmployees.TabIndex = 11;
            // 
            // frmService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 529);
            this.Controls.Add(this.dgvEmployees);
            this.Controls.Add(this.grpAction);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lstService);
            this.Name = "frmService";
            this.Text = "Services";
            this.grpAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.ListBox lstService;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.DataGridView dgvEmployees;
    }
}

