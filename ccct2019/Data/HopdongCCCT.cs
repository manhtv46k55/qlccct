//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ccct2019.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class HopdongCCCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HopdongCCCT()
        {
            this.Mauhopdong = new HashSet<Mauhopdong>();
        }
    
        public int ID { get; set; }
        public string Tenhopdong { get; set; }
        public int IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mauhopdong> Mauhopdong { get; set; }
    }
}