namespace ExempleBase
{
    partial class EcranPrincipal
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
            this.btnQuitter = new System.Windows.Forms.Button();
            this.rbNoir = new System.Windows.Forms.RadioButton();
            this.rbRouge = new System.Windows.Forms.RadioButton();
            this.ckGras = new System.Windows.Forms.CheckBox();
            this.ckItalique = new System.Windows.Forms.CheckBox();
            this.ckSouligne = new System.Windows.Forms.CheckBox();
            this.rbGauche = new System.Windows.Forms.RadioButton();
            this.rbMilieu = new System.Windows.Forms.RadioButton();
            this.rbDroite = new System.Windows.Forms.RadioButton();
            this.gbCouleur = new System.Windows.Forms.GroupBox();
            this.gbAlignement = new System.Windows.Forms.GroupBox();
            this.gbStyle = new System.Windows.Forms.GroupBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblMdp = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtprenom = new System.Windows.Forms.TextBox();
            this.txtMdp = new System.Windows.Forms.TextBox();
            this.lblCommentaires = new System.Windows.Forms.Label();
            this.gbClientlu = new System.Windows.Forms.GroupBox();
            this.gbClients = new System.Windows.Forms.GroupBox();
            this.gbCouleur.SuspendLayout();
            this.gbAlignement.SuspendLayout();
            this.gbStyle.SuspendLayout();
            this.gbClientlu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQuitter
            // 
            this.btnQuitter.BackColor = System.Drawing.Color.Gainsboro;
            this.btnQuitter.Location = new System.Drawing.Point(490, 521);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(75, 30);
            this.btnQuitter.TabIndex = 0;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // rbNoir
            // 
            this.rbNoir.AutoSize = true;
            this.rbNoir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNoir.Location = new System.Drawing.Point(22, 19);
            this.rbNoir.Name = "rbNoir";
            this.rbNoir.Size = new System.Drawing.Size(48, 17);
            this.rbNoir.TabIndex = 1;
            this.rbNoir.TabStop = true;
            this.rbNoir.Text = "Noir";
            this.rbNoir.UseVisualStyleBackColor = true;
            this.rbNoir.CheckedChanged += new System.EventHandler(this.rbCouleur_CheckedChanged);
            // 
            // rbRouge
            // 
            this.rbRouge.AutoSize = true;
            this.rbRouge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRouge.ForeColor = System.Drawing.Color.Red;
            this.rbRouge.Location = new System.Drawing.Point(22, 56);
            this.rbRouge.Name = "rbRouge";
            this.rbRouge.Size = new System.Drawing.Size(62, 17);
            this.rbRouge.TabIndex = 2;
            this.rbRouge.TabStop = true;
            this.rbRouge.Text = "Rouge";
            this.rbRouge.UseVisualStyleBackColor = true;
            this.rbRouge.CheckedChanged += new System.EventHandler(this.rbCouleur_CheckedChanged);
            // 
            // ckGras
            // 
            this.ckGras.AutoSize = true;
            this.ckGras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckGras.Location = new System.Drawing.Point(25, 27);
            this.ckGras.Name = "ckGras";
            this.ckGras.Size = new System.Drawing.Size(52, 17);
            this.ckGras.TabIndex = 3;
            this.ckGras.Text = "Gras";
            this.ckGras.UseVisualStyleBackColor = true;
            // 
            // ckItalique
            // 
            this.ckItalique.AutoSize = true;
            this.ckItalique.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckItalique.Location = new System.Drawing.Point(25, 64);
            this.ckItalique.Name = "ckItalique";
            this.ckItalique.Size = new System.Drawing.Size(60, 17);
            this.ckItalique.TabIndex = 4;
            this.ckItalique.Text = "Italique";
            this.ckItalique.UseVisualStyleBackColor = true;
            // 
            // ckSouligne
            // 
            this.ckSouligne.AutoSize = true;
            this.ckSouligne.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSouligne.Location = new System.Drawing.Point(25, 103);
            this.ckSouligne.Name = "ckSouligne";
            this.ckSouligne.Size = new System.Drawing.Size(67, 17);
            this.ckSouligne.TabIndex = 5;
            this.ckSouligne.Text = "Souligné";
            this.ckSouligne.UseVisualStyleBackColor = true;
            // 
            // rbGauche
            // 
            this.rbGauche.AutoSize = true;
            this.rbGauche.Location = new System.Drawing.Point(23, 17);
            this.rbGauche.Name = "rbGauche";
            this.rbGauche.Size = new System.Drawing.Size(71, 17);
            this.rbGauche.TabIndex = 6;
            this.rbGauche.TabStop = true;
            this.rbGauche.Text = "A gauche";
            this.rbGauche.UseVisualStyleBackColor = true;
            // 
            // rbMilieu
            // 
            this.rbMilieu.AutoSize = true;
            this.rbMilieu.Location = new System.Drawing.Point(41, 53);
            this.rbMilieu.Name = "rbMilieu";
            this.rbMilieu.Size = new System.Drawing.Size(67, 17);
            this.rbMilieu.TabIndex = 7;
            this.rbMilieu.TabStop = true;
            this.rbMilieu.Text = "Au milieu";
            this.rbMilieu.UseVisualStyleBackColor = true;
            // 
            // rbDroite
            // 
            this.rbDroite.AutoSize = true;
            this.rbDroite.Location = new System.Drawing.Point(60, 93);
            this.rbDroite.Name = "rbDroite";
            this.rbDroite.Size = new System.Drawing.Size(61, 17);
            this.rbDroite.TabIndex = 8;
            this.rbDroite.TabStop = true;
            this.rbDroite.Text = "A droite";
            this.rbDroite.UseVisualStyleBackColor = true;
            // 
            // gbCouleur
            // 
            this.gbCouleur.Controls.Add(this.rbNoir);
            this.gbCouleur.Controls.Add(this.rbRouge);
            this.gbCouleur.Location = new System.Drawing.Point(136, 170);
            this.gbCouleur.Name = "gbCouleur";
            this.gbCouleur.Size = new System.Drawing.Size(113, 91);
            this.gbCouleur.TabIndex = 9;
            this.gbCouleur.TabStop = false;
            this.gbCouleur.Text = "Couleurs";
            // 
            // gbAlignement
            // 
            this.gbAlignement.Controls.Add(this.rbDroite);
            this.gbAlignement.Controls.Add(this.rbGauche);
            this.gbAlignement.Controls.Add(this.rbMilieu);
            this.gbAlignement.Location = new System.Drawing.Point(434, 170);
            this.gbAlignement.Name = "gbAlignement";
            this.gbAlignement.Size = new System.Drawing.Size(142, 120);
            this.gbAlignement.TabIndex = 10;
            this.gbAlignement.TabStop = false;
            this.gbAlignement.Text = "Alignement";
            // 
            // gbStyle
            // 
            this.gbStyle.Controls.Add(this.ckSouligne);
            this.gbStyle.Controls.Add(this.ckGras);
            this.gbStyle.Controls.Add(this.ckItalique);
            this.gbStyle.Location = new System.Drawing.Point(274, 170);
            this.gbStyle.Name = "gbStyle";
            this.gbStyle.Size = new System.Drawing.Size(137, 132);
            this.gbStyle.TabIndex = 11;
            this.gbStyle.TabStop = false;
            this.gbStyle.Text = "Style";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(19, 28);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(38, 13);
            this.lblNom.TabIndex = 12;
            this.lblNom.Text = "Nom : ";
            // 
            // lblMdp
            // 
            this.lblMdp.AutoSize = true;
            this.lblMdp.Location = new System.Drawing.Point(19, 108);
            this.lblMdp.Name = "lblMdp";
            this.lblMdp.Size = new System.Drawing.Size(77, 13);
            this.lblMdp.TabIndex = 13;
            this.lblMdp.Text = "Mot de passe :";
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Location = new System.Drawing.Point(19, 68);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(52, 13);
            this.lblPrenom.TabIndex = 14;
            this.lblPrenom.Text = "Prenom : ";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(109, 28);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(160, 20);
            this.txtNom.TabIndex = 15;
            // 
            // txtprenom
            // 
            this.txtprenom.Location = new System.Drawing.Point(109, 68);
            this.txtprenom.Name = "txtprenom";
            this.txtprenom.Size = new System.Drawing.Size(160, 20);
            this.txtprenom.TabIndex = 16;
            // 
            // txtMdp
            // 
            this.txtMdp.Location = new System.Drawing.Point(109, 105);
            this.txtMdp.Name = "txtMdp";
            this.txtMdp.Size = new System.Drawing.Size(85, 20);
            this.txtMdp.TabIndex = 17;
            // 
            // lblCommentaires
            // 
            this.lblCommentaires.AutoSize = true;
            this.lblCommentaires.Location = new System.Drawing.Point(332, 28);
            this.lblCommentaires.Name = "lblCommentaires";
            this.lblCommentaires.Size = new System.Drawing.Size(79, 13);
            this.lblCommentaires.TabIndex = 18;
            this.lblCommentaires.Text = "Commentaires :";
            // 
            // gbClientlu
            // 
            this.gbClientlu.Controls.Add(this.lblNom);
            this.gbClientlu.Controls.Add(this.gbStyle);
            this.gbClientlu.Controls.Add(this.gbAlignement);
            this.gbClientlu.Controls.Add(this.lblCommentaires);
            this.gbClientlu.Controls.Add(this.gbCouleur);
            this.gbClientlu.Controls.Add(this.lblMdp);
            this.gbClientlu.Controls.Add(this.txtMdp);
            this.gbClientlu.Controls.Add(this.lblPrenom);
            this.gbClientlu.Controls.Add(this.txtprenom);
            this.gbClientlu.Controls.Add(this.txtNom);
            this.gbClientlu.Location = new System.Drawing.Point(38, 167);
            this.gbClientlu.Name = "gbClientlu";
            this.gbClientlu.Size = new System.Drawing.Size(584, 335);
            this.gbClientlu.TabIndex = 19;
            this.gbClientlu.TabStop = false;
            this.gbClientlu.Text = "Client sélectionné :";
            // 
            // gbClients
            // 
            this.gbClients.Location = new System.Drawing.Point(38, 13);
            this.gbClients.Name = "gbClients";
            this.gbClients.Size = new System.Drawing.Size(584, 148);
            this.gbClients.TabIndex = 20;
            this.gbClients.TabStop = false;
            this.gbClients.Text = "Liste des clients :";
            // 
            // EcranPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(687, 563);
            this.Controls.Add(this.gbClients);
            this.Controls.Add(this.gbClientlu);
            this.Controls.Add(this.btnQuitter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EcranPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "composants courants";
            this.Load += new System.EventHandler(this.EcranPrincipal_Load);
            this.gbCouleur.ResumeLayout(false);
            this.gbCouleur.PerformLayout();
            this.gbAlignement.ResumeLayout(false);
            this.gbAlignement.PerformLayout();
            this.gbStyle.ResumeLayout(false);
            this.gbStyle.PerformLayout();
            this.gbClientlu.ResumeLayout(false);
            this.gbClientlu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.RadioButton rbNoir;
        private System.Windows.Forms.RadioButton rbRouge;
        private System.Windows.Forms.CheckBox ckGras;
        private System.Windows.Forms.CheckBox ckItalique;
        private System.Windows.Forms.CheckBox ckSouligne;
        private System.Windows.Forms.RadioButton rbGauche;
        private System.Windows.Forms.RadioButton rbMilieu;
        private System.Windows.Forms.RadioButton rbDroite;
        private System.Windows.Forms.GroupBox gbCouleur;
        private System.Windows.Forms.GroupBox gbAlignement;
        private System.Windows.Forms.GroupBox gbStyle;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblMdp;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtprenom;
        private System.Windows.Forms.TextBox txtMdp;
        private System.Windows.Forms.Label lblCommentaires;
        private System.Windows.Forms.GroupBox gbClientlu;
        private System.Windows.Forms.GroupBox gbClients;
    }
}

