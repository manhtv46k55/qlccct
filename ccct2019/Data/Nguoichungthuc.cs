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
    
    public partial class Nguoichungthuc
    {
        public int ID { get; set; }
        public string Hoten { get; set; }
        public string Chucvu { get; set; }
        public string Sodienthoai { get; set; }
        public string Email { get; set; }
        public Nullable<int> Donvi { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int IsActive { get; set; }
    
        public virtual Donvi Donvi1 { get; set; }
    }
}