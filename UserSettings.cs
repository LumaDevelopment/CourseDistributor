using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CourseDistributor
{
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
