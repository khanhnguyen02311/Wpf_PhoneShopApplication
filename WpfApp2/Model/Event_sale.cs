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
    
    public partial class Event_sale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event_sale()
        {
            this.Detail_Bill = new HashSet<Detail_Bill>();
        }
    
        public string Name { get; set; }
        public string Id { get; set; }
        public System.DateTime Datebegin { get; set; }
        public System.DateTime Datefinish { get; set; }
        public int Percent_sale { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detail_Bill> Detail_Bill { get; set; }
    }
}