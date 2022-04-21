﻿
namespace secretsantaapp.WinUI
{
    partial class frmSecretSantaAdmin
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvGiftPairs = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatePublished = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiftPairs)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvGiftPairs);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 186);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista parova";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dgvGiftPairs
            // 
            this.dgvGiftPairs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiftPairs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.FromUser,
            this.ToUser,
            this.DatePublished});
            this.dgvGiftPairs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGiftPairs.Location = new System.Drawing.Point(3, 19);
            this.dgvGiftPairs.Name = "dgvGiftPairs";
            this.dgvGiftPairs.RowTemplate.Height = 25;
            this.dgvGiftPairs.Size = new System.Drawing.Size(508, 164);
            this.dgvGiftPairs.TabIndex = 0;
            this.dgvGiftPairs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "GiftId";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // FromUser
            // 
            this.FromUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FromUser.DataPropertyName = "FromUsers";
            this.FromUser.HeaderText = "FromUser";
            this.FromUser.Name = "FromUser";
            // 
            // ToUser
            // 
            this.ToUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ToUser.DataPropertyName = "ToUsers";
            this.ToUser.HeaderText = "ToUser";
            this.ToUser.Name = "ToUser";
            // 
            // DatePublished
            // 
            this.DatePublished.DataPropertyName = "DatePublished";
            this.DatePublished.HeaderText = "DatePublished";
            this.DatePublished.Name = "DatePublished";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "GiftId";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(370, 238);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(153, 23);
            this.btnDodaj.TabIndex = 1;
            this.btnDodaj.Text = "Dodaj par @secretsanta";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // frmSecretSantaAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 269);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSecretSantaAdmin";
            this.Text = "Admin:: Secret santa app";
            this.Load += new System.EventHandler(this.frmSecretSantaAdmin_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiftPairs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvGiftPairs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatePublished;
        private System.Windows.Forms.Button btnDodaj;
    }
}