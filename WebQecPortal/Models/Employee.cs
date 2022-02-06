using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQecPortal.Models
{
        public class Employee
        {
        public IEnumerable<Course> Courses { get; set; }
        public virtual ICollection<Institution> Institutions { get; set; }


    }

}