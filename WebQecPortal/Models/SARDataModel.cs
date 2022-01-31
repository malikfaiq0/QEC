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
    public class SARList
    {
        public StudentCourseReg StudentCourseRegs { get; set; }
        public AssignmentReport AssignmentReports { get; set; }
        public QuizReport QuizReports { get; set; }

        public ProjectReport ProjectReports { get; set; }

        public Quiz Quizs { get; set; }
        public Project Projects { get; set; }
        public Assignment Assignments
        {
            set; get;
        }
        public Course Courses { get; set; }
        public Student Students { get; set; }
    }
}