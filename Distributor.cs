using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseDistributor
{
    public class Distributor
    {

        private readonly Dictionary<string, Course> _courses;
        private readonly List<Semester> _semesters;

        private readonly Dictionary<Semester, List<Course>> _courseDistribution;
        private readonly List<Course> _notScheduled;
        private readonly List<string> _alreadyScheduled;
        private TreeView _courseDistributionTreeView;

        public Distributor(Dictionary<string, Course> courses, List<Semester> semesters, TreeView courseDistribution)
        {
            this._courses = courses;
            this._semesters = semesters;

            this._courseDistribution = new Dictionary<Semester, List<Course>>();
            this._notScheduled = new List<Course>();
            this._alreadyScheduled = new List<string>();
            this._courseDistributionTreeView = courseDistribution;
        }

        public void Run()
        {

            foreach (var course in _courses.Values)
            {
                _notScheduled.Add(course);
            }

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

            while (_notScheduled.Count > 0)
            {

                for (var i = 0; i < _notScheduled.Count; i++)
                {

                    var semesterIndex = 0;
                    Semester semesterToScheduleTo = null;

                    while (semesterToScheduleTo == null)
                    {

                        if (semesterIndex >= _semesters.Count)
                        {
                            break;
                        }

                        if (_notScheduled[i].creditHours + GetSemesterCreditHours(_semesters[semesterIndex]) <= _semesters[semesterIndex].maxCreditHours)
                        {
                            semesterToScheduleTo = _semesters[semesterIndex];
                            break;
                        }

                        semesterIndex++;

                    }

                    var alreadyScheduledCopy = new List<string>(_alreadyScheduled);

                    if (_courseDistribution.ContainsKey(semesterToScheduleTo))
                    {
                        foreach (var course in _courseDistribution[semesterToScheduleTo])
                        {
                            alreadyScheduledCopy.Remove(course.courseId);
                        }
                    }

                    if (!_notScheduled[i].CanBeScheduled(alreadyScheduledCopy, semesterToScheduleTo))
                    {
                        continue;
                    }

                    var courseId = _notScheduled[i].courseId;
                    _notScheduled.RemoveAt(i);
                    ScheduleCourse(_semesters[semesterIndex], courseId);

                    break;

                }

            }

            _courseDistributionTreeView.BeginUpdate();
            _courseDistributionTreeView.Nodes.Clear();

            foreach (var semester in _courseDistribution.Keys)
            {

                var semesterNode = new TreeNode(semester.semesterName);

                foreach (var course in _courseDistribution[semester])
                {
                    semesterNode.Nodes.Add(course.courseId);
                }

                semesterNode.Nodes.Add(new TreeNode("Credit Hours: " + GetSemesterCreditHours(semester)));

                _courseDistributionTreeView.Nodes.Add(semesterNode);

            }

            if (_notScheduled.Count > 0)
            {
                MessageBox.Show("Was not able to schedule " + _notScheduled.Count + " courses!", "Some Courses Not Scheduled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _courseDistributionTreeView.EndUpdate();

        }

        public void ScheduleCourse(Semester semester, string courseId)
        {

            Course course = _courses[courseId];
            _notScheduled.Remove(course);
            _alreadyScheduled.Add(courseId);

            _courseDistribution.TryGetValue(semester, out List<Course> coursesForSemester);

            if (coursesForSemester == null)
            {
                coursesForSemester = new List<Course>();
            }

            coursesForSemester.Add(course);

            _courseDistribution[semester] = coursesForSemester;

        }

        private int GetSemesterCreditHours(Semester semester)
        {
            var creditHours = 0;

            if (!_courseDistribution.ContainsKey(semester))
            {
                return creditHours;
            }

            foreach (var course in _courseDistribution[semester])
            {
                creditHours += course.creditHours;
            }

            return creditHours;
        }

        // Sort by highest number of courses dependent on this course and lowest number of prerequisites

    }
}
