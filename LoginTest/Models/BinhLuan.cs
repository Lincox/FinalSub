namespace LoginTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BinhLuan()
        {
            BinhLuan1 = new HashSet<BinhLuan>();
        }

        [Key]
        [Column("_idBinhLuan")]
        public int C_idBinhLuan { get; set; }

        [Column("_idUserDoc")]
        [StringLength(50)]
        public string C_idUserDoc { get; set; }

        public DateTime? ThoiDiemBinhLuan { get; set; }

        [Column("_idBaiViet")]
        public int? C_idBaiViet { get; set; }

        public string NoiDung { get; set; }

        [Column("_idBinhLuanGoc")]
        public int? C_idBinhLuanGoc { get; set; }

        public int? CapBac { get; set; }

        public virtual BaiViet BaiViet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuan1 { get; set; }

        public virtual BinhLuan BinhLuan2 { get; set; }

        public virtual User User { get; set; }
    }
}
