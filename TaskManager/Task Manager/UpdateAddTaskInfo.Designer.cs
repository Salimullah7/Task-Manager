namespace Task_Manager
{
    partial class UpdateAddTaskInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateAddTaskInfo));
            this.pBoxAddTaskView = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cBRepeat = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cBSelectedReminders = new System.Windows.Forms.ComboBox();
            this.cBSelectReminder = new System.Windows.Forms.ComboBox();
            this.cBPriority = new System.Windows.Forms.ComboBox();
            this.cBCategory = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxAddTaskView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBoxAddTaskView
            // 
            this.pBoxAddTaskView.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pBoxAddTaskView.Image = ((System.Drawing.Image)(resources.GetObject("pBoxAddTaskView.Image")));
            this.pBoxAddTaskView.Location = new System.Drawing.Point(651, 3);
            this.pBoxAddTaskView.Name = "pBoxAddTaskView";
            this.pBoxAddTaskView.Size = new System.Drawing.Size(22, 24);
            this.pBoxAddTaskView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxAddTaskView.TabIndex = 47;
            this.pBoxAddTaskView.TabStop = false;
            this.pBoxAddTaskView.Click += new System.EventHandler(this.pBoxAddTaskView_Click);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(12, 130);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(390, 240);
            this.textBox2.TabIndex = 46;
            this.textBox2.Text = "Description..............................................................";
            // 
            // cBRepeat
            // 
            this.cBRepeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cBRepeat.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBRepeat.FormattingEnabled = true;
            this.cBRepeat.Items.AddRange(new object[] {
            "Every day",
            "Every week",
            "Every month",
            "Every year",
            "Custom"});
            this.cBRepeat.Location = new System.Drawing.Point(422, 192);
            this.cBRepeat.Name = "cBRepeat";
            this.cBRepeat.Size = new System.Drawing.Size(236, 25);
            this.cBRepeat.TabIndex = 45;
            this.cBRepeat.Text = "Repeat";
            this.cBRepeat.SelectedIndexChanged += new System.EventHandler(this.cBRepeat_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(614, 253);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(44, 25);
            this.button5.TabIndex = 44;
            this.button5.Text = "Del";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(614, 222);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(44, 25);
            this.button3.TabIndex = 43;
            this.button3.Text = "Add";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cBSelectedReminders
            // 
            this.cBSelectedReminders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cBSelectedReminders.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBSelectedReminders.FormattingEnabled = true;
            this.cBSelectedReminders.Location = new System.Drawing.Point(464, 253);
            this.cBSelectedReminders.Name = "cBSelectedReminders";
            this.cBSelectedReminders.Size = new System.Drawing.Size(144, 25);
            this.cBSelectedReminders.TabIndex = 42;
            this.cBSelectedReminders.Text = "Reminders";
            // 
            // cBSelectReminder
            // 
            this.cBSelectReminder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cBSelectReminder.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBSelectReminder.FormattingEnabled = true;
            this.cBSelectReminder.Items.AddRange(new object[] {
            "5 minutes before - NO",
            "10 minutes before - NO",
            "15 minutes before - NO",
            "30 minutes before - NO",
            "1 hour before - NO",
            "Custom"});
            this.cBSelectReminder.Location = new System.Drawing.Point(464, 222);
            this.cBSelectReminder.Name = "cBSelectReminder";
            this.cBSelectReminder.Size = new System.Drawing.Size(144, 25);
            this.cBSelectReminder.TabIndex = 41;
            this.cBSelectReminder.Text = "Select Reminder";
            this.cBSelectReminder.SelectedIndexChanged += new System.EventHandler(this.cBSelectReminder_SelectedIndexChanged);
            // 
            // cBPriority
            // 
            this.cBPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cBPriority.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBPriority.FormattingEnabled = true;
            this.cBPriority.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low"});
            this.cBPriority.Location = new System.Drawing.Point(422, 161);
            this.cBPriority.Name = "cBPriority";
            this.cBPriority.Size = new System.Drawing.Size(236, 25);
            this.cBPriority.TabIndex = 40;
            this.cBPriority.Text = "Select Priority";
            // 
            // cBCategory
            // 
            this.cBCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cBCategory.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBCategory.FormattingEnabled = true;
            this.cBCategory.Location = new System.Drawing.Point(422, 130);
            this.cBCategory.Name = "cBCategory";
            this.cBCategory.Size = new System.Drawing.Size(236, 25);
            this.cBCategory.TabIndex = 39;
            this.cBCategory.Text = "Select Category";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(464, 83);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(89, 23);
            this.dateTimePicker2.TabIndex = 38;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(562, 83);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(96, 23);
            this.dateTimePicker1.TabIndex = 37;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Salmon;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(542, 351);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 37);
            this.button1.TabIndex = 36;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 22);
            this.label1.TabIndex = 35;
            this.label1.Text = "Quick Add Task";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 65);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(390, 41);
            this.textBox1.TabIndex = 34;
            this.textBox1.Text = "Title.................................................";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pBoxAddTaskView);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(676, 47);
            this.panel1.TabIndex = 48;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // UpdateAddTaskInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(674, 412);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.cBRepeat);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cBSelectedReminders);
            this.Controls.Add(this.cBSelectReminder);
            this.Controls.Add(this.cBPriority);
            this.Controls.Add(this.cBCategory);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdateAddTaskInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateAddTaskInfo";
            this.Load += new System.EventHandler(this.UpdateAddTaskInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxAddTaskView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pBoxAddTaskView;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox cBRepeat;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cBSelectedReminders;
        private System.Windows.Forms.ComboBox cBSelectReminder;
        private System.Windows.Forms.ComboBox cBPriority;
        private System.Windows.Forms.ComboBox cBCategory;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
    }
}