//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebQecPortal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentSAR
    {
        public int StudentSARID { get; set; }
        public Nullable<int> CourseID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<int> AssignmentNumber { get; set; }
        public Nullable<int> QuizNumber { get; set; }
        public Nullable<int> Project { get; set; }
        public Nullable<int> AssignMarks { get; set; }
        public Nullable<int> QuizMarks { get; set; }
        public int ProjectMarks { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
