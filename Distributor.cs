using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseDistributor
{

    /**
     * The class responsible for distributing courses to semesters.
     */
    public class Distributor
    {

        // The full, always unaltered lists of courses and semesters
        private readonly Dictionary<string, Course> _courses;
        private readonly List<Semester> _semesters;

        /** The dictionary of how courses are assigned **/
        private readonly Dictionary<Semester, List<Course>> _courseDistribution;

        /** List of courses that are not scheduled**/
        private readonly List<Course> _notScheduled;

        /** List of courses that are already scheduled **/
        private readonly List<string> _alreadyScheduled;

        /** The TreeView UI element that will display the course distribution **/
        private readonly TreeView _courseDistributionTreeView;

        public Distributor(Dictionary<string, Course> courses, List<Semester> semesters, TreeView courseDistribution)
        {
            this._courses = courses;
            this._semesters = semesters;

            this._courseDistribution = new Dictionary<Semester, List<Course>>();
            this._notScheduled = new List<Course>();
            this._alreadyScheduled = new List<string>();
            this._courseDistributionTreeView = courseDistribution;
        }

        /**
         * Distributes courses to each semester and updates the UI with the information.
         */
        public void Run()
        {

            // Add all courses to the 'not scheduled' list
            foreach (var course in _courses.Values)
            {
                _notScheduled.Add(course);
            }

            // Sort the unscheduled courses with selection sort and Course.CompareTo()
            var unscheduledCount = _notScheduled.Count;

            for (var i = 0; i < unscheduledCount - 1; i++)
            {
                var maxIndex = i;

                for (var j = i + 1; j < unscheduledCount; j++)
                {
                    if (_notScheduled[j].CompareTo(_notScheduled[maxIndex], _courses) > 0)
                    {
                        maxIndex = j;
                    }
                }

                (_notScheduled[maxIndex], _notScheduled[i]) = (_notScheduled[i], _notScheduled[maxIndex]);

            }

            // Keep running while there are still courses to schedule
            while (_notScheduled.Count > 0)
            {

                // Iterate through until we find a course that can be scheduled
                for (var i = 0; i < _notScheduled.Count; i++)
                {

                    // Find a semester that can fit ithis course
                    Semester semesterToScheduleTo = null;

                    for (int j = 0; j < _semesters.Count; j++)
                    {

                        // If this course's credit hours + the semester's already scheduled credit hours are less than 
                        // or equal to the max credit hours for the semester, we can schedule it
                        if (_notScheduled[i].creditHours + GetSemesterCreditHours(_semesters[j]) <= _semesters[j].maxCreditHours)
                        {
                            semesterToScheduleTo = _semesters[j];
                            break;
                        }

                    }

                    // If we couldn't find a semester to schedule to, break, 
                    // go to next course and try to schedule it.
                    if (semesterToScheduleTo == null)
                    {
                        break;
                    }

                    var alreadyScheduledCopy = new List<string>(_alreadyScheduled);

                    // Remove courses from this semester from the already scheduled list 
                    // so that we don't think we've completed courses that we're taking 
                    // at the same time as this course
                    if (_courseDistribution.ContainsKey(semesterToScheduleTo))
                    {
                        foreach (var course in _courseDistribution[semesterToScheduleTo])
                        {
                            alreadyScheduledCopy.Remove(course.courseId);
                        }
                    }

                    // If we can't schedule this course, continue to the next course
                    if (!_notScheduled[i].CanBeScheduled(alreadyScheduledCopy, semesterToScheduleTo))
                    {
                        continue;
                    }

                    // If we can schedule the course, do so!
                    var courseId = _notScheduled[i].courseId;
                    _notScheduled.RemoveAt(i);
                    ScheduleCourse(semesterToScheduleTo, courseId);

                    Console.WriteLine("Schedule course #" + _alreadyScheduled.Count + " (" + _courses[courseId].ToString() + ") to semester " + semesterToScheduleTo.semesterName);

                    break;

                }

            }

            // We've scheduled as many courses as we can, now 
            // we need to update the UI with the information
            _courseDistributionTreeView.BeginUpdate();
            _courseDistributionTreeView.Nodes.Clear();

            // Loop through every semester
            foreach (var semester in _courseDistribution.Keys)
            {

                var semesterNode = new TreeNode(semester.semesterName);

                // Loop through every course in this semester
                foreach (var course in _courseDistribution[semester])
                {
                    semesterNode.Nodes.Add(course.ToString());
                }

                // Add credit hour information
                semesterNode.Nodes.Add(new TreeNode("Credit Hours: " + GetSemesterCreditHours(semester)));

                _courseDistributionTreeView.Nodes.Add(semesterNode);

            }

            // If we weren't able to schedule every course, let the user know
            if (_notScheduled.Count > 0)
            {
                MessageBox.Show("Was not able to schedule " + _notScheduled.Count + " courses!", "Some Courses Not Scheduled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Update the UI
            _courseDistributionTreeView.EndUpdate();

        }

        /**
         * Schedule the course corresponding to the provided course ID to the provided semester.
         * This is done in the context of the Distributor class, so this means modifying
         * the schedule lists, course distribution, etc.
         */
        private void ScheduleCourse(Semester semester, string courseId)
        {

            Course course = _courses[courseId];

            // Remove the course from the not scheduled list and add it to the already scheduled list
            _notScheduled.Remove(course);
            _alreadyScheduled.Add(courseId);

            // Try to get the list of courses for the semester
            _courseDistribution.TryGetValue(semester, out List<Course> coursesForSemester);

            if (coursesForSemester == null)
            {
                // If there are no courses for this semester, create a new list
                coursesForSemester = new List<Course>();
            }

            // Add the course to the list of courses for this semester
            coursesForSemester.Add(course);

            _courseDistribution[semester] = coursesForSemester;

        }

        /**
         * Return the total amount of credit hours scheduled to the semester.
         */
        private int GetSemesterCreditHours(Semester semester)
        {
            var creditHours = 0;

            // If there is no existing list for this semester, return 0
            if (!_courseDistribution.ContainsKey(semester))
            {
                return creditHours;
            }

            // Loop through every course in the semester and add its credit hours to the total
            foreach (var course in _courseDistribution[semester])
            {
                creditHours += course.creditHours;
            }

            return creditHours;
        }

    }
}
