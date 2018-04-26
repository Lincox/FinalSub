namespace LoginTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichSuNapTien")]
    public partial class LichSuNapTien
    {
        [Key]
        [Column("_idLichSuNapTien")]
        public int C_idLichSuNapTien { get; set; }

        [Column("_idUserDang")]
        [StringLength(50)]
        public string C_idUserDang { get; set; }

        [Column("_idUserDoc")]
        [StringLength(50)]
        public string C_idUserDoc { get; set; }

        public DateTime? NgayNop { get; set; }

        public double? MenhGia { get; set; }

        public int? ThoiHan { get; set; }

        [StringLength(50)]
        public string Seri { get; set; }

        [StringLength(50)]
        public string MaSMS { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
