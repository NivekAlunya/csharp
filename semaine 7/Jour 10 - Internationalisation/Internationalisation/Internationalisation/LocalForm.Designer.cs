namespace Internationalisation
{
    partial class LocalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalForm));
            this.lbCultures = new System.Windows.Forms.Label();
            this.cbCultures = new System.Windows.Forms.ComboBox();
            this.lbCultureEnCours = new System.Windows.Forms.Label();
            this.gbExemples = new System.Windows.Forms.GroupBox();
            this.lbMonnaie = new System.Windows.Forms.Label();
            this.lbUneDate = new System.Windows.Forms.Label();
            this.btnSortir = new System.Windows.Forms.Button();
            this.gbExemples.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCultures
            // 
            resources.ApplyResources(this.lbCultures, "lbCultures");
            this.lbCultures.Name = "lbCultures";
            // 
            // cbCultures
            // 
            resources.ApplyResources(this.cbCultures, "cbCultures");
            this.cbCultures.FormattingEnabled = true;
            this.cbCultures.Name = "cbCultures";
            this.cbCultures.SelectedIndexChanged += new System.EventHandler(this.cbCultures_SelectedIndexChanged);
            // 
            // lbCultureEnCours
            // 
            resources.ApplyResources(this.lbCultureEnCours, "lbCultureEnCours");
            this.lbCultureEnCours.Name = "lbCultureEnCours";
            // 
            // gbExemples
            // 
            resources.ApplyResources(this.gbExemples, "gbExemples");
            this.gbExemples.Controls.Add(this.lbMonnaie);
            this.gbExemples.Controls.Add(this.lbUneDate);
            this.gbExemples.Name = "gbExemples";
            this.gbExemples.TabStop = false;
            // 
            // lbMonnaie
            // 
            resources.ApplyResources(this.lbMonnaie, "lbMonnaie");
            this.lbMonnaie.Name = "lbMonnaie";
            // 
            // lbUneDate
            // 
            resources.ApplyResources(this.lbUneDate, "lbUneDate");
            this.lbUneDate.Name = "lbUneDate";
            // 
            // btnSortir
            // 
            resources.ApplyResources(this.btnSortir, "btnSortir");
            this.btnSortir.Name = "btnSortir";
            this.btnSortir.UseVisualStyleBackColor = true;
            this.btnSortir.Click += new System.EventHandler(this.btnSortir_Click);
            // 
            // LocalForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSortir);
            this.Controls.Add(this.gbExemples);
            this.Controls.Add(this.lbCultureEnCours);
            this.Controls.Add(this.cbCultures);
            this.Controls.Add(this.lbCultures);
            this.Name = "LocalForm";
            this.gbExemples.ResumeLayout(false);
            this.gbExemples.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCultures;
        private System.Windows.Forms.ComboBox cbCultures;
        private System.Windows.Forms.Label lbCultureEnCours;
        private System.Windows.Forms.GroupBox gbExemples;
        private System.Windows.Forms.Label lbMonnaie;
        private System.Windows.Forms.Label lbUneDate;
        private System.Windows.Forms.Button btnSortir;
    }
}

