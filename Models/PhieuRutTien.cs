//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLSTK.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhieuRutTien
    {
        public int MaPhieuRut { get; set; }
        public string MaSTK { get; set; }
        public int SoTienRut { get; set; }
        public System.DateTime NgayRut { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
