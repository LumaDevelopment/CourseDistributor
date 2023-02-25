using System;
using System.Collections.Generic;

namespace CourseDistributor
{

    public class Course
    {

        public string courseId { get; set; }
        public string courseName { get; set; }
        public int creditHours { get; set; }
        public SemestersOffered semestersOffered { get; set; }
        public List<string> prerequisites { get; set; }
        public List<string> dependents { get; set; }

        public Course(string courseId, string courseName, int creditHours, SemestersOffered semestersOffered, List<string> prerequisites, List<string> dependents)
        {
            this.courseId = courseId;
            this.courseName = courseName;
            this.creditHours = creditHours;
            this.semestersOffered = semestersOffered;
            this.prerequisites = prerequisites;
            this.dependents = dependents;
        }

        public override bool Equals(object obj)
        {
            return obj is Course c && c.courseId.Equals(courseId);

        }

        public override string ToString()
        {
            return courseName + " (" + courseId + ")";
        }


        public int TotalDependents(Dictionary<string, Course> courses, bool origin)
        {
            var totalDependents = 0;

            foreach (var dependencyId in dependents)
            {
                var numOfDependents = courses[dependencyId].TotalDependents(courses, false);

                totalDependents += numOfDependents;
            }

            if (!origin)
            {
                totalDependents++;
            }

            return totalDependents;
        }

        public bool CanBeScheduled(List<string> alreadyScheduled, Semester semester)
        {

            var semesterName = semester.semesterName;

            if (semesterName.Contains("Fall") && !semestersOffered.Equals(SemestersOffered.Fall) &&
                !semestersOffered.Equals(SemestersOffered.Both))
            {
                return false;
            }

            if (semesterName.Equals("Spring") && !semestersOffered.Equals(SemestersOffered.Spring) &&
                !semestersOffered.Equals(SemestersOffered.Both))
            {
                return false;
            }

            foreach (var prereq in prerequisites)
            {
                if (!alreadyScheduled.Contains(prereq))
                {
                    return false;
                }
            }

            return true;
        }

        public int CompareTo(Course other, Dictionary<string, Course> courses)
        {
            // 1 if this course should be taken before the other course
            // -1 if this course should be taken after the other course
            // 0 if this course has no relative value to the other course

            // 1. Number of courses dependent on these courses
            var thisTotalDependents = TotalDependents(courses, true);
            var otherTotalDependents = other.TotalDependents(courses, true);

            if (thisTotalDependents > otherTotalDependents)
            {
                return 1;
            }

            if (otherTotalDependents > thisTotalDependents)
            {
                return -1;
            }

            // 2. Availability of courses
            if (other.semestersOffered.Equals(2) && !semestersOffered.Equals(2))
            {
                return 1;
            }

            if (semestersOffered.Equals(2) && !other.semestersOffered.Equals(2))
            {
                return -1;
            }

            // 3. Number of prerequisites these courses have
            var thisNumOfPrereqs = prerequisites.Count;
            var otherNumOfPrereqs = other.prerequisites.Count;

            if (thisNumOfPrereqs > otherNumOfPrereqs)
            {
                return 1;
            }

            if (otherNumOfPrereqs > thisNumOfPrereqs)
            {
                return -1;
            }

            // 4. Course number
            var isThisCourseNumberAnInt = int.TryParse(courseId.Split(' ')[1], out var thisCourseNumber);
            var isOtherCourseNumberAnInt = int.TryParse(courseId.Split(' ')[1], out var otherCourseNumber);

            if (!(isThisCourseNumberAnInt && isOtherCourseNumberAnInt))
            {
                return 0;
            }

            if (thisCourseNumber < otherCourseNumber)
            {
                return 1;
            }

            if (otherCourseNumber > thisCourseNumber)
            {
                return -1;
            }

            // Out of options:
            return 0;

        }

    }
}
