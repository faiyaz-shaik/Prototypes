namespace VLE_DataLoad
{
    partial class Form1
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
            this.butDataLoad = new System.Windows.Forms.Button();
            this.txtRooNode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butDataLoad
            // 
            this.butDataLoad.Location = new System.Drawing.Point(109, 127);
            this.butDataLoad.Name = "butDataLoad";
            this.butDataLoad.Size = new System.Drawing.Size(145, 62);
            this.butDataLoad.TabIndex = 0;
            this.butDataLoad.Text = "Load Projects";
            this.butDataLoad.UseVisualStyleBackColor = true;
            this.butDataLoad.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtRooNode
            // 
            this.txtRooNode.Location = new System.Drawing.Point(262, 66);
            this.txtRooNode.Name = "txtRooNode";
            this.txtRooNode.Size = new System.Drawing.Size(100, 22);
            this.txtRooNode.TabIndex = 1;
            this.txtRooNode.Text = "2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Root Node";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 386);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRooNode);
            this.Controls.Add(this.butDataLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butDataLoad;
        private System.Windows.Forms.TextBox txtRooNode;
        private System.Windows.Forms.Label label1;
    }
}

