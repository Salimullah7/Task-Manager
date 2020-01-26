namespace Task_Manager
{
    partial class ProjectUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblProjectName = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblProjectName
            // 
            this.lblProjectName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectName.ForeColor = System.Drawing.Color.White;
            this.lblProjectName.Location = new System.Drawing.Point(30, 0);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(147, 50);
            this.lblProjectName.TabIndex = 0;
            this.lblProjectName.Text = "Project Name";
            this.lblProjectName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProjectName.Click += new System.EventHandler(this.lblProjectName_Click);
            this.lblProjectName.MouseLeave += new System.EventHandler(this.lblProjectName_MouseLeave);
            this.lblProjectName.MouseHover += new System.EventHandler(this.lblProjectName_MouseHover);
            // 
            // lblColor
            // 
            this.lblColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblColor.Location = new System.Drawing.Point(9, 15);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(25, 23);
            this.lblColor.TabIndex = 1;
            this.lblColor.Click += new System.EventHandler(this.lblProjectName_Click);
            this.lblColor.MouseLeave += new System.EventHandler(this.lblProjectName_MouseLeave);
            this.lblColor.MouseHover += new System.EventHandler(this.lblProjectName_MouseHover);
            // 
            // ProjectUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(65)))), ((int)(((byte)(114)))));
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblProjectName);
            this.Name = "ProjectUserControl";
            this.Size = new System.Drawing.Size(181, 54);
            this.Click += new System.EventHandler(this.lblProjectName_Click);
            this.MouseLeave += new System.EventHandler(this.lblProjectName_MouseLeave);
            this.MouseHover += new System.EventHandler(this.lblProjectName_MouseHover);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Label lblColor;
    }
}
