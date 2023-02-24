using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;

namespace CourseDistributor
{
    public partial class MainForm : Form
    {

        public Dictionary<string, Course> Courses;
        public List<Semester> Semesters;
        private UserSettings _settings;

        public MainForm()
        {
            InitializeComponent();
        }

        public void RefreshCourseBox()
        {

            courseBox.Items.Clear();

            foreach (var courseId in Courses.Keys)
            {
                courseBox.Items.Add(courseId);
            }

        }

        public void RefreshSemesterBox()
        {

            semesterBox.Items.Clear();

            foreach (var semester in Semesters)
            {
                semesterBox.Items.Add(semester);
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _settings = new UserSettings();

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

            RefreshCourseBox();
            RefreshSemesterBox();

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settings.Courses = JsonSerializer.Serialize(Courses);
            _settings.Semesters = JsonSerializer.Serialize(Semesters);
            _settings.Save();
        }

        private void addCourse_Click(object sender, EventArgs e)
        {
            new AddEditCourseForm(this).Show();
        }

        private void courseBox_DoubleClick(object sender, EventArgs e)
        {
            new AddEditCourseForm(this, (string) courseBox.SelectedItem).Show();
        }

        private void removeCourse_Click(object sender, EventArgs e)
        {

            if (courseBox.SelectedItem == null)
            {
                return;
            }

            var courseId = (string)courseBox.SelectedItem;

            var res = MessageBox.Show("Are you sure you want to delete course " + courseId + "?", "Deletion Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res != DialogResult.OK)
            {
                return;
            }

            Courses.Remove(courseId);
            RefreshCourseBox();

        }

        private void addSemester_Click(object sender, EventArgs e)
        {
            new AddRenameSemesterForm(this, Semesters.Count).Show();
        }

        private void semesterBox_DoubleClick(object sender, EventArgs e)
        {
            new AddRenameSemesterForm(this, semesterBox.SelectedIndex).Show();
        }

        private void removeSemester_Click(object sender, EventArgs e)
        {

            var semesterName = Semesters[semesterBox.SelectedIndex].semesterName;
            var res = MessageBox.Show("Are you sure you want to delete semester " + semesterName + "?", "Deletion Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res != DialogResult.OK)
            {
                return;
            }

            Semesters.RemoveAt(semesterBox.SelectedIndex);
            RefreshSemesterBox();

        }

        private void moveSemesterUp_Click(object sender, EventArgs e)
        {

            if (semesterBox.SelectedItem == null)
            {
                return;
            }

            var selectedIndex = semesterBox.SelectedIndex;

            if ((selectedIndex - 1) == -1)
            {
                return;
            }

            (Semesters[selectedIndex], Semesters[selectedIndex - 1]) =
                (Semesters[selectedIndex - 1], Semesters[selectedIndex]);

            RefreshSemesterBox();

        }

        private void moveSemesterDown_Click(object sender, EventArgs e)
        {

            if (semesterBox.SelectedItem == null)
            {
                return;
            }

            var selectedIndex = semesterBox.SelectedIndex;

            if ((selectedIndex + 1) == Semesters.Count)
            {
                return;
            }

            (Semesters[selectedIndex], Semesters[selectedIndex + 1]) =
                (Semesters[selectedIndex + 1], Semesters[selectedIndex]);

            RefreshSemesterBox();

        }
    }
}
