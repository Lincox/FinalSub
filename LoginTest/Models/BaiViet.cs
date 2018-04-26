namespace LoginTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiViet")]
    public partial class BaiViet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaiViet()
        {
            BinhLuans = new HashSet<BinhLuan>();
        }

        [Key]
        [Column("_idBaiViet")]
        public int C_idBaiViet { get; set; }

        [Column("_idTheLoai")]
        public int? C_idTheLoai { get; set; }

        [Column("_idUserDang")]
        [StringLength(50)]
        public string C_idUserDang { get; set; }

        public string TieuDe { get; set; }

        public string TomTatNoiDung { get; set; }

        public byte[] AnhBia { get; set; }

        public DateTime? NgayDang { get; set; }

        public DateTime? NgayChinhSua { get; set; }

        public string NoiDung { get; set; }

        public int? SoLanXem { get; set; }

        public bool? TrangThaiBaiViet { get; set; }

        public virtual TheLoai TheLoai { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }
    }
}
