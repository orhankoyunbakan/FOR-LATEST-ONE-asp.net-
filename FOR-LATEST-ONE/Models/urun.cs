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
    
    public partial class urun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public urun()
        {
            this.favoris = new HashSet<favori>();
            this.yorums = new HashSet<yorum>();
        }
    
        public int urun_id { get; set; }
        public string ad { get; set; }
        public Nullable<int> menu_id { get; set; }
        public Nullable<int> kategori_id { get; set; }
        public string aciklama { get; set; }
        public string yonetmen { get; set; }
        public Nullable<int> yapim_yili { get; set; }
        public string oyuncular { get; set; }
        public string foto_url { get; set; }
        public string yayin_kanal { get; set; }
        public Nullable<int> bolum_sayisi { get; set; }
        public string son_surum { get; set; }
        public string yukleme_sayisi { get; set; }
        public string boyut { get; set; }
        public string yayin_evi { get; set; }
        public Nullable<int> sayfa_sayisi { get; set; }
        public string sozler { get; set; }
        public string sanatci { get; set; }
        public string tur { get; set; }
        public string yazar { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<favori> favoris { get; set; }
        public virtual kategori kategori { get; set; }
        public virtual menu menu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<yorum> yorums { get; set; }
    }
}
