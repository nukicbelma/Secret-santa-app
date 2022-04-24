
namespace secretsantaapp.WinUI
{
    partial class frmHomePageAdmin
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
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnUpravljanje = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(80, 201);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(210, 41);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnUpravljanje
            // 
            this.btnUpravljanje.Location = new System.Drawing.Point(80, 107);
            this.btnUpravljanje.Name = "btnUpravljanje";
            this.btnUpravljanje.Size = new System.Drawing.Size(210, 41);
            this.btnUpravljanje.TabIndex = 1;
            this.btnUpravljanje.Text = "Upravljanjem secret santom";
            this.btnUpravljanje.UseVisualStyleBackColor = true;
            this.btnUpravljanje.Click += new System.EventHandler(this.btnUpravljanje_Click);
            // 
            // frmHomePageAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 292);
            this.Controls.Add(this.btnUpravljanje);
            this.Controls.Add(this.btnLogout);
            this.Name = "frmHomePageAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome::admin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnUpravljanje;
    }
}