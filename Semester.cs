using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDistributor
{
    public class Semester
    {

        public string semesterName { get; set; }
        public int minCreditHours { get; set; }
        public int maxCreditHours { get; set; }

        public Semester (string semesterName, int minCreditHours, int maxCreditHours)
        {
            this.semesterName = semesterName;
            this.minCreditHours = minCreditHours;
            this.maxCreditHours = maxCreditHours;
        }

        public override string ToString()
        {
            return semesterName;
        }

    }
}
