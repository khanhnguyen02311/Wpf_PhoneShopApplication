//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp2.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            this.Detail_Bill = new HashSet<Detail_Bill>();
        }
    
        public string Id { get; set; }
        public string IdCustomer { get; set; }
        public System.DateTime Date_output_bill { get; set; }
        public string Status { get; set; }
        public int IdUsers { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detail_Bill> Detail_Bill { get; set; }
    }
}
