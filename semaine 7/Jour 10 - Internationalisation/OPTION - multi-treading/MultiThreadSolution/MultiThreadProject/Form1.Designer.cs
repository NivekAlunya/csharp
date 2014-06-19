namespace MultiThreadProject
{
    partial class Form1
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
            this.gbLong = new System.Windows.Forms.GroupBox();
            this.lbLong = new System.Windows.Forms.Label();
            this.pbLong = new System.Windows.Forms.ProgressBar();
            this.btStartLong = new System.Windows.Forms.Button();
            this.tbTest = new System.Windows.Forms.TextBox();
            this.gbThread = new System.Windows.Forms.GroupBox();
            this.btStopThread = new System.Windows.Forms.Button();
            this.lbThread = new System.Windows.Forms.Label();
            this.pbThread = new System.Windows.Forms.ProgressBar();
            this.btStartThread = new System.Windows.Forms.Button();
            this.gbAsync = new System.Windows.Forms.GroupBox();
            this.btStopAsync = new System.Windows.Forms.Button();
            this.lbAsync = new System.Windows.Forms.Label();
            this.pbAsync = new System.Windows.Forms.ProgressBar();
            this.btStartAsync = new System.Windows.Forms.Button();
            this.gbLong.SuspendLayout();
            this.gbThread.SuspendLayout();
            this.gbAsync.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLong
            // 
            this.gbLong.Controls.Add(this.lbLong);
            this.gbLong.Controls.Add(this.pbLong);
            this.gbLong.Controls.Add(this.btStartLong);
            this.gbLong.Location = new System.Drawing.Point(18, 17);
            this.gbLong.Name = "gbLong";
            this.gbLong.Size = new System.Drawing.Size(486, 53);
            this.gbLong.TabIndex = 0;
            this.gbLong.TabStop = false;
            this.gbLong.Text = "Traitement long lancé dans le thread de l\'application";
            // 
            // lbLong
            // 
            this.lbLong.AutoSize = true;
            this.lbLong.Location = new System.Drawing.Point(337, 24);
            this.lbLong.Name = "lbLong";
            this.lbLong.Size = new System.Drawing.Size(13, 13);
            this.lbLong.TabIndex = 2;
            this.lbLong.Text = "0";
            // 
            // pbLong
            // 
            this.pbLong.Location = new System.Drawing.Point(87, 19);
            this.pbLong.Name = "pbLong";
            this.pbLong.Size = new System.Drawing.Size(244, 23);
            this.pbLong.TabIndex = 1;
            // 
            // btStartLong
            // 
            this.btStartLong.Location = new System.Drawing.Point(6, 19);
            this.btStartLong.Name = "btStartLong";
            this.btStartLong.Size = new System.Drawing.Size(75, 23);
            this.btStartLong.TabIndex = 0;
            this.btStartLong.Text = "Start";
            this.btStartLong.UseVisualStyleBackColor = true;
            this.btStartLong.Click += new System.EventHandler(this.btStartLong_Click);
            // 
            // tbTest
            // 
            this.tbTest.Location = new System.Drawing.Point(105, 238);
            this.tbTest.Name = "tbTest";
            this.tbTest.Size = new System.Drawing.Size(291, 20);
            this.tbTest.TabIndex = 1;
            // 
            // gbThread
            // 
            this.gbThread.Controls.Add(this.btStopThread);
            this.gbThread.Controls.Add(this.lbThread);
            this.gbThread.Controls.Add(this.pbThread);
            this.gbThread.Controls.Add(this.btStartThread);
            this.gbThread.Location = new System.Drawing.Point(18, 73);
            this.gbThread.Name = "gbThread";
            this.gbThread.Size = new System.Drawing.Size(486, 53);
            this.gbThread.TabIndex = 2;
            this.gbThread.TabStop = false;
            this.gbThread.Text = "Traitement long lancé dans un thread indépendant";
            // 
            // btStopThread
            // 
            this.btStopThread.Location = new System.Drawing.Point(405, 19);
            this.btStopThread.Name = "btStopThread";
            this.btStopThread.Size = new System.Drawing.Size(75, 23);
            this.btStopThread.TabIndex = 3;
            this.btStopThread.Text = "Stop";
            this.btStopThread.UseVisualStyleBackColor = true;
            this.btStopThread.Click += new System.EventHandler(this.btStopThread_Click);
            // 
            // lbThread
            // 
            this.lbThread.AutoSize = true;
            this.lbThread.Location = new System.Drawing.Point(337, 24);
            this.lbThread.Name = "lbThread";
            this.lbThread.Size = new System.Drawing.Size(13, 13);
            this.lbThread.TabIndex = 2;
            this.lbThread.Text = "0";
            // 
            // pbThread
            // 
            this.pbThread.Location = new System.Drawing.Point(87, 19);
            this.pbThread.Name = "pbThread";
            this.pbThread.Size = new System.Drawing.Size(244, 23);
            this.pbThread.TabIndex = 1;
            // 
            // btStartThread
            // 
            this.btStartThread.Location = new System.Drawing.Point(6, 19);
            this.btStartThread.Name = "btStartThread";
            this.btStartThread.Size = new System.Drawing.Size(75, 23);
            this.btStartThread.TabIndex = 0;
            this.btStartThread.Text = "Start";
            this.btStartThread.UseVisualStyleBackColor = true;
            this.btStartThread.Click += new System.EventHandler(this.btStartThread_Click);
            // 
            // gbAsync
            // 
            this.gbAsync.Controls.Add(this.btStopAsync);
            this.gbAsync.Controls.Add(this.lbAsync);
            this.gbAsync.Controls.Add(this.pbAsync);
            this.gbAsync.Controls.Add(this.btStartAsync);
            this.gbAsync.Location = new System.Drawing.Point(17, 131);
            this.gbAsync.Name = "gbAsync";
            this.gbAsync.Size = new System.Drawing.Size(486, 53);
            this.gbAsync.TabIndex = 3;
            this.gbAsync.TabStop = false;
            this.gbAsync.Text = "Traitement long lancé à partir d\'une fonction asynchrones";
            // 
            // btStopAsync
            // 
            this.btStopAsync.Location = new System.Drawing.Point(405, 19);
            this.btStopAsync.Name = "btStopAsync";
            this.btStopAsync.Size = new System.Drawing.Size(75, 23);
            this.btStopAsync.TabIndex = 3;
            this.btStopAsync.Text = "Stop";
            this.btStopAsync.UseVisualStyleBackColor = true;
            this.btStopAsync.Click += new System.EventHandler(this.btStopAsync_Click);
            // 
            // lbAsync
            // 
            this.lbAsync.AutoSize = true;
            this.lbAsync.Location = new System.Drawing.Point(337, 24);
            this.lbAsync.Name = "lbAsync";
            this.lbAsync.Size = new System.Drawing.Size(13, 13);
            this.lbAsync.TabIndex = 2;
            this.lbAsync.Text = "0";
            // 
            // pbAsync
            // 
            this.pbAsync.Location = new System.Drawing.Point(87, 19);
            this.pbAsync.Name = "pbAsync";
            this.pbAsync.Size = new System.Drawing.Size(244, 23);
            this.pbAsync.TabIndex = 1;
            // 
            // btStartAsync
            // 
            this.btStartAsync.Location = new System.Drawing.Point(6, 19);
            this.btStartAsync.Name = "btStartAsync";
            this.btStartAsync.Size = new System.Drawing.Size(75, 23);
            this.btStartAsync.TabIndex = 0;
            this.btStartAsync.Text = "Start";
            this.btStartAsync.UseVisualStyleBackColor = true;
            this.btStartAsync.Click += new System.EventHandler(this.btStartAsync_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 262);
            this.Controls.Add(this.gbAsync);
            this.Controls.Add(this.gbThread);
            this.Controls.Add(this.tbTest);
            this.Controls.Add(this.gbLong);
            this.Name = "Form1";
            this.Text = "Multi-Threading";
            this.gbLong.ResumeLayout(false);
            this.gbLong.PerformLayout();
            this.gbThread.ResumeLayout(false);
            this.gbThread.PerformLayout();
            this.gbAsync.ResumeLayout(false);
            this.gbAsync.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLong;
        private System.Windows.Forms.Label lbLong;
        private System.Windows.Forms.ProgressBar pbLong;
        private System.Windows.Forms.Button btStartLong;
        private System.Windows.Forms.TextBox tbTest;
        private System.Windows.Forms.GroupBox gbThread;
        private System.Windows.Forms.Button btStopThread;
        private System.Windows.Forms.Label lbThread;
        private System.Windows.Forms.ProgressBar pbThread;
        private System.Windows.Forms.Button btStartThread;
        private System.Windows.Forms.GroupBox gbAsync;
        private System.Windows.Forms.Button btStopAsync;
        private System.Windows.Forms.Label lbAsync;
        private System.Windows.Forms.ProgressBar pbAsync;
        private System.Windows.Forms.Button btStartAsync;
    }
}

