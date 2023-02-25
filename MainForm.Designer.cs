namespace CourseDistributor
{
    partial class MainForm
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
            this.addCourse = new System.Windows.Forms.Button();
            this.appTitle = new System.Windows.Forms.Label();
            this.courseMgmtLabel = new System.Windows.Forms.Label();
            this.courseBox = new System.Windows.Forms.ListBox();
            this.removeCourse = new System.Windows.Forms.Button();
            this.semesterMgmtLabel = new System.Windows.Forms.Label();
            this.addSemester = new System.Windows.Forms.Button();
            this.removeSemester = new System.Windows.Forms.Button();
            this.semesterBox = new System.Windows.Forms.ListBox();
            this.moveSemesterUp = new System.Windows.Forms.Button();
            this.moveSemesterDown = new System.Windows.Forms.Button();
            this.courseDistributionLabel = new System.Windows.Forms.Label();
            this.distributeCourses = new System.Windows.Forms.Button();
            this.courseDistribution = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // addCourse
            // 
            this.addCourse.Location = new System.Drawing.Point(18, 78);
            this.addCourse.Name = "addCourse";
            this.addCourse.Size = new System.Drawing.Size(183, 23);
            this.addCourse.TabIndex = 0;
            this.addCourse.Text = "Add Course";
            this.addCourse.UseVisualStyleBackColor = true;
            this.addCourse.Click += new System.EventHandler(this.addCourse_Click);
            // 
            // appTitle
            // 
            this.appTitle.AutoSize = true;
            this.appTitle.Font = new System.Drawing.Font("Open Sans Semibold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appTitle.Location = new System.Drawing.Point(12, 14);
            this.appTitle.Name = "appTitle";
            this.appTitle.Size = new System.Drawing.Size(229, 33);
            this.appTitle.TabIndex = 1;
            this.appTitle.Text = "Course Distributor";
            // 
            // courseMgmtLabel
            // 
            this.courseMgmtLabel.AutoSize = true;
            this.courseMgmtLabel.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseMgmtLabel.Location = new System.Drawing.Point(13, 51);
            this.courseMgmtLabel.Name = "courseMgmtLabel";
            this.courseMgmtLabel.Size = new System.Drawing.Size(200, 26);
            this.courseMgmtLabel.TabIndex = 2;
            this.courseMgmtLabel.Text = "Course Management";
            // 
            // courseBox
            // 
            this.courseBox.FormattingEnabled = true;
            this.courseBox.Location = new System.Drawing.Point(18, 136);
            this.courseBox.Name = "courseBox";
            this.courseBox.Size = new System.Drawing.Size(183, 446);
            this.courseBox.TabIndex = 3;
            this.courseBox.DoubleClick += new System.EventHandler(this.courseBox_DoubleClick);
            // 
            // removeCourse
            // 
            this.removeCourse.Location = new System.Drawing.Point(18, 107);
            this.removeCourse.Name = "removeCourse";
            this.removeCourse.Size = new System.Drawing.Size(183, 23);
            this.removeCourse.TabIndex = 4;
            this.removeCourse.Text = "Remove Selected Course";
            this.removeCourse.UseVisualStyleBackColor = true;
            this.removeCourse.Click += new System.EventHandler(this.removeCourse_Click);
            // 
            // semesterMgmtLabel
            // 
            this.semesterMgmtLabel.AutoSize = true;
            this.semesterMgmtLabel.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.semesterMgmtLabel.Location = new System.Drawing.Point(237, 51);
            this.semesterMgmtLabel.Name = "semesterMgmtLabel";
            this.semesterMgmtLabel.Size = new System.Drawing.Size(222, 26);
            this.semesterMgmtLabel.TabIndex = 5;
            this.semesterMgmtLabel.Text = "Semester Management";
            // 
            // addSemester
            // 
            this.addSemester.Location = new System.Drawing.Point(241, 78);
            this.addSemester.Name = "addSemester";
            this.addSemester.Size = new System.Drawing.Size(218, 23);
            this.addSemester.TabIndex = 6;
            this.addSemester.Text = "Add Semester";
            this.addSemester.UseVisualStyleBackColor = true;
            this.addSemester.Click += new System.EventHandler(this.addSemester_Click);
            // 
            // removeSemester
            // 
            this.removeSemester.Location = new System.Drawing.Point(241, 107);
            this.removeSemester.Name = "removeSemester";
            this.removeSemester.Size = new System.Drawing.Size(218, 23);
            this.removeSemester.TabIndex = 7;
            this.removeSemester.Text = "Remove Selected Semester";
            this.removeSemester.UseVisualStyleBackColor = true;
            this.removeSemester.Click += new System.EventHandler(this.removeSemester_Click);
            // 
            // semesterBox
            // 
            this.semesterBox.FormattingEnabled = true;
            this.semesterBox.Location = new System.Drawing.Point(241, 136);
            this.semesterBox.Name = "semesterBox";
            this.semesterBox.Size = new System.Drawing.Size(218, 420);
            this.semesterBox.TabIndex = 8;
            this.semesterBox.DoubleClick += new System.EventHandler(this.semesterBox_DoubleClick);
            // 
            // moveSemesterUp
            // 
            this.moveSemesterUp.Location = new System.Drawing.Point(241, 562);
            this.moveSemesterUp.Name = "moveSemesterUp";
            this.moveSemesterUp.Size = new System.Drawing.Size(106, 23);
            this.moveSemesterUp.TabIndex = 9;
            this.moveSemesterUp.Text = "Up";
            this.moveSemesterUp.UseVisualStyleBackColor = true;
            this.moveSemesterUp.Click += new System.EventHandler(this.moveSemesterUp_Click);
            // 
            // moveSemesterDown
            // 
            this.moveSemesterDown.Location = new System.Drawing.Point(353, 562);
            this.moveSemesterDown.Name = "moveSemesterDown";
            this.moveSemesterDown.Size = new System.Drawing.Size(106, 23);
            this.moveSemesterDown.TabIndex = 10;
            this.moveSemesterDown.Text = "Down";
            this.moveSemesterDown.UseVisualStyleBackColor = true;
            this.moveSemesterDown.Click += new System.EventHandler(this.moveSemesterDown_Click);
            // 
            // courseDistributionLabel
            // 
            this.courseDistributionLabel.AutoSize = true;
            this.courseDistributionLabel.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseDistributionLabel.Location = new System.Drawing.Point(494, 51);
            this.courseDistributionLabel.Name = "courseDistributionLabel";
            this.courseDistributionLabel.Size = new System.Drawing.Size(187, 26);
            this.courseDistributionLabel.TabIndex = 11;
            this.courseDistributionLabel.Text = "Course Distribution";
            // 
            // distributeCourses
            // 
            this.distributeCourses.Location = new System.Drawing.Point(499, 78);
            this.distributeCourses.Name = "distributeCourses";
            this.distributeCourses.Size = new System.Drawing.Size(373, 23);
            this.distributeCourses.TabIndex = 12;
            this.distributeCourses.Text = "Distribute Courses";
            this.distributeCourses.UseVisualStyleBackColor = true;
            this.distributeCourses.Click += new System.EventHandler(this.distributeCourses_Click);
            // 
            // courseDistribution
            // 
            this.courseDistribution.Location = new System.Drawing.Point(499, 107);
            this.courseDistribution.Name = "courseDistribution";
            this.courseDistribution.Size = new System.Drawing.Size(373, 478);
            this.courseDistribution.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 605);
            this.Controls.Add(this.courseDistribution);
            this.Controls.Add(this.distributeCourses);
            this.Controls.Add(this.courseDistributionLabel);
            this.Controls.Add(this.moveSemesterDown);
            this.Controls.Add(this.moveSemesterUp);
            this.Controls.Add(this.semesterBox);
            this.Controls.Add(this.removeSemester);
            this.Controls.Add(this.addSemester);
            this.Controls.Add(this.semesterMgmtLabel);
            this.Controls.Add(this.removeCourse);
            this.Controls.Add(this.courseBox);
            this.Controls.Add(this.courseMgmtLabel);
            this.Controls.Add(this.appTitle);
            this.Controls.Add(this.addCourse);
            this.Name = "MainForm";
            this.Text = "Course Distributor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addCourse;
        private System.Windows.Forms.Label appTitle;
        private System.Windows.Forms.Label courseMgmtLabel;
        private System.Windows.Forms.ListBox courseBox;
        private System.Windows.Forms.Button removeCourse;
        private System.Windows.Forms.Label semesterMgmtLabel;
        private System.Windows.Forms.Button addSemester;
        private System.Windows.Forms.Button removeSemester;
        private System.Windows.Forms.ListBox semesterBox;
        private System.Windows.Forms.Button moveSemesterUp;
        private System.Windows.Forms.Button moveSemesterDown;
        private System.Windows.Forms.Label courseDistributionLabel;
        private System.Windows.Forms.Button distributeCourses;
        private System.Windows.Forms.TreeView courseDistribution;
    }
}

