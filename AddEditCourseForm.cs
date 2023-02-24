using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;

namespace CourseDistributor
{
    public partial class AddEditCourseForm : Form
    {

        private MainForm mainForm;
        private Dictionary<String, Course> courses;
        private String selectedCourse;

        public AddEditCourseForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.courses = mainForm.courses;
            this.selectedCourse = null;
        }

        public AddEditCourseForm(MainForm mainForm, string selectedCourse)
        {

            InitializeComponent();
            this.mainForm = mainForm;
            this.courses = mainForm.courses;
            this.selectedCourse = selectedCourse;
        }

        private void InitializeFieldsFromCourseID(string targetCourseID) {

            courses.TryGetValue(targetCourseID, out Course course);

            if (course == null)
            {
                return;
            }

            courseID.Text = course.courseId;
            courseName.Text = course.courseName;
            creditHours.Text = course.creditHours.ToString();

            switch (course.semestersOffered)
            {
                case SemestersOffered.SPRING:
                    springCheckBox.Checked = true; break;
                case SemestersOffered.FALL:
                    fallCheckBox.Checked = true; break;
                case SemestersOffered.BOTH:
                    springCheckBox.Checked = true;
                    fallCheckBox.Checked = true;
                    break;
            }

            prereqListBox.Items.Remove(course.courseId);

            for (int i = 0; i < prereqListBox.Items.Count; i++)
            {

                if (course.prerequisites.Contains((string) prereqListBox.Items[i]))
                {
                    prereqListBox.SetItemChecked(i, true);
                }

            }

        }

        private void AddEditCourseForm_Load(object sender, EventArgs e)
        {

            foreach (KeyValuePair<String, Course> course in courses) {
                prereqListBox.Items.Add(course.Key);
            }

            if (selectedCourse != null)
            {
                this.Text = "Edit Course";
                submitButton.Text = "Edit";
                InitializeFieldsFromCourseID(selectedCourse);
            } else
            {
                this.Text = "Add New Course";
                submitButton.Text = "Add";
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

            if(courses.ContainsKey(courseID.Text))
            {
                courses.Remove(courseID.Text);
            }

            courses.Add(courseID.Text, GetCourseFromUI());

            mainForm.RefreshCourseBox();

            this.Close();

        }

        private Course GetCourseFromUI()
        {

            List<String> prerequisites = new List<String>();

            foreach (String prereqID in prereqListBox.CheckedItems)
            {

                prerequisites.Add(prereqID);

            }

            Course course = new Course(
                courseID.Text,
                courseName.Text,
                int.Parse(creditHours.Text),
                SemestersOfferedFromUI(fallCheckBox.Checked, springCheckBox.Checked),
                prerequisites);

            return course;

        }

        private SemestersOffered SemestersOfferedFromUI(bool fall, bool spring)
        {
            if (fall && spring)
            {
                return SemestersOffered.BOTH;
            }
            else if (fall)
            {
                return SemestersOffered.FALL;
            }
            else if (spring)
            {
                return SemestersOffered.SPRING;
            }
            else
            {
                throw new ArgumentException("At least one of the booleans must be true");
            }
        }

    }
}
