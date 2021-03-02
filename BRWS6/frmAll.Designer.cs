
namespace BRWS6
{
    partial class frmAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAll));
            this.btnAll = new System.Windows.Forms.Button();
            this.dgvTestResults = new System.Windows.Forms.DataGridView();
            this.ModuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MethodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Outcome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtbProgress = new System.Windows.Forms.RichTextBox();
            this.lblResults = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestResults)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(13, 13);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 0;
            this.btnAll.Text = "RunAll";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // dgvTestResults
            // 
            this.dgvTestResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ModuleName,
            this.MethodName,
            this.Outcome});
            this.dgvTestResults.Location = new System.Drawing.Point(13, 60);
            this.dgvTestResults.Name = "dgvTestResults";
            this.dgvTestResults.Size = new System.Drawing.Size(839, 462);
            this.dgvTestResults.TabIndex = 1;
            // 
            // ModuleName
            // 
            this.ModuleName.HeaderText = "Module Name";
            this.ModuleName.Name = "ModuleName";
            // 
            // MethodName
            // 
            this.MethodName.HeaderText = "Method Name";
            this.MethodName.Name = "MethodName";
            this.MethodName.Width = 250;
            // 
            // Outcome
            // 
            this.Outcome.HeaderText = "Outcome";
            this.Outcome.Name = "Outcome";
            this.Outcome.Width = 400;
            // 
            // rtbProgress
            // 
            this.rtbProgress.Location = new System.Drawing.Point(858, 60);
            this.rtbProgress.Name = "rtbProgress";
            this.rtbProgress.Size = new System.Drawing.Size(265, 462);
            this.rtbProgress.TabIndex = 2;
            this.rtbProgress.Text = "";
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(12, 44);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(66, 13);
            this.lblResults.TabIndex = 3;
            this.lblResults.Text = "Test Results";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(855, 44);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(72, 13);
            this.lblProgress.TabIndex = 4;
            this.lblProgress.Text = "Test Progress";
            // 
            // frmAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 536);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.rtbProgress);
            this.Controls.Add(this.dgvTestResults);
            this.Controls.Add(this.btnAll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Run It All";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.DataGridView dgvTestResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MethodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Outcome;
        private System.Windows.Forms.RichTextBox rtbProgress;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Label lblProgress;
    }
}