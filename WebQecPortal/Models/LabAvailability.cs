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
    
    public partial class LabAvailability
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LabAvailability()
        {
            this.ComputingBudgets = new HashSet<ComputingBudget>();
        }
    
        public int LabAvailabilityID { get; set; }
        public Nullable<bool> AdvancedLab { get; set; }
        public Nullable<bool> Projectors { get; set; }
        public Nullable<bool> sound { get; set; }
        public Nullable<bool> LAN { get; set; }
        public Nullable<bool> whiteboards { get; set; }
        public Nullable<bool> supportStaff { get; set; }
        public Nullable<bool> Printers { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComputingBudget> ComputingBudgets { get; set; }
    }
}
