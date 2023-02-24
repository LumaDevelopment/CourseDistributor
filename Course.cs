using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Json;

namespace CourseDistributor
{

    public class Course
    {

        public string courseId { get; set; }
        public string courseName { get; set; }
        public int creditHours { get; set; }
        public SemestersOffered semestersOffered { get; set; }
        public List<String> prerequisites { get; set; }

        public Course(string courseId, string courseName, int creditHours, SemestersOffered semestersOffered, List<String> prerequisites)
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
