//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectdotNET
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblBILL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblBILL()
        {
            this.tblBILL_INFO = new HashSet<tblBILL_INFO>();
        }
    
        public int BillID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<int> TableID { get; set; }
        public string Status { get; set; }
    
        public virtual tblEMPLOYEE tblEMPLOYEE { get; set; }
        public virtual tblTABLE tblTABLE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblBILL_INFO> tblBILL_INFO { get; set; }
    }
}
