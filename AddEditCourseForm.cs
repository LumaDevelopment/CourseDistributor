using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseDistributor
{
    public partial class AddEditCourseForm : Form
    {

        public AddEditCourseForm(string presetCourseId)
        {
            InitializeComponent();
            courseID.Text = presetCourseId;
        }

        public AddEditCourseForm()
        {
            InitializeComponent();
        }

        private void AddEditCourseForm_Load(object sender, EventArgs e)
        {

            foreach (KeyValuePair<String, Course> course in Program.courses) {
                prereqListBox.Items.Add(course.Key);
            }

        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            var creditHoursTextIsNumeric = int.TryParse(creditHours.Text, out _);

            if(!creditHoursTextIsNumeric)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Credit hours field must be an integer!", "Invalid Input", buttons, MessageBoxIcon.Error);
                return;
            }

            if(!fallCheckBox.Checked && !springCheckBox.Checked)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Course must be available in either fall or spring!", "Invalid Input", buttons, MessageBoxIcon.Error);
                return;
            }

            if(Program.courses.ContainsKey(courseID.Text))
            {
                Program.courses.Remove(courseID.Text);
            }

            Program.courses.Add(courseID.Text, getCourseFromUI());

            this.Close();

        }

        private Course getCourseFromUI()
        {

            List<Course> prerequisites = new List<Course>();

            foreach (String s in prereqListBox.Items)
            {
                var courseExists = Program.courses.TryGetValue(s, out Course courseFromListBox);

                if (courseExists)
                {
                    prerequisites.Add(courseFromListBox);
                }

            }

            Course course = new Course(
                courseID.Text,
                courseName.Text,
                int.Parse(creditHours.Text),
                Program.semestersOfferedFromUI(fallCheckBox.Checked, springCheckBox.Checked),
                prerequisites);

            return course;

        }

    }
}
