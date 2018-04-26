namespace LoginTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class BaiViet_BinhLuanViewModels
    {
        
        public int C_idBaiViet { get; set; }
        
        public int C_idTheLoai { get; set; }

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

        public int C_idBinhLuan { get; set; }

        public string C_idUserDoc { get; set; }

        public DateTime? ThoiDiemBinhLuan { get; set; }
     
        public string NoiDungBL { get; set; }

        public int? C_idBinhLuanGoc { get; set; }

        public int? CapBac { get; set; }

    }
}
