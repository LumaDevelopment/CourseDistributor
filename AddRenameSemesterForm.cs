using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseDistributor
{
    public partial class AddRenameSemesterForm : Form
    {

        private MainForm mainForm;
        private List<Semester> semesters;
        private int semesterIndex;

        public AddRenameSemesterForm(MainForm mainForm, int semesterIndex)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.semesters = mainForm.semesters;
            this.semesterIndex = semesterIndex;
        }

        private void AddRenameSemesterForm_Load(object sender, EventArgs e)
        {

            if (semesters.Count == semesterIndex)
            {
                this.Text = "Add Semester";
                submitButton.Text = "Add";
            } else
            {
                this.Text = "Edit Semester";
                submitButton.Text = "Edit";
                semesterName.Text = semesters[semesterIndex].semesterName;
                minCreditHours.Text = semesters[semesterIndex].minCreditHours.ToString();
                maxCreditHours.Text = semesters[semesterIndex].maxCreditHours.ToString();
            }

        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(minCreditHours.Text, out int minCreditHoursForSemester)
                || !int.TryParse(maxCreditHours.Text, out int maxCreditHoursForSemester))
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Both minimum and maximum credit hours must be integers!", "Invalid Input", buttons, MessageBoxIcon.Error);
                return;
            }

            if(semesterIndex == semesters.Count)
            {
                Semester semester = new Semester(
                    semesterName.Text,
                    int.Parse(minCreditHours.Text),
                    int.Parse(maxCreditHours.Text));
                semesters.Add(semester);
            } else
            {

                Semester temp = semesters[semesterIndex];
                temp.semesterName = semesterName.Text;
                temp.minCreditHours = int.Parse(minCreditHours.Text);
                temp.maxCreditHours = int.Parse(maxCreditHours.Text);

                semesters[semesterIndex] = temp;

            }

            mainForm.RefreshSemesterBox();

            this.Close();

        }
    }
}
