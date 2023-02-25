using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;

namespace CourseDistributor
{

    /**
     * Handles the logic for the main form of the class.
     */
    public partial class MainForm : Form
    {

        public Dictionary<string, Course> Courses;
        public List<Semester> Semesters;
        private UserSettings _settings;

        public MainForm()
        {
            InitializeComponent();
        }

        /**
         * Refresh the course box by clearing all items from the 
         * course box and adding all courses from the Courses 
         * dictionary to the course box.
         */
        public void RefreshCourseBox()
        {

            courseBox.Items.Clear();

            foreach (var courseId in Courses.Keys)
            {
                courseBox.Items.Add(courseId);
            }

        }

        /**
         * Refresh the semester box by clearing all items from the 
         * semester box and adding all semesters from the Semesters
         * dictionary to the course box.
         */
        public void RefreshSemesterBox()
        {

            semesterBox.Items.Clear();

            foreach (var semester in Semesters)
            {
                semesterBox.Items.Add(semester);
            }

        }

        /**
         * Called when the main form is opened.
         */
        private void MainForm_Load(object sender, EventArgs e)
        {

            // Get ready to load from user settings
            _settings = new UserSettings();

            // Attempt to retrieve courses from user settings, and if we can't, 
            // create a new dictionary for courses
            if (_settings.Courses != null)
            {

                var coursesFromSettings = JsonSerializer.Deserialize<Dictionary<string, Course>>(_settings.Courses);

                if (coursesFromSettings != null)
                {
                    Courses = coursesFromSettings;
                } else
                {
                    Courses = new Dictionary<string, Course> ();
                }

            } else
            {
                Courses = new Dictionary<string, Course> ();
            }

            // Attempt to retrieve semesters from user settings, and if we can't,
            // create a new list for semesters
            if(_settings.Semesters != null)
            {
                var semestersFromSettings = JsonSerializer.Deserialize<List<Semester>> (_settings.Semesters);

                if (semestersFromSettings != null)
                {
                    Semesters = semestersFromSettings;
                } else
                {
                    Semesters = new List<Semester>();
                }

            } else
            {
                Semesters = new List<Semester> ();
            }

            // Load UI
            RefreshCourseBox();
            RefreshSemesterBox();

        }

        /**
         * When the program is closed, save data to user settings
         */
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            _settings.Courses = JsonSerializer.Serialize(Courses);
            _settings.Semesters = JsonSerializer.Serialize(Semesters);
            _settings.Save();

        }

        /**
         * On add course button click, show add course form
         */
        private void addCourse_Click(object sender, EventArgs e)
        {
            new AddEditCourseForm(this).Show();
        }

        /**
         * On remove course button click, check if there's a selected button,
         * then confirm that the user wants to delete the selected course.
         * If so, remove the course and refresh the course box UI.
         */
        private void removeCourse_Click(object sender, EventArgs e)
        {

            // Make sure a course is selected
            if (courseBox.SelectedItem == null)
            {
                return;
            }

            var courseId = (string)courseBox.SelectedItem;

            // Show message box
            var res = MessageBox.Show("Are you sure you want to delete course " + courseId + "?", "Deletion Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res != DialogResult.OK)
            {
                // If cancelled, don't remove course
                return;
            }

            RemoveCourse(courseId);

            // Update UI
            RefreshCourseBox();

        }

        /**
         * Remove a course by erasing all references to it from other courses,
         * then removing it from the Courses dictionary.
         */
        public void RemoveCourse(string courseId)
        {

            Courses.TryGetValue(courseId, out var course);

            // Make sure course exists
            if (course == null)
            {
                return;
            }

            // Remove this course from all other courses' dependents lists.
            foreach (var prereqId in course.prerequisites)
            {

                Courses.TryGetValue(prereqId, out var prereqCourse);

                if (prereqCourse == null)
                {
                    continue;
                }

                prereqCourse.dependents.Remove(courseId);

            }

            // Remove this course from all other courses' prerequisites lists.
            foreach (var dependentId in course.dependents)
            {

                Courses.TryGetValue(dependentId, out var dependentCourse);

                if (dependentCourse == null)
                {
                    continue;
                }

                dependentCourse.prerequisites.Remove(courseId);

            }

            // Remove this course from the Courses dictionary
            Courses.Remove(courseId);

        }

        /**
         * On course double click, bring up the edit course form.
         */
        private void courseBox_DoubleClick(object sender, EventArgs e)
        {
            new AddEditCourseForm(this, (string)courseBox.SelectedItem).Show();
        }

        /**
         * On add semester button click, bring up the add semester form.
         */
        private void addSemester_Click(object sender, EventArgs e)
        {
            new AddEditSemesterForm(this, Semesters.Count).Show();
        }

        /**
         * On remove semester button click, confirm the user wants to delete the semester,
         * and if so, delete the semester.
         */
        private void removeSemester_Click(object sender, EventArgs e)
        {

            // Make sure a semester is selected
            if (semesterBox.SelectedItem == null)
            {
                return;
            }

            var semesterName = Semesters[semesterBox.SelectedIndex].semesterName;

            // Confirm semester delete
            var res = MessageBox.Show("Are you sure you want to delete semester " + semesterName + "?", "Deletion Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res != DialogResult.OK)
            {
                // If cancelled, don't remove semester
                return;
            }

            Semesters.RemoveAt(semesterBox.SelectedIndex);

            // Update UI
            RefreshSemesterBox();

        }

        /**
         * On semester double click, bring up the edit semester form.
         */
        private void semesterBox_DoubleClick(object sender, EventArgs e)
        {
            new AddEditSemesterForm(this, semesterBox.SelectedIndex).Show();
        }

        /**
         * On up button click, move the selected semester up one place in the semester list.
         */
        private void moveSemesterUp_Click(object sender, EventArgs e)
        {

            // Make sure a semester is selected
            if (semesterBox.SelectedItem == null)
            {
                return;
            }

            var selectedIndex = semesterBox.SelectedIndex;

            // Out of bounds check
            if ((selectedIndex - 1) == -1)
            {
                return;
            }

            // Swap the selected semester with the one above it
            (Semesters[selectedIndex], Semesters[selectedIndex - 1]) =
                (Semesters[selectedIndex - 1], Semesters[selectedIndex]);

            // Update UI
            RefreshSemesterBox();

        }

        /**
         * On down button click, move the selected semester down one place in the semester list.
         */
        private void moveSemesterDown_Click(object sender, EventArgs e)
        {

            // Make sure a semester is selected
            if (semesterBox.SelectedItem == null)
            {
                return;
            }

            var selectedIndex = semesterBox.SelectedIndex;

            // Out of bounds check
            if ((selectedIndex + 1) == Semesters.Count)
            {
                return;
            }

            // Swap the selected semester with the one below it
            (Semesters[selectedIndex], Semesters[selectedIndex + 1]) =
                (Semesters[selectedIndex + 1], Semesters[selectedIndex]);

            // Update UI
            RefreshSemesterBox();

        }

        /**
         * On distribute courses click, create a new instance of the Distributor and
         * run it. The Distributor will then distribute courses, and display
         * its course distribution on the UI.
         */
        private void distributeCourses_Click(object sender, EventArgs e)
        {
            new Distributor(Courses, Semesters, courseDistribution).Run();
        }

    }
}
