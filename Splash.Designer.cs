namespace SmartG
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.labelVersion = new System.Windows.Forms.Label();
            this.imgLoading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // timerMain
            // 
            this.timerMain.Interval = 2500;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // labelVersion
            // 
            this.labelVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(249)))));
            this.labelVersion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(43)))), ((int)(((byte)(124)))));
            this.labelVersion.Location = new System.Drawing.Point(477, 230);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(201, 23);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imgLoading
            // 
            this.imgLoading.BackColor = System.Drawing.Color.Transparent;
            this.imgLoading.Image = global::SmartG.Properties.Resources.waitGif_3;
            this.imgLoading.Location = new System.Drawing.Point(14, 281);
            this.imgLoading.Name = "imgLoading";
            this.imgLoading.Size = new System.Drawing.Size(72, 68);
            this.imgLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLoading.TabIndex = 1;
            this.imgLoading.TabStop = false;
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SmartG.Properties.Resources.SplashScreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(719, 388);
            this.Controls.Add(this.imgLoading);
            this.Controls.Add(this.labelVersion);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.Load += new System.EventHandler(this.Splash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.PictureBox imgLoading;
    }
}