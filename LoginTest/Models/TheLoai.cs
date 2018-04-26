namespace LoginTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TheLoai")]
    public partial class TheLoai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TheLoai()
        {
            BaiViets = new HashSet<BaiViet>();
            TheLoai11 = new HashSet<TheLoai>();
        }

        [Key]
        [Column("_idTheLoai")]
        public int C_idTheLoai { get; set; }

        [Column("TheLoai")]
        public string TheLoai1 { get; set; }

        [Column("_idTheLoaiCha")]
        public int? C_idTheLoaiCha { get; set; }

        public string TheLoaiCha { get; set; }

        [Column("_idUser")]
        [StringLength(50)]
        public string C_idUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiViet> BaiViets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TheLoai> TheLoai11 { get; set; }

        public virtual TheLoai TheLoai2 { get; set; }

        public virtual User User { get; set; }
    }
}
