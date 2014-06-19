namespace WinFormPresentation
{
    partial class StateForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btAjouter = new System.Windows.Forms.Button();
            this.btSupprimer = new System.Windows.Forms.Button();
            this.btValider = new System.Windows.Forms.Button();
            this.btAnnuler = new System.Windows.Forms.Button();
            this.btQuitter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbData = new System.Windows.Forms.TextBox();
            this.ControleSaisie = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ControleSaisie)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btAjouter, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btSupprimer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btValider, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btAnnuler, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btQuitter, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 68);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(439, 32);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btAjouter
            // 
            this.btAjouter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btAjouter.Location = new System.Drawing.Point(3, 3);
            this.btAjouter.Name = "btAjouter";
            this.btAjouter.Size = new System.Drawing.Size(81, 26);
            this.btAjouter.TabIndex = 0;
            this.btAjouter.Text = "ajouter";
            this.btAjouter.UseVisualStyleBackColor = true;
            // 
            // btSupprimer
            // 
            this.btSupprimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btSupprimer.Location = new System.Drawing.Point(90, 3);
            this.btSupprimer.Name = "btSupprimer";
            this.btSupprimer.Size = new System.Drawing.Size(81, 26);
            this.btSupprimer.TabIndex = 1;
            this.btSupprimer.Text = "supprimer";
            this.btSupprimer.UseVisualStyleBackColor = true;
            // 
            // btValider
            // 
            this.btValider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btValider.Location = new System.Drawing.Point(177, 3);
            this.btValider.Name = "btValider";
            this.btValider.Size = new System.Drawing.Size(81, 26);
            this.btValider.TabIndex = 2;
            this.btValider.Text = "valider";
            this.btValider.UseVisualStyleBackColor = true;
            // 
            // btAnnuler
            // 
            this.btAnnuler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btAnnuler.Location = new System.Drawing.Point(264, 3);
            this.btAnnuler.Name = "btAnnuler";
            this.btAnnuler.Size = new System.Drawing.Size(81, 26);
            this.btAnnuler.TabIndex = 3;
            this.btAnnuler.Text = "annuler";
            this.btAnnuler.UseVisualStyleBackColor = true;
            // 
            // btQuitter
            // 
            this.btQuitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btQuitter.Location = new System.Drawing.Point(351, 3);
            this.btQuitter.Name = "btQuitter";
            this.btQuitter.Size = new System.Drawing.Size(85, 26);
            this.btQuitter.TabIndex = 4;
            this.btQuitter.Text = "quitter";
            this.btQuitter.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data :";
            // 
            // tbData
            // 
            this.tbData.Location = new System.Drawing.Point(124, 22);
            this.tbData.Name = "tbData";
            this.tbData.Size = new System.Drawing.Size(201, 20);
            this.tbData.TabIndex = 2;
            // 
            // ControleSaisie
            // 
            this.ControleSaisie.ContainerControl = this;
            // 
            // StateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 100);
            this.Controls.Add(this.tbData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StateForm";
            this.Text = "StateForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ControleSaisie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btAjouter;
        private System.Windows.Forms.Button btSupprimer;
        private System.Windows.Forms.Button btValider;
        private System.Windows.Forms.Button btAnnuler;
        private System.Windows.Forms.Button btQuitter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbData;
        private System.Windows.Forms.ErrorProvider ControleSaisie;
    }
}