
namespace BRWS6
{
    partial class frmCatalog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCatalog));
            this.lblParamTypes = new System.Windows.Forms.Label();
            this.cmbParamTypes = new System.Windows.Forms.ComboBox();
            this.lblConcepts = new System.Windows.Forms.Label();
            this.cmbConcepts = new System.Windows.Forms.ComboBox();
            this.cmbLookups = new System.Windows.Forms.ComboBox();
            this.lblLookups = new System.Windows.Forms.Label();
            this.btnLookupsByPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblParamTypes
            // 
            this.lblParamTypes.AutoSize = true;
            this.lblParamTypes.Location = new System.Drawing.Point(12, 21);
            this.lblParamTypes.Name = "lblParamTypes";
            this.lblParamTypes.Size = new System.Drawing.Size(87, 13);
            this.lblParamTypes.TabIndex = 0;
            this.lblParamTypes.Text = "Parameter Types";
            // 
            // cmbParamTypes
            // 
            this.cmbParamTypes.FormattingEnabled = true;
            this.cmbParamTypes.Location = new System.Drawing.Point(137, 18);
            this.cmbParamTypes.Name = "cmbParamTypes";
            this.cmbParamTypes.Size = new System.Drawing.Size(406, 21);
            this.cmbParamTypes.TabIndex = 1;
            // 
            // lblConcepts
            // 
            this.lblConcepts.AutoSize = true;
            this.lblConcepts.Location = new System.Drawing.Point(12, 57);
            this.lblConcepts.Name = "lblConcepts";
            this.lblConcepts.Size = new System.Drawing.Size(91, 13);
            this.lblConcepts.TabIndex = 2;
            this.lblConcepts.Text = "Catalog Concepts";
            // 
            // cmbConcepts
            // 
            this.cmbConcepts.FormattingEnabled = true;
            this.cmbConcepts.Location = new System.Drawing.Point(137, 57);
            this.cmbConcepts.Name = "cmbConcepts";
            this.cmbConcepts.Size = new System.Drawing.Size(406, 21);
            this.cmbConcepts.TabIndex = 3;
            // 
            // cmbLookups
            // 
            this.cmbLookups.FormattingEnabled = true;
            this.cmbLookups.Location = new System.Drawing.Point(137, 99);
            this.cmbLookups.Name = "cmbLookups";
            this.cmbLookups.Size = new System.Drawing.Size(406, 21);
            this.cmbLookups.TabIndex = 4;
            // 
            // lblLookups
            // 
            this.lblLookups.AutoSize = true;
            this.lblLookups.Location = new System.Drawing.Point(12, 102);
            this.lblLookups.Name = "lblLookups";
            this.lblLookups.Size = new System.Drawing.Size(87, 13);
            this.lblLookups.TabIndex = 5;
            this.lblLookups.Text = "Catalog Lookups";
            // 
            // btnLookupsByPath
            // 
            this.btnLookupsByPath.Location = new System.Drawing.Point(562, 55);
            this.btnLookupsByPath.Name = "btnLookupsByPath";
            this.btnLookupsByPath.Size = new System.Drawing.Size(122, 23);
            this.btnLookupsByPath.TabIndex = 6;
            this.btnLookupsByPath.Text = "Get Lookups by Path";
            this.btnLookupsByPath.UseVisualStyleBackColor = true;
            this.btnLookupsByPath.Click += new System.EventHandler(this.btnLookupsByPath_Click);
            // 
            // frmCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLookupsByPath);
            this.Controls.Add(this.lblLookups);
            this.Controls.Add(this.cmbLookups);
            this.Controls.Add(this.cmbConcepts);
            this.Controls.Add(this.lblConcepts);
            this.Controls.Add(this.cmbParamTypes);
            this.Controls.Add(this.lblParamTypes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCatalog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Catalog Testing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblParamTypes;
        private System.Windows.Forms.ComboBox cmbParamTypes;
        private System.Windows.Forms.Label lblConcepts;
        private System.Windows.Forms.ComboBox cmbConcepts;
        private System.Windows.Forms.ComboBox cmbLookups;
        private System.Windows.Forms.Label lblLookups;
        private System.Windows.Forms.Button btnLookupsByPath;
    }
}