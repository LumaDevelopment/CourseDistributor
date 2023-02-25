namespace CourseDistributor
{

    /**
     * Object to represent a semester
     */
    public class Semester
    {

        public string semesterName { get; set; }
        public int maxCreditHours { get; set; }

        public Semester (string semesterName, int maxCreditHours)
        {
            this.semesterName = semesterName;
            this.maxCreditHours = maxCreditHours;
        }

        public override string ToString()
        {
            return semesterName;
        }

    }
}
