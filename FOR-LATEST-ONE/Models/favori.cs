//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FOR_LATEST_ONE.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class favori
    {
        public int fovori_id { get; set; }
        public Nullable<int> urun_id { get; set; }
        public Nullable<int> uye_id { get; set; }
    
        public virtual urun urun { get; set; }
        public virtual uye uye { get; set; }
    }
}
