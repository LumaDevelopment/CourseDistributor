namespace CourseDistributor
{
    partial class AddEditSemesterForm
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
            this.formLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.semesterName = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.maximumCreditHoursLabel = new System.Windows.Forms.Label();
            this.maxCreditHours = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // formLabel
            // 
            this.formLabel.AutoSize = true;
            this.formLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formLabel.Location = new System.Drawing.Point(102, 22);
            this.formLabel.Name = "formLabel";
            this.formLabel.Size = new System.Drawing.Size(167, 24);
            this.formLabel.TabIndex = 2;
            this.formLabel.Text = "Add/Edit Semester";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(55, 72);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Name:";
            // 
            // semesterName
            // 
            this.semesterName.Location = new System.Drawing.Point(181, 69);
            this.semesterName.Name = "semesterName";
            this.semesterName.Size = new System.Drawing.Size(130, 20);
            this.semesterName.TabIndex = 4;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(141, 149);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 5;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // maximumCreditHoursLabel
            // 
            this.maximumCreditHoursLabel.AutoSize = true;
            this.maximumCreditHoursLabel.Location = new System.Drawing.Point(55, 109);
            this.maximumCreditHoursLabel.Name = "maximumCreditHoursLabel";
            this.maximumCreditHoursLabel.Size = new System.Drawing.Size(115, 13);
            this.maximumCreditHoursLabel.TabIndex = 7;
            this.maximumCreditHoursLabel.Text = "Maximum Credit Hours:";
            // 
            // maxCreditHours
            // 
            this.maxCreditHours.Location = new System.Drawing.Point(181, 106);
            this.maxCreditHours.MaxLength = 2;
            this.maxCreditHours.Name = "maxCreditHours";
            this.maxCreditHours.Size = new System.Drawing.Size(44, 20);
            this.maxCreditHours.TabIndex = 9;
            // 
            // AddEditSemesterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 201);
            this.Controls.Add(this.maxCreditHours);
            this.Controls.Add(this.maximumCreditHoursLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.semesterName);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.formLabel);
            this.Name = "AddEditSemesterForm";
            this.Text = "Add/Edit Semester";
            this.Load += new System.EventHandler(this.AddRenameSemesterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label formLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox semesterName;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label maximumCreditHoursLabel;
        private System.Windows.Forms.TextBox maxCreditHours;
    }
}