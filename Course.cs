using System.Collections.Generic;

namespace CourseDistributor
{
    internal class Course
    {

        public string courseId;
        public string courseName;
        public int creditHours;
        public SemestersOffered semestersOffered;
        public List<Course> prerequisites;

        public Course(string courseId, string courseName, int creditHours, SemestersOffered semestersOffered, List<Course> prerequisites)
        {
            this.courseId = courseId;
            this.courseName = courseName;
            this.creditHours = creditHours;
            this.semestersOffered = semestersOffered;
            this.prerequisites = prerequisites;
        }

        public override bool Equals(object obj)
        {

            if (obj == null) return false;

            if (!(obj is Course)) return false;

            Course c = (Course)obj;
            return c.courseId.Equals(courseId);

        }

        public override string ToString()
        {
            return courseName + " (" + courseId + ")";
        }

    }
}
