namespace SmartG.Operaciones.Emision
{
    partial class visorTextoRTF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(visorTextoRTF));
            this.txtTexto = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtTexto
            // 
            this.txtTexto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTexto.Location = new System.Drawing.Point(0, 0);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.ReadOnly = true;
            this.txtTexto.Size = new System.Drawing.Size(886, 411);
            this.txtTexto.TabIndex = 1;
            this.txtTexto.Text = "";
            // 
            // visorTextoRTF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 411);
            this.Controls.Add(this.txtTexto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "visorTextoRTF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visor Texto";
            this.Load += new System.EventHandler(this.visorTextoRTF_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtTexto;
    }
}