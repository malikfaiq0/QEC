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
    
    public partial class DepComputingBudget
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DepComputingBudget()
        {
            this.ComputingBudgets = new HashSet<ComputingBudget>();
            this.Financials = new HashSet<Financial>();
        }
    
        public int DepComputingBudgetID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<int> DCYearlyBudgetID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComputingBudget> ComputingBudgets { get; set; }
        public virtual DCYearlyBudget DCYearlyBudget { get; set; }
        public virtual Department Department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Financial> Financials { get; set; }
    }
}
