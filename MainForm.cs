using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;

namespace CourseDistributor
{
    public partial class MainForm : Form
    {

        public Dictionary<String, Course> courses;
        public List<Semester> semesters;
        private UserSettings settings;

        public MainForm()
        {
            InitializeComponent();
        }

        public void RefreshCourseBox()
        {

            courseBox.Items.Clear();

            foreach (String courseId in courses.Keys)
            {
                courseBox.Items.Add(courseId);
            }

        }

        public void RefreshSemesterBox()
        {

            semesterBox.Items.Clear();

            for (int i = 0; i < semesters.Count; i++)
            {
                semesterBox.Items.Add(semesters[i]);
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            settings = new UserSettings();

            if (settings.Courses != null)
            {

                Dictionary<String, Course> coursesFromSettings = JsonSerializer.Deserialize<Dictionary<String, Course>>(settings.Courses);

                if (coursesFromSettings != null)
                {
                    courses = coursesFromSettings;
                } else
                {
                    courses = new Dictionary<String, Course> ();
                }

            } else
            {
                courses = new Dictionary<String, Course> ();
            }

            if(settings.Semesters != null)
            {
                List<Semester> semestersFromSettings = JsonSerializer.Deserialize<List<Semester>> (settings.Semesters);

                if (semestersFromSettings != null)
                {
                    semesters = semestersFromSettings;
                } else
                {
                    semesters = new List<Semester>();
                }

            } else
            {
                semesters = new List<Semester> ();
            }

            RefreshCourseBox();
            RefreshSemesterBox();

        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.Courses = JsonSerializer.Serialize(courses);
            settings.Semesters = JsonSerializer.Serialize(semesters);
            settings.Save();
        }

        private void addCourse_Click(object sender, EventArgs e)
        {
            new AddEditCourseForm(this).Show();
        }

        private void courseBox_DoubleClick(object sender, EventArgs e)
        {
            new AddEditCourseForm(this, (String) courseBox.SelectedItem).Show();
        }

        private void removeCourse_Click(object sender, EventArgs e)
        {

            if(courseBox.SelectedItem != null)
            {

                String courseID = (String) courseBox.SelectedItem;

                DialogResult res = MessageBox.Show("Are you sure you want to delete course " + courseID + "?", "Deletion Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res == DialogResult.OK)
                {
                    courses.Remove(courseID);
                    RefreshCourseBox();
                }
                
            }

        }

        private void addSemester_Click(object sender, EventArgs e)
        {
            new AddRenameSemesterForm(this, semesters.Count).Show();
        }

        private void semesterBox_DoubleClick(object sender, EventArgs e)
        {
            new AddRenameSemesterForm(this, semesterBox.SelectedIndex).Show();
        }

        private void removeSemester_Click(object sender, EventArgs e)
        {

            string semesterName = semesters[semesterBox.SelectedIndex].semesterName;
            DialogResult res = MessageBox.Show("Are you sure you want to delete semester " + semesterName + "?", "Deletion Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.OK)
            {
                semesters.RemoveAt(semesterBox.SelectedIndex);
                RefreshSemesterBox();
            }

        }

        private void moveSemesterUp_Click(object sender, EventArgs e)
        {

            if (semesterBox.SelectedItem == null)
            {
                return;
            }

            int selectedIndex = semesterBox.SelectedIndex;

            if ((selectedIndex - 1) == -1)
            {
                return;
            }

            Semester temp = semesters[selectedIndex];
            semesters[selectedIndex] = semesters[selectedIndex - 1];
            semesters[selectedIndex - 1] = temp;

            RefreshSemesterBox();

        }

        private void moveSemesterDown_Click(object sender, EventArgs e)
        {

            if (semesterBox.SelectedItem == null)
            {
                return;
            }

            int selectedIndex = semesterBox.SelectedIndex;

            if ((selectedIndex + 1) == semesters.Count)
            {
                return;
            }

            Semester temp = semesters[selectedIndex];
            semesters[selectedIndex] = semesters[selectedIndex + 1];
            semesters[selectedIndex + 1] = temp;

            RefreshSemesterBox();

        }
    }
}
