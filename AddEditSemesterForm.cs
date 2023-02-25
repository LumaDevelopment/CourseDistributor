using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseDistributor
{

    /**
     * Handles the logic for the add/rename semester form.
     */
    public partial class AddEditSemesterForm : Form
    {

        // To access main form methods for UI interaction
        private readonly MainForm _mainForm;

        // List of semesters to modify
        private readonly List<Semester> _semesters;

        // Either the index of the semester to edit or the index of the semester to add
        private readonly int _semesterIndex;

        public AddEditSemesterForm(MainForm mainForm, int semesterIndex)
        {
            InitializeComponent();
            this._mainForm = mainForm;
            this._semesters = mainForm.Semesters;
            this._semesterIndex = semesterIndex;
        }

        /**
         * Change the form title and button text based on whether we are adding or editing a semester.
         * If we're editing a semester, fill in the fields with the existing information.
         */
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
                maxCreditHours.Text = _semesters[_semesterIndex].maxCreditHours.ToString();
            }

        }

        /**
         * Called when the submit button is clicked. Verify input, then either add or edit the semester.
         * Last, refresh the semester box in the main form and close this form.
         */
        private void submitButton_Click(object sender, EventArgs e)
        {

            // Make sure the min and max credit hours fields are only integers
            if (!int.TryParse(maxCreditHours.Text, out var maxCreditHoursForSemester))
            {
                MessageBox.Show("Maximum credit hours must be an integer!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(_semesterIndex == _semesters.Count)
            {

                // New semester
                var semester = new Semester(
                    semesterName.Text,
                    int.Parse(maxCreditHours.Text));
                _semesters.Add(semester);

            } else
            {

                // Edit existing semester
                var temp = _semesters[_semesterIndex];
                temp.semesterName = semesterName.Text;
                temp.maxCreditHours = int.Parse(maxCreditHours.Text);

                _semesters[_semesterIndex] = temp;

            }

            // Update UI
            _mainForm.RefreshSemesterBox();

            // Close form
            this.Close();

        }

    }
}
