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
    
    public partial class Canhan
    {
        public int ID { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string Hoten { get; set; }
        public System.DateTime Ngaysinh { get; set; }
        public decimal SoCMND { get; set; }
        public System.DateTime NgaycapCMND { get; set; }
        public string NoicapCMND { get; set; }
        public string Hokhau { get; set; }
        public string Diachilienhe { get; set; }
        public Nullable<decimal> Sodienthoai { get; set; }
        public Nullable<decimal> SoTKNH { get; set; }
        public string Nganhang { get; set; }
        public string Masothue { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<int> LoaiqhID { get; set; }
        public int IsActive { get; set; }
    
        public virtual LoaiQH LoaiQH { get; set; }
    }
}
