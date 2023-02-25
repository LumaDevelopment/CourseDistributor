using System;
using System.Collections.Generic;

namespace CourseDistributor
{

    /**
     * Object to represent a course
     */
    public class Course
    {

        // Course ID, the unique identifier for a course
        public string courseId { get; set; }
        public string courseName { get; set; }
        public int creditHours { get; set; }

        // An enum representing the semester(s) a course is offered
        public SemestersOffered semestersOffered { get; set; }

        // A list of course IDs for the courses that are prerequisites for this course
        public List<string> prerequisites { get; set; }

        // A list of course IDs for the courses that have this course as a prerequisite
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

        public override string ToString()
        {
            return courseName + " (" + courseId + ")";
        }

        /**
         * Count the total number of courses that depend on this course (including by proxy,
         * a.k.a. a course which relies on a course which relies on this course)
         */
        public int TotalDependents(Dictionary<string, Course> courses, bool origin)
        {
            var totalDependents = 0;

            // For all depends of this course, count the number of courses that depend on them
            foreach (var dependencyId in dependents)
            {
                var numOfDependents = courses[dependencyId].TotalDependents(courses, false);

                totalDependents += numOfDependents;
            }

            // If this is not the course the function was originally called on, 
            // add one to the total dependents
            if (!origin)
            {
                totalDependents++;
            }

            return totalDependents;
        }

        /**
         * Return whether or not this course can be scheduled in the given semester,
         * with the given list of courses already having been 'completed' (scheduled)
         */
        public bool CanBeScheduled(List<string> alreadyScheduled, Semester semester)
        {

            var semesterName = semester.semesterName;

            // Check if the course is offered in the given semester

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

            // Check if all prerequisites for this course have been completed
            foreach (var prereq in prerequisites)
            {
                if (!alreadyScheduled.Contains(prereq))
                {
                    return false;
                }
            }

            return true;

        }

        /**
         * Returns 1 if this course should be taken before the other course
         * Returns -1 if this course should be taken after the other course
         * 0 if this course has no relative value to the other course
         */
        public int CompareTo(Course other, Dictionary<string, Course> courses)
        {

            // 1. Number of courses dependent on these courses
            // The course with the most dependents should be taken first
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
            // The course that is less frequently offered should be taken first
            if (other.semestersOffered.Equals(2) && !semestersOffered.Equals(2))
            {
                return 1;
            }

            if (semestersOffered.Equals(2) && !other.semestersOffered.Equals(2))
            {
                return -1;
            }

            // 3. Number of prerequisites these courses have
            // The course with the most prerequisites should be taken first
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
            // The course with the lower course number should be taken first
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

            // These courses are the same in all ways that matter to us
            // Highly unlikely this happens.
            return 0;

        }

    }
}
