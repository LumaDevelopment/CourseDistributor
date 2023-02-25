using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CourseDistributor
{

    /**
     * Handles the logic for the add and edit course form.
     */
    public partial class AddEditCourseForm : Form
    {

        // To access main form methods for UI interaction and course removal
        private readonly MainForm _mainForm;

        // Directory of courses to modify
        private readonly Dictionary<string, Course> _courses;

        // Course ID of the course to edit, null if adding a new course
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

        /**
         * Given a course ID, fill in all the information on the form with
         * the existing information of that course ID
         */
        private void InitializeFieldsFromCourseId(string targetCourseId) {

            _courses.TryGetValue(targetCourseId, out var course);

            // Course DNE for some reason
            if (course == null)
            {
                return;
            }

            // Easy fields
            courseID.Text = course.courseId;
            courseName.Text = course.courseName;
            creditHours.Text = course.creditHours.ToString();

            // Check checkboxes based on semesters offered enum
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

            // Remove this course from the prerequisites list, so that 
            // a course cannot be its own prerequisite
            prereqListBox.Items.Remove(course.courseId);

            // Check all the boxes for the course's prerequisites
            for (var i = 0; i < prereqListBox.Items.Count; i++)
            {

                if (course.prerequisites.Contains((string) prereqListBox.Items[i]))
                {
                    prereqListBox.SetItemChecked(i, true);
                }

            }

        }

        /**
         * Add all prerequisites to the prerequisite list box, and change the
         * form title and submit button text based on whether we are adding
         * a new course or editing an existing one.
         */
        private void AddEditCourseForm_Load(object sender, EventArgs e)
        {

            // Add al prerequisites to prerequisite list box
            foreach (KeyValuePair<string, Course> course in _courses) {
                prereqListBox.Items.Add(course.Key);
            }

            if (_selectedCourse != null)
            {

                // Editing an existing course
                this.Text = "Edit Course";
                submitButton.Text = "Edit";
                InitializeFieldsFromCourseId(_selectedCourse);

            } else
            {

                // Add a new course
                this.Text = "Add New Course";
                submitButton.Text = "Add";

            }

        }

        /**
         * When the submit button is pressed, validate input, remove any courses associated with
         * the old and/or new course ID, add the new course to the course directory, and this course
         * as a dependent to all of its prerequisites.
         */
        private void submitButton_Click(object sender, EventArgs e)
        {

            var creditHoursTextIsNumeric = int.TryParse(creditHours.Text, out _);

            if(!creditHoursTextIsNumeric)
            {
                // If text in credit hours text field is not numeric, show error message
                MessageBox.Show("Credit hours field must be an integer!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!fallCheckBox.Checked && !springCheckBox.Checked)
            {
                // If neither checkbox is checked, show error message
                MessageBox.Show("Course must be available in either fall or spring!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (_selectedCourse != null)
            {
                // Remove the old course if we are editing an existing course
                _mainForm.RemoveCourse(_selectedCourse);
            }

            // If there's already a course with this ID, remove it
            _mainForm.RemoveCourse(courseID.Text);

            // Create course object from UI fields
            var courseToAdd = GetCourseFromUI();

            // Add course to course directory
            _courses.Add(courseID.Text, courseToAdd);

            // Add this course as a dependent to all of its prerequisites
            foreach (var dependency in courseToAdd.prerequisites)
            {
                _courses[dependency].dependents.Add(courseID.Text);
            }

            // Update UI
            _mainForm.RefreshCourseBox();

            // Close form
            this.Close();

        }

        /**
         * Create a course object from the UI fields
         */
        private Course GetCourseFromUI()
        {

            var prerequisites = new List<string>();

            // Add every checked prerequisite to the course object's prerequisites list
            prerequisites.AddRange(prereqListBox.CheckedItems.Cast<string>());

            var course = new Course(
                courseID.Text,
                courseName.Text,
                int.Parse(creditHours.Text),

                // based on the boolean value of the semester checkboxes, get a SemestersOffered enum

                SemestersOfferedFromUI(fallCheckBox.Checked, springCheckBox.Checked),
                prerequisites,
                new List<string>());

            return course;

        }
        
        /**
         * Based on the checked/not checked status of the semester check boxes,
         * return a SemestersOffered instance.
         */
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
