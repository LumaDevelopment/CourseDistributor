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

        public Course(string courseId, string courseName, int creditHours, SemestersOffered semestersOffered, List<string> prerequisites)
        {
            this.courseId = courseId;
            this.courseName = courseName;
            this.creditHours = creditHours;
            this.semestersOffered = semestersOffered;
            this.prerequisites = prerequisites;
        }

        public override bool Equals(object obj)
        {
            return obj is Course c && c.courseId.Equals(courseId);

        }

        public override string ToString()
        {
            return courseName + " (" + courseId + ")";
        }

    }
}
