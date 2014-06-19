namespace WindowsFormsApplication1
{
    partial class DrawingForm
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
            this.paneDrawing = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // paneDrawing
            // 
            this.paneDrawing.Location = new System.Drawing.Point(1, 1);
            this.paneDrawing.Name = "paneDrawing";
            this.paneDrawing.Size = new System.Drawing.Size(866, 627);
            this.paneDrawing.TabIndex = 0;
            // 
            // DrawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 629);
            this.Controls.Add(this.paneDrawing);
            this.Name = "DrawingForm";
            this.Text = "Drawing";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel paneDrawing;

    }
}

