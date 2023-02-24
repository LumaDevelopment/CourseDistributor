﻿namespace CourseDistributor
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
            this.SuspendLayout();
            // 
            // addCourse
            // 
            this.addCourse.Location = new System.Drawing.Point(17, 65);
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
            this.appTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appTitle.Location = new System.Drawing.Point(12, 9);
            this.appTitle.Name = "appTitle";
            this.appTitle.Size = new System.Drawing.Size(207, 29);
            this.appTitle.TabIndex = 1;
            this.appTitle.Text = "Course Distributor";
            // 
            // courseMgmtLabel
            // 
            this.courseMgmtLabel.AutoSize = true;
            this.courseMgmtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseMgmtLabel.Location = new System.Drawing.Point(13, 38);
            this.courseMgmtLabel.Name = "courseMgmtLabel";
            this.courseMgmtLabel.Size = new System.Drawing.Size(187, 24);
            this.courseMgmtLabel.TabIndex = 2;
            this.courseMgmtLabel.Text = "Course Management";
            // 
            // courseBox
            // 
            this.courseBox.FormattingEnabled = true;
            this.courseBox.Location = new System.Drawing.Point(17, 123);
            this.courseBox.Name = "courseBox";
            this.courseBox.Size = new System.Drawing.Size(183, 381);
            this.courseBox.TabIndex = 3;
            this.courseBox.DoubleClick += new System.EventHandler(this.courseBox_DoubleClick);
            // 
            // removeCourse
            // 
            this.removeCourse.Location = new System.Drawing.Point(17, 94);
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
            this.semesterMgmtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.semesterMgmtLabel.Location = new System.Drawing.Point(237, 38);
            this.semesterMgmtLabel.Name = "semesterMgmtLabel";
            this.semesterMgmtLabel.Size = new System.Drawing.Size(206, 24);
            this.semesterMgmtLabel.TabIndex = 5;
            this.semesterMgmtLabel.Text = "Semester Management";
            // 
            // addSemester
            // 
            this.addSemester.Location = new System.Drawing.Point(241, 65);
            this.addSemester.Name = "addSemester";
            this.addSemester.Size = new System.Drawing.Size(202, 23);
            this.addSemester.TabIndex = 6;
            this.addSemester.Text = "Add Semester";
            this.addSemester.UseVisualStyleBackColor = true;
            this.addSemester.Click += new System.EventHandler(this.addSemester_Click);
            // 
            // removeSemester
            // 
            this.removeSemester.Location = new System.Drawing.Point(241, 94);
            this.removeSemester.Name = "removeSemester";
            this.removeSemester.Size = new System.Drawing.Size(202, 23);
            this.removeSemester.TabIndex = 7;
            this.removeSemester.Text = "Remove Selected Semester";
            this.removeSemester.UseVisualStyleBackColor = true;
            this.removeSemester.Click += new System.EventHandler(this.removeSemester_Click);
            // 
            // semesterBox
            // 
            this.semesterBox.FormattingEnabled = true;
            this.semesterBox.Location = new System.Drawing.Point(241, 123);
            this.semesterBox.Name = "semesterBox";
            this.semesterBox.Size = new System.Drawing.Size(202, 355);
            this.semesterBox.TabIndex = 8;
            this.semesterBox.DoubleClick += new System.EventHandler(this.semesterBox_DoubleClick);
            // 
            // moveSemesterUp
            // 
            this.moveSemesterUp.Location = new System.Drawing.Point(241, 484);
            this.moveSemesterUp.Name = "moveSemesterUp";
            this.moveSemesterUp.Size = new System.Drawing.Size(98, 23);
            this.moveSemesterUp.TabIndex = 9;
            this.moveSemesterUp.Text = "Up";
            this.moveSemesterUp.UseVisualStyleBackColor = true;
            this.moveSemesterUp.Click += new System.EventHandler(this.moveSemesterUp_Click);
            // 
            // moveSemesterDown
            // 
            this.moveSemesterDown.Location = new System.Drawing.Point(345, 484);
            this.moveSemesterDown.Name = "moveSemesterDown";
            this.moveSemesterDown.Size = new System.Drawing.Size(98, 23);
            this.moveSemesterDown.TabIndex = 10;
            this.moveSemesterDown.Text = "Down";
            this.moveSemesterDown.UseVisualStyleBackColor = true;
            this.moveSemesterDown.Click += new System.EventHandler(this.moveSemesterDown_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 523);
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
    }
}
