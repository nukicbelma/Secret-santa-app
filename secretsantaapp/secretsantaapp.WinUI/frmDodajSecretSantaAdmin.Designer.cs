
namespace secretsantaapp.WinUI
{
    partial class frmDodajSecretSantaAdmin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDavaoci = new System.Windows.Forms.ComboBox();
            this.cmbPrimaoci = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "From user (davalac):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "To User (primalac):";
            // 
            // cmbDavaoci
            // 
            this.cmbDavaoci.FormattingEnabled = true;
            this.cmbDavaoci.Location = new System.Drawing.Point(172, 46);
            this.cmbDavaoci.Name = "cmbDavaoci";
            this.cmbDavaoci.Size = new System.Drawing.Size(121, 23);
            this.cmbDavaoci.TabIndex = 2;
            this.cmbDavaoci.SelectedIndexChanged += new System.EventHandler(this.cmbDavaoci_SelectedIndexChanged);
            // 
            // cmbPrimaoci
            // 
            this.cmbPrimaoci.FormattingEnabled = true;
            this.cmbPrimaoci.Location = new System.Drawing.Point(172, 95);
            this.cmbPrimaoci.Name = "cmbPrimaoci";
            this.cmbPrimaoci.Size = new System.Drawing.Size(121, 23);
            this.cmbPrimaoci.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(210, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Pohrani";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmDodajSecretSantaAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 204);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbPrimaoci);
            this.Controls.Add(this.cmbDavaoci);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDodajSecretSantaAdmin";
            this.Text = "Dodaj par @secretsanta";
            this.Load += new System.EventHandler(this.frmDodajSecretSantaAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDavaoci;
        private System.Windows.Forms.ComboBox cmbPrimaoci;
        private System.Windows.Forms.Button button1;
    }
}