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
    
    public partial class Mauhopdong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mauhopdong()
        {
            this.Chitiethopdong = new HashSet<Chitiethopdong>();
            this.Hopdongkhac = new HashSet<Hopdongkhac>();
        }
    
        public int ID { get; set; }
        public string Tenmauhopdong { get; set; }
        public Nullable<int> HopdongccctID { get; set; }
        public int IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitiethopdong> Chitiethopdong { get; set; }
        public virtual HopdongCCCT HopdongCCCT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hopdongkhac> Hopdongkhac { get; set; }
    }
}
