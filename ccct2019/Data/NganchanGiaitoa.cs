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
    
    public partial class NganchanGiaitoa
    {
        public int ID { get; set; }
        public int LoaiVB { get; set; }
        public string SoGCN { get; set; }
        public Nullable<System.DateTime> Ngaycap { get; set; }
        public string Noicap { get; set; }
        public string Chusohuu { get; set; }
        public string Diachichusohuu { get; set; }
        public string Thuadatso { get; set; }
        public string Bandoso { get; set; }
        public string Diachithuadat { get; set; }
        public string Dientich { get; set; }
        public string Sudungchung { get; set; }
        public string Sudungrieng { get; set; }
        public string Mucdichsudung { get; set; }
        public Nullable<System.DateTime> Ngaygiaitoa { get; set; }
        public string Thoihansudung { get; set; }
        public string Nguongoc { get; set; }
        public string Sokyhieu { get; set; }
        public Nullable<System.DateTime> NgayVB { get; set; }
        public string Trichyeu { get; set; }
        public string Noigui { get; set; }
        public string Filedinhkem { get; set; }
        public string Lydo { get; set; }
        public Nullable<int> Demncgt { get; set; }
        public Nullable<int> UserID { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int IsActive { get; set; }
    
        public virtual User User { get; set; }
    }
}