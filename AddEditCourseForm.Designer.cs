namespace CourseDistributor
{
    partial class AddEditCourseForm
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
            this.submitButton = new System.Windows.Forms.Button();
            this.formLabel = new System.Windows.Forms.Label();
            this.courseIDLabel = new System.Windows.Forms.Label();
            this.courseID = new System.Windows.Forms.TextBox();
            this.courseName = new System.Windows.Forms.TextBox();
            this.courseNameLabel = new System.Windows.Forms.Label();
            this.creditHoursLabel = new System.Windows.Forms.Label();
            this.creditHours = new System.Windows.Forms.TextBox();
            this.semestersOfferedLabel = new System.Windows.Forms.Label();
            this.fallCheckBox = new System.Windows.Forms.CheckBox();
            this.springCheckBox = new System.Windows.Forms.CheckBox();
            this.prereqListBox = new System.Windows.Forms.CheckedListBox();
            this.prereqLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(158, 357);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 0;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // formLabel
            // 
            this.formLabel.AutoSize = true;
            this.formLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formLabel.Location = new System.Drawing.Point(126, 23);
            this.formLabel.Name = "formLabel";
            this.formLabel.Size = new System.Drawing.Size(148, 24);
            this.formLabel.TabIndex = 1;
            this.formLabel.Text = "Add/Edit Course";
            // 
            // courseIDLabel
            // 
            this.courseIDLabel.AutoSize = true;
            this.courseIDLabel.Location = new System.Drawing.Point(43, 70);
            this.courseIDLabel.Name = "courseIDLabel";
            this.courseIDLabel.Size = new System.Drawing.Size(57, 13);
            this.courseIDLabel.TabIndex = 2;
            this.courseIDLabel.Text = "Course ID:";
            // 
            // courseID
            // 
            this.courseID.Location = new System.Drawing.Point(158, 67);
            this.courseID.Name = "courseID";
            this.courseID.Size = new System.Drawing.Size(100, 20);
            this.courseID.TabIndex = 3;
            // 
            // courseName
            // 
            this.courseName.Location = new System.Drawing.Point(158, 113);
            this.courseName.Name = "courseName";
            this.courseName.Size = new System.Drawing.Size(189, 20);
            this.courseName.TabIndex = 4;
            // 
            // courseNameLabel
            // 
            this.courseNameLabel.AutoSize = true;
            this.courseNameLabel.Location = new System.Drawing.Point(43, 116);
            this.courseNameLabel.Name = "courseNameLabel";
            this.courseNameLabel.Size = new System.Drawing.Size(74, 13);
            this.courseNameLabel.TabIndex = 5;
            this.courseNameLabel.Text = "Course Name:";
            // 
            // creditHoursLabel
            // 
            this.creditHoursLabel.AutoSize = true;
            this.creditHoursLabel.Location = new System.Drawing.Point(43, 156);
            this.creditHoursLabel.Name = "creditHoursLabel";
            this.creditHoursLabel.Size = new System.Drawing.Size(68, 13);
            this.creditHoursLabel.TabIndex = 6;
            this.creditHoursLabel.Text = "Credit Hours:";
            // 
            // creditHours
            // 
            this.creditHours.Location = new System.Drawing.Point(158, 153);
            this.creditHours.MaxLength = 1;
            this.creditHours.Name = "creditHours";
            this.creditHours.Size = new System.Drawing.Size(38, 20);
            this.creditHours.TabIndex = 7;
            // 
            // semestersOfferedLabel
            // 
            this.semestersOfferedLabel.AutoSize = true;
            this.semestersOfferedLabel.Location = new System.Drawing.Point(43, 197);
            this.semestersOfferedLabel.Name = "semestersOfferedLabel";
            this.semestersOfferedLabel.Size = new System.Drawing.Size(97, 13);
            this.semestersOfferedLabel.TabIndex = 8;
            this.semestersOfferedLabel.Text = "Semesters Offered:";
            // 
            // fallCheckBox
            // 
            this.fallCheckBox.AutoSize = true;
            this.fallCheckBox.Location = new System.Drawing.Point(158, 196);
            this.fallCheckBox.Name = "fallCheckBox";
            this.fallCheckBox.Size = new System.Drawing.Size(42, 17);
            this.fallCheckBox.TabIndex = 9;
            this.fallCheckBox.Text = "Fall";
            this.fallCheckBox.UseVisualStyleBackColor = true;
            // 
            // springCheckBox
            // 
            this.springCheckBox.AutoSize = true;
            this.springCheckBox.Location = new System.Drawing.Point(206, 197);
            this.springCheckBox.Name = "springCheckBox";
            this.springCheckBox.Size = new System.Drawing.Size(56, 17);
            this.springCheckBox.TabIndex = 10;
            this.springCheckBox.Text = "Spring";
            this.springCheckBox.UseVisualStyleBackColor = true;
            // 
            // prereqListBox
            // 
            this.prereqListBox.FormattingEnabled = true;
            this.prereqListBox.Location = new System.Drawing.Point(158, 240);
            this.prereqListBox.Name = "prereqListBox";
            this.prereqListBox.Size = new System.Drawing.Size(189, 94);
            this.prereqListBox.TabIndex = 11;
            // 
            // prereqLabel
            // 
            this.prereqLabel.AutoSize = true;
            this.prereqLabel.Location = new System.Drawing.Point(43, 240);
            this.prereqLabel.Name = "prereqLabel";
            this.prereqLabel.Size = new System.Drawing.Size(70, 13);
            this.prereqLabel.TabIndex = 12;
            this.prereqLabel.Text = "Prerequisites:";
            // 
            // AddEditCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 411);
            this.Controls.Add(this.prereqLabel);
            this.Controls.Add(this.prereqListBox);
            this.Controls.Add(this.springCheckBox);
            this.Controls.Add(this.fallCheckBox);
            this.Controls.Add(this.semestersOfferedLabel);
            this.Controls.Add(this.creditHours);
            this.Controls.Add(this.creditHoursLabel);
            this.Controls.Add(this.courseNameLabel);
            this.Controls.Add(this.courseName);
            this.Controls.Add(this.courseID);
            this.Controls.Add(this.courseIDLabel);
            this.Controls.Add(this.formLabel);
            this.Controls.Add(this.submitButton);
            this.Name = "AddEditCourseForm";
            this.Text = "Add/Edit Course";
            this.Load += new System.EventHandler(this.AddEditCourseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label formLabel;
        private System.Windows.Forms.Label courseIDLabel;
        private System.Windows.Forms.TextBox courseID;
        private System.Windows.Forms.TextBox courseName;
        private System.Windows.Forms.Label courseNameLabel;
        private System.Windows.Forms.Label creditHoursLabel;
        private System.Windows.Forms.TextBox creditHours;
        private System.Windows.Forms.Label semestersOfferedLabel;
        private System.Windows.Forms.CheckBox fallCheckBox;
        private System.Windows.Forms.CheckBox springCheckBox;
        private System.Windows.Forms.CheckedListBox prereqListBox;
        private System.Windows.Forms.Label prereqLabel;
    }
}

