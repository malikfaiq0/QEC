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
    
    public partial class ComputerRatio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ComputerRatio()
        {
            this.ComputingBudgets = new HashSet<ComputingBudget>();
        }
    
        public int ComputerRatioID { get; set; }
        public Nullable<int> RatioYearlyBudgetID { get; set; }
    
        public virtual RatioYearlyBudget RatioYearlyBudget { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComputingBudget> ComputingBudgets { get; set; }
    }
}
