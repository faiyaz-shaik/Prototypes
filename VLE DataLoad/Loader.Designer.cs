namespace VLE_DataLoad
{
    partial class Loader
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
            this.txtRootNode = new System.Windows.Forms.TextBox();
            this.cmbVleResourceType = new System.Windows.Forms.ComboBox();
            this.butLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblResourceType = new System.Windows.Forms.Label();
            this.progressBarLoader = new System.Windows.Forms.ProgressBar();
            this.txtTotalRecords = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtRootNode
            // 
            this.txtRootNode.Location = new System.Drawing.Point(247, 106);
            this.txtRootNode.Name = "txtRootNode";
            this.txtRootNode.Size = new System.Drawing.Size(100, 22);
            this.txtRootNode.TabIndex = 0;
            this.txtRootNode.Text = "260";
            // 
            // cmbVleResourceType
            // 
            this.cmbVleResourceType.FormattingEnabled = true;
            this.cmbVleResourceType.Items.AddRange(new object[] {
            "ProjectResource",
            "CurriculumResource",
            "EventResource",
            "BlobResource",
            "ScormResource",
            "WebResource",
            "ImageResource"});
            this.cmbVleResourceType.Location = new System.Drawing.Point(247, 149);
            this.cmbVleResourceType.Name = "cmbVleResourceType";
            this.cmbVleResourceType.Size = new System.Drawing.Size(233, 24);
            this.cmbVleResourceType.TabIndex = 1;
            // 
            // butLoad
            // 
            this.butLoad.Location = new System.Drawing.Point(247, 242);
            this.butLoad.Name = "butLoad";
            this.butLoad.Size = new System.Drawing.Size(100, 61);
            this.butLoad.TabIndex = 2;
            this.butLoad.Text = "Load";
            this.butLoad.UseVisualStyleBackColor = true;
            this.butLoad.Click += new System.EventHandler(this.butLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Root Node";
            // 
            // lblResourceType
            // 
            this.lblResourceType.AutoSize = true;
            this.lblResourceType.Location = new System.Drawing.Point(121, 149);
            this.lblResourceType.Name = "lblResourceType";
            this.lblResourceType.Size = new System.Drawing.Size(105, 17);
            this.lblResourceType.TabIndex = 4;
            this.lblResourceType.Text = "Resource Type";
            // 
            // progressBarLoader
            // 
            this.progressBarLoader.Location = new System.Drawing.Point(142, 344);
            this.progressBarLoader.Name = "progressBarLoader";
            this.progressBarLoader.Size = new System.Drawing.Size(357, 23);
            this.progressBarLoader.TabIndex = 5;
            // 
            // txtTotalRecords
            // 
            this.txtTotalRecords.Location = new System.Drawing.Point(247, 197);
            this.txtTotalRecords.Name = "txtTotalRecords";
            this.txtTotalRecords.Size = new System.Drawing.Size(100, 22);
            this.txtTotalRecords.TabIndex = 6;
            this.txtTotalRecords.Text = "10";
            // 
            // Loader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 503);
            this.Controls.Add(this.txtTotalRecords);
            this.Controls.Add(this.progressBarLoader);
            this.Controls.Add(this.lblResourceType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butLoad);
            this.Controls.Add(this.cmbVleResourceType);
            this.Controls.Add(this.txtRootNode);
            this.Name = "Loader";
            this.Text = "Loader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRootNode;
        private System.Windows.Forms.ComboBox cmbVleResourceType;
        private System.Windows.Forms.Button butLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblResourceType;
        private System.Windows.Forms.ProgressBar progressBarLoader;
        private System.Windows.Forms.TextBox txtTotalRecords;
    }
}