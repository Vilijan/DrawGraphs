namespace Test
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.weighted = new System.Windows.Forms.Button();
            this.unweighted = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // weighted
            // 
            this.weighted.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.weighted.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.weighted.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weighted.Location = new System.Drawing.Point(102, 71);
            this.weighted.Name = "weighted";
            this.weighted.Size = new System.Drawing.Size(297, 83);
            this.weighted.TabIndex = 1;
            this.weighted.Text = "Draw Weighted Graph";
            this.weighted.UseVisualStyleBackColor = true;
            this.weighted.Click += new System.EventHandler(this.weighted_Click);
            // 
            // unweighted
            // 
            this.unweighted.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unweighted.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.unweighted.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unweighted.Location = new System.Drawing.Point(102, 176);
            this.unweighted.Name = "unweighted";
            this.unweighted.Size = new System.Drawing.Size(297, 93);
            this.unweighted.TabIndex = 2;
            this.unweighted.Text = "Draw Unweighted Graph";
            this.unweighted.UseVisualStyleBackColor = true;
            this.unweighted.Click += new System.EventHandler(this.unweighted_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(484, 341);
            this.Controls.Add(this.unweighted);
            this.Controls.Add(this.weighted);
            this.MinimumSize = new System.Drawing.Size(429, 337);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Resize += new System.EventHandler(this.Home_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button weighted;
        private System.Windows.Forms.Button unweighted;
    }
}