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
    
    public partial class Donvi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Donvi()
        {
            this.Congchungvien = new HashSet<Congchungvien>();
            this.Nguoichungthuc = new HashSet<Nguoichungthuc>();
            this.User = new HashSet<User>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<int> Type { get; set; }
        public string Madonvi { get; set; }
        public string Tendonvi { get; set; }
        public string Diachi { get; set; }
        public Nullable<int> LoaivbdvthID { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Congchungvien> Congchungvien { get; set; }
        public virtual LoaiVBDVTH LoaiVBDVTH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nguoichungthuc> Nguoichungthuc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User { get; set; }
    }
}