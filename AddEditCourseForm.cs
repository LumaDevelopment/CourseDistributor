using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CourseDistributor
{
    public partial class AddEditCourseForm : Form
    {

        private readonly MainForm _mainForm;
        private readonly Dictionary<string, Course> _courses;
        private readonly string _selectedCourse;

        public AddEditCourseForm(MainForm mainForm)
        {
            InitializeComponent();
            this._mainForm = mainForm;
            this._courses = mainForm.Courses;
            this._selectedCourse = null;
        }

        public AddEditCourseForm(MainForm mainForm, string selectedCourse)
        {

            InitializeComponent();
            this._mainForm = mainForm;
            this._courses = mainForm.Courses;
            this._selectedCourse = selectedCourse;
        }

        private void InitializeFieldsFromCourseId(string targetCourseId) {

            _courses.TryGetValue(targetCourseId, out var course);

            if (course == null)
            {
                return;
            }

            courseID.Text = course.courseId;
            courseName.Text = course.courseName;
            creditHours.Text = course.creditHours.ToString();

            switch (course.semestersOffered)
            {
                case SemestersOffered.Spring:
                    springCheckBox.Checked = true; break;
                case SemestersOffered.Fall:
                    fallCheckBox.Checked = true; break;
                case SemestersOffered.Both:
                    springCheckBox.Checked = true;
                    fallCheckBox.Checked = true;
                    break;
                default:
                    break;
            }

            prereqListBox.Items.Remove(course.courseId);

            for (var i = 0; i < prereqListBox.Items.Count; i++)
            {

                if (course.prerequisites.Contains((string) prereqListBox.Items[i]))
                {
                    prereqListBox.SetItemChecked(i, true);
                }

            }

        }

        private void AddEditCourseForm_Load(object sender, EventArgs e)
        {

            foreach (KeyValuePair<string, Course> course in _courses) {
                prereqListBox.Items.Add(course.Key);
            }

            if (_selectedCourse != null)
            {
                this.Text = "Edit Course";
                submitButton.Text = "Edit";
                InitializeFieldsFromCourseId(_selectedCourse);
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
                MessageBox.Show("Credit hours field must be an integer!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!fallCheckBox.Checked && !springCheckBox.Checked)
            {
                MessageBox.Show("Course must be available in either fall or spring!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(_courses.ContainsKey(courseID.Text))
            {
                _courses.Remove(courseID.Text);
            }

            _courses.Add(courseID.Text, GetCourseFromUI());

            _mainForm.RefreshCourseBox();

            this.Close();

        }

        private Course GetCourseFromUI()
        {

            var prerequisites = new List<string>();
            prerequisites.AddRange(prereqListBox.CheckedItems.Cast<string>());

            var course = new Course(
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
                return SemestersOffered.Both;
            }
            else if (fall)
            {
                return SemestersOffered.Fall;
            }
            else if (spring)
            {
                return SemestersOffered.Spring;
            }
            else
            {
                throw new ArgumentException("At least one of the booleans must be true");
            }

        }

    }
}
