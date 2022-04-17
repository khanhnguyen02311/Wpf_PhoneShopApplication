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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Detail_Bill = new HashSet<Detail_Bill>();
        }
    
        public string Name { get; set; }
        public string Id { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Price { get; set; }
        public int InitialAmount { get; set; }
        public int CurrentAmount { get; set; }
        public string Description { get; set; }
        public string IdProductType { get; set; }
        public string ImagePath { get; set; }
        public decimal Capital { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detail_Bill> Detail_Bill { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}
