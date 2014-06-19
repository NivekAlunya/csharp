namespace MyCompany.Controls
{
    partial class NavigationBar
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

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lnkFirst = new System.Windows.Forms.LinkLabel();
            this.lnkPrev = new System.Windows.Forms.LinkLabel();
            this.lnkNext = new System.Windows.Forms.LinkLabel();
            this.lnkLast = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.lnkLast, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lnkNext, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lnkPrev, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lnkFirst, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(130, 30);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lnkFirst
            // 
            this.lnkFirst.AutoSize = true;
            this.lnkFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lnkFirst.Location = new System.Drawing.Point(3, 0);
            this.lnkFirst.Name = "lnkFirst";
            this.lnkFirst.Size = new System.Drawing.Size(26, 30);
            this.lnkFirst.TabIndex = 0;
            this.lnkFirst.TabStop = true;
            this.lnkFirst.Text = "I<";
            this.lnkFirst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkFirst.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // lnkPrev
            // 
            this.lnkPrev.AutoSize = true;
            this.lnkPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lnkPrev.Location = new System.Drawing.Point(35, 0);
            this.lnkPrev.Name = "lnkPrev";
            this.lnkPrev.Size = new System.Drawing.Size(26, 30);
            this.lnkPrev.TabIndex = 1;
            this.lnkPrev.TabStop = true;
            this.lnkPrev.Text = "<";
            this.lnkPrev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkPrev.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // lnkNext
            // 
            this.lnkNext.AutoSize = true;
            this.lnkNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lnkNext.Location = new System.Drawing.Point(67, 0);
            this.lnkNext.Name = "lnkNext";
            this.lnkNext.Size = new System.Drawing.Size(26, 30);
            this.lnkNext.TabIndex = 2;
            this.lnkNext.TabStop = true;
            this.lnkNext.Text = ">";
            this.lnkNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkNext.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // lnkLast
            // 
            this.lnkLast.AutoSize = true;
            this.lnkLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lnkLast.Location = new System.Drawing.Point(99, 0);
            this.lnkLast.Name = "lnkLast";
            this.lnkLast.Size = new System.Drawing.Size(28, 30);
            this.lnkLast.TabIndex = 3;
            this.lnkLast.TabStop = true;
            this.lnkLast.Text = ">I";
            this.lnkLast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkLast.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // NavigationBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Source Code Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NavigationBar";
            this.Size = new System.Drawing.Size(130, 30);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.LinkLabel lnkLast;
        private System.Windows.Forms.LinkLabel lnkNext;
        private System.Windows.Forms.LinkLabel lnkPrev;
        private System.Windows.Forms.LinkLabel lnkFirst;

    }
}
