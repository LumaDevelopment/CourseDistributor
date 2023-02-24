using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseDistributor
{
    public partial class AddRenameSemesterForm : Form
    {

        private readonly MainForm _mainForm;
        private readonly List<Semester> _semesters;
        private readonly int _semesterIndex;

        public AddRenameSemesterForm(MainForm mainForm, int semesterIndex)
        {
            InitializeComponent();
            this._mainForm = mainForm;
            this._semesters = mainForm.Semesters;
            this._semesterIndex = semesterIndex;
        }

        private void AddRenameSemesterForm_Load(object sender, EventArgs e)
        {

            if (_semesters.Count == _semesterIndex)
            {
                this.Text = "Add Semester";
                submitButton.Text = "Add";
            } else
            {
                this.Text = "Edit Semester";
                submitButton.Text = "Edit";
                semesterName.Text = _semesters[_semesterIndex].semesterName;
                minCreditHours.Text = _semesters[_semesterIndex].minCreditHours.ToString();
                maxCreditHours.Text = _semesters[_semesterIndex].maxCreditHours.ToString();
            }

        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(minCreditHours.Text, out var minCreditHoursForSemester)
                || !int.TryParse(maxCreditHours.Text, out var maxCreditHoursForSemester))
            {
                MessageBox.Show("Both minimum and maximum credit hours must be integers!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(_semesterIndex == _semesters.Count)
            {
                var semester = new Semester(
                    semesterName.Text,
                    int.Parse(minCreditHours.Text),
                    int.Parse(maxCreditHours.Text));
                _semesters.Add(semester);
            } else
            {

                var temp = _semesters[_semesterIndex];
                temp.semesterName = semesterName.Text;
                temp.minCreditHours = int.Parse(minCreditHours.Text);
                temp.maxCreditHours = int.Parse(maxCreditHours.Text);

                _semesters[_semesterIndex] = temp;

            }

            _mainForm.RefreshSemesterBox();

            this.Close();

        }
    }
}
