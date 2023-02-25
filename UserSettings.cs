using System.Configuration;

namespace CourseDistributor
{

    /**
     * Establishes the ability to save our courses and semesters to application settings.
     */
    internal class UserSettings : ApplicationSettingsBase
    {

        [UserScopedSetting()]
        public string Courses
        {
            get
            {
                return ((string)this["Courses"]);
            }
            set
            {
                this["Courses"] = (string)value;
            }
        }

        [UserScopedSetting()]
        public string Semesters
        {
            get
            {
                return ((string)this["Semesters"]);
            }
            set
            {
                this["Semesters"] = (string)value;
            }
        }

    }
}
