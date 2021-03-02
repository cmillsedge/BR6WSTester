
namespace BRWS6
{
    partial class frmSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelect));
            this.btnCatalog = new System.Windows.Forms.Button();
            this.lblCatalog = new System.Windows.Forms.Label();
            this.btnAll = new System.Windows.Forms.Button();
            this.lblAll = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCatalog
            // 
            this.btnCatalog.Image = ((System.Drawing.Image)(resources.GetObject("btnCatalog.Image")));
            this.btnCatalog.Location = new System.Drawing.Point(98, 28);
            this.btnCatalog.Name = "btnCatalog";
            this.btnCatalog.Size = new System.Drawing.Size(69, 59);
            this.btnCatalog.TabIndex = 0;
            this.btnCatalog.UseVisualStyleBackColor = true;
            this.btnCatalog.Click += new System.EventHandler(this.btnCatalog_Click);
            // 
            // lblCatalog
            // 
            this.lblCatalog.AutoSize = true;
            this.lblCatalog.Location = new System.Drawing.Point(111, 12);
            this.lblCatalog.Name = "lblCatalog";
            this.lblCatalog.Size = new System.Drawing.Size(43, 13);
            this.lblCatalog.TabIndex = 1;
            this.lblCatalog.Text = "Catalog";
            // 
            // btnAll
            // 
            this.btnAll.Image = ((System.Drawing.Image)(resources.GetObject("btnAll.Image")));
            this.btnAll.Location = new System.Drawing.Point(12, 28);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(69, 59);
            this.btnAll.TabIndex = 2;
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // lblAll
            // 
            this.lblAll.AutoSize = true;
            this.lblAll.Location = new System.Drawing.Point(25, 12);
            this.lblAll.Name = "lblAll";
            this.lblAll.Size = new System.Drawing.Size(41, 13);
            this.lblAll.TabIndex = 3;
            this.lblAll.Text = "Run All";
            // 
            // frmSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 108);
            this.Controls.Add(this.lblAll);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.lblCatalog);
            this.Controls.Add(this.btnCatalog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Select Module to Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCatalog;
        private System.Windows.Forms.Label lblCatalog;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Label lblAll;
    }
}