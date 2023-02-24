using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseDistributor
{
    internal static class Program
    {

        public static Dictionary<string, Course> courses = new Dictionary<string, Course>();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Course exampleCourse = new Course("CSE 1002", "Fundamentals of Software Development 2", 4, SemestersOffered.BOTH, new List<Course>());
            courses.Add("CSE 1002", exampleCourse);

            Application.Run(new AddEditCourseForm("CSE 2010"));
        }

        public static SemestersOffered semestersOfferedFromUI(bool fall, bool spring)
        {
            if (fall && spring)
            {
                return SemestersOffered.BOTH;
            }
            else if (fall)
            {
                return SemestersOffered.FALL;
            }
            else if (spring)
            {
                return SemestersOffered.SPRING;
            }
            else
            {
                throw new ArgumentException("At least one of the booleans must be true");
            }
        }

    }
}
