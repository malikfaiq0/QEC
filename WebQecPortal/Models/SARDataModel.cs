using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQecPortal.Models
{
    public class SARDataModel
    {
        public Term Terms { get; set; }

        public Program Programs { get; set; }

        public Course Courses { get; set; }
    }
    public class ECourseModel
    {
        public Term Terms { get; set; }

        public Program Programs { get; set; }

        public Course Courses { get; set; }
        public Instructor Instructors { get; set; }
        public Status Statuses { get; set; }
        public Department Departments { get; set; }

    }
}