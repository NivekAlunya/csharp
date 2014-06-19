namespace DockingControl
{
    partial class frmMain
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
            this.grpChoice = new System.Windows.Forms.GroupBox();
            this.rdYesNoCancel = new System.Windows.Forms.RadioButton();
            this.rdYesNo = new System.Windows.Forms.RadioButton();
            this.rdTryCancel = new System.Windows.Forms.RadioButton();
            this.rdOKCancel = new System.Windows.Forms.RadioButton();
            this.rdOK = new System.Windows.Forms.RadioButton();
            this.grpButton = new System.Windows.Forms.GroupBox();
            this.rdButton2 = new System.Windows.Forms.RadioButton();
            this.rdButton3 = new System.Windows.Forms.RadioButton();
            this.rdButton1 = new System.Windows.Forms.RadioButton();
            this.grpIcons = new System.Windows.Forms.GroupBox();
            this.rdAlert = new System.Windows.Forms.RadioButton();
            this.rdQuestion = new System.Windows.Forms.RadioButton();
            this.rdInformation = new System.Windows.Forms.RadioButton();
            this.rdError = new System.Windows.Forms.RadioButton();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnDialog = new System.Windows.Forms.Button();
            this.grpChoice.SuspendLayout();
            this.grpButton.SuspendLayout();
            this.grpIcons.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpChoice
            // 
            this.grpChoice.Controls.Add(this.rdYesNoCancel);
            this.grpChoice.Controls.Add(this.rdYesNo);
            this.grpChoice.Controls.Add(this.rdTryCancel);
            this.grpChoice.Controls.Add(this.rdOKCancel);
            this.grpChoice.Controls.Add(this.rdOK);
            this.grpChoice.Location = new System.Drawing.Point(0, 28);
            this.grpChoice.Name = "grpChoice";
            this.grpChoice.Size = new System.Drawing.Size(200, 135);
            this.grpChoice.TabIndex = 0;
            this.grpChoice.TabStop = false;
            this.grpChoice.Text = "Button Choice";
            // 
            // rdYesNoCancel
            // 
            this.rdYesNoCancel.AutoSize = true;
            this.rdYesNoCancel.Location = new System.Drawing.Point(6, 111);
            this.rdYesNoCancel.Name = "rdYesNoCancel";
            this.rdYesNoCancel.Size = new System.Drawing.Size(100, 17);
            this.rdYesNoCancel.TabIndex = 8;
            this.rdYesNoCancel.TabStop = true;
            this.rdYesNoCancel.Text = "Yes/No/Cancel";
            this.rdYesNoCancel.UseVisualStyleBackColor = true;
            // 
            // rdYesNo
            // 
            this.rdYesNo.AutoSize = true;
            this.rdYesNo.Location = new System.Drawing.Point(6, 88);
            this.rdYesNo.Name = "rdYesNo";
            this.rdYesNo.Size = new System.Drawing.Size(62, 17);
            this.rdYesNo.TabIndex = 7;
            this.rdYesNo.TabStop = true;
            this.rdYesNo.Text = "Yes/No";
            this.rdYesNo.UseVisualStyleBackColor = true;
            // 
            // rdTryCancel
            // 
            this.rdTryCancel.AutoSize = true;
            this.rdTryCancel.Location = new System.Drawing.Point(6, 65);
            this.rdTryCancel.Name = "rdTryCancel";
            this.rdTryCancel.Size = new System.Drawing.Size(78, 17);
            this.rdTryCancel.TabIndex = 6;
            this.rdTryCancel.TabStop = true;
            this.rdTryCancel.Text = "Try/Cancel";
            this.rdTryCancel.UseVisualStyleBackColor = true;
            // 
            // rdOKCancel
            // 
            this.rdOKCancel.AutoSize = true;
            this.rdOKCancel.Location = new System.Drawing.Point(6, 42);
            this.rdOKCancel.Name = "rdOKCancel";
            this.rdOKCancel.Size = new System.Drawing.Size(78, 17);
            this.rdOKCancel.TabIndex = 5;
            this.rdOKCancel.TabStop = true;
            this.rdOKCancel.Text = "OK/Cancel";
            this.rdOKCancel.UseVisualStyleBackColor = true;
            // 
            // rdOK
            // 
            this.rdOK.AutoSize = true;
            this.rdOK.Location = new System.Drawing.Point(6, 19);
            this.rdOK.Name = "rdOK";
            this.rdOK.Size = new System.Drawing.Size(40, 17);
            this.rdOK.TabIndex = 4;
            this.rdOK.TabStop = true;
            this.rdOK.Text = "OK";
            this.rdOK.UseVisualStyleBackColor = true;
            // 
            // grpButton
            // 
            this.grpButton.Controls.Add(this.rdButton2);
            this.grpButton.Controls.Add(this.rdButton3);
            this.grpButton.Controls.Add(this.rdButton1);
            this.grpButton.Location = new System.Drawing.Point(412, 28);
            this.grpButton.Name = "grpButton";
            this.grpButton.Size = new System.Drawing.Size(200, 100);
            this.grpButton.TabIndex = 2;
            this.grpButton.TabStop = false;
            this.grpButton.Text = "Buttons";
            // 
            // rdButton2
            // 
            this.rdButton2.AutoSize = true;
            this.rdButton2.Location = new System.Drawing.Point(6, 42);
            this.rdButton2.Name = "rdButton2";
            this.rdButton2.Size = new System.Drawing.Size(14, 13);
            this.rdButton2.TabIndex = 14;
            this.rdButton2.TabStop = true;
            this.rdButton2.UseVisualStyleBackColor = true;
            // 
            // rdButton3
            // 
            this.rdButton3.AutoSize = true;
            this.rdButton3.Location = new System.Drawing.Point(6, 65);
            this.rdButton3.Name = "rdButton3";
            this.rdButton3.Size = new System.Drawing.Size(14, 13);
            this.rdButton3.TabIndex = 13;
            this.rdButton3.TabStop = true;
            this.rdButton3.UseVisualStyleBackColor = true;
            // 
            // rdButton1
            // 
            this.rdButton1.AutoSize = true;
            this.rdButton1.Location = new System.Drawing.Point(6, 19);
            this.rdButton1.Name = "rdButton1";
            this.rdButton1.Size = new System.Drawing.Size(14, 13);
            this.rdButton1.TabIndex = 12;
            this.rdButton1.TabStop = true;
            this.rdButton1.UseVisualStyleBackColor = true;
            // 
            // grpIcons
            // 
            this.grpIcons.Controls.Add(this.rdAlert);
            this.grpIcons.Controls.Add(this.rdQuestion);
            this.grpIcons.Controls.Add(this.rdInformation);
            this.grpIcons.Controls.Add(this.rdError);
            this.grpIcons.Location = new System.Drawing.Point(206, 28);
            this.grpIcons.Name = "grpIcons";
            this.grpIcons.Size = new System.Drawing.Size(200, 116);
            this.grpIcons.TabIndex = 3;
            this.grpIcons.TabStop = false;
            this.grpIcons.Text = "Icons";
            // 
            // rdAlert
            // 
            this.rdAlert.AutoSize = true;
            this.rdAlert.Location = new System.Drawing.Point(6, 88);
            this.rdAlert.Name = "rdAlert";
            this.rdAlert.Size = new System.Drawing.Size(46, 17);
            this.rdAlert.TabIndex = 12;
            this.rdAlert.TabStop = true;
            this.rdAlert.Text = "Alert";
            this.rdAlert.UseVisualStyleBackColor = true;
            // 
            // rdQuestion
            // 
            this.rdQuestion.AutoSize = true;
            this.rdQuestion.Location = new System.Drawing.Point(6, 65);
            this.rdQuestion.Name = "rdQuestion";
            this.rdQuestion.Size = new System.Drawing.Size(67, 17);
            this.rdQuestion.TabIndex = 11;
            this.rdQuestion.TabStop = true;
            this.rdQuestion.Text = "Question";
            this.rdQuestion.UseVisualStyleBackColor = true;
            // 
            // rdInformation
            // 
            this.rdInformation.AutoSize = true;
            this.rdInformation.Location = new System.Drawing.Point(6, 19);
            this.rdInformation.Name = "rdInformation";
            this.rdInformation.Size = new System.Drawing.Size(77, 17);
            this.rdInformation.TabIndex = 10;
            this.rdInformation.TabStop = true;
            this.rdInformation.Text = "Information";
            this.rdInformation.UseVisualStyleBackColor = true;
            // 
            // rdError
            // 
            this.rdError.AutoSize = true;
            this.rdError.Location = new System.Drawing.Point(6, 42);
            this.rdError.Name = "rdError";
            this.rdError.Size = new System.Drawing.Size(47, 17);
            this.rdError.TabIndex = 9;
            this.rdError.TabStop = true;
            this.rdError.Text = "Error";
            this.rdError.UseVisualStyleBackColor = true;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(0, 4);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(200, 20);
            this.txtMessage.TabIndex = 4;
            // 
            // btnDialog
            // 
            this.btnDialog.Location = new System.Drawing.Point(204, 1);
            this.btnDialog.Name = "btnDialog";
            this.btnDialog.Size = new System.Drawing.Size(75, 23);
            this.btnDialog.TabIndex = 5;
            this.btnDialog.Text = "Show dialog";
            this.btnDialog.UseVisualStyleBackColor = true;
            this.btnDialog.Click += new System.EventHandler(this.btnDialog_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 167);
            this.Controls.Add(this.btnDialog);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.grpIcons);
            this.Controls.Add(this.grpButton);
            this.Controls.Add(this.grpChoice);
            this.Name = "frmMain";
            this.grpChoice.ResumeLayout(false);
            this.grpChoice.PerformLayout();
            this.grpButton.ResumeLayout(false);
            this.grpButton.PerformLayout();
            this.grpIcons.ResumeLayout(false);
            this.grpIcons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpChoice;
        private System.Windows.Forms.GroupBox grpButton;
        private System.Windows.Forms.GroupBox grpIcons;
        private System.Windows.Forms.RadioButton rdError;
        private System.Windows.Forms.RadioButton rdYesNoCancel;
        private System.Windows.Forms.RadioButton rdYesNo;
        private System.Windows.Forms.RadioButton rdTryCancel;
        private System.Windows.Forms.RadioButton rdOKCancel;
        private System.Windows.Forms.RadioButton rdOK;
        private System.Windows.Forms.RadioButton rdButton2;
        private System.Windows.Forms.RadioButton rdButton3;
        private System.Windows.Forms.RadioButton rdButton1;
        private System.Windows.Forms.RadioButton rdAlert;
        private System.Windows.Forms.RadioButton rdQuestion;
        private System.Windows.Forms.RadioButton rdInformation;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnDialog;

    }
}

