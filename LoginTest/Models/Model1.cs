namespace LoginTest.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<BaiViet> BaiViets { get; set; }
        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<LichSuNapTien> LichSuNapTiens { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiViet>()
                .Property(e => e.C_idUserDang)
                .IsUnicode(false);

            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.C_idUserDoc)
                .IsUnicode(false);

            modelBuilder.Entity<BinhLuan>()
                .HasMany(e => e.BinhLuan1)
                .WithOptional(e => e.BinhLuan2)
                .HasForeignKey(e => e.C_idBinhLuanGoc);

            modelBuilder.Entity<LichSuNapTien>()
                .Property(e => e.C_idUserDang)
                .IsUnicode(false);

            modelBuilder.Entity<LichSuNapTien>()
                .Property(e => e.C_idUserDoc)
                .IsUnicode(false);

            modelBuilder.Entity<LichSuNapTien>()
                .Property(e => e.Seri)
                .IsUnicode(false);

            modelBuilder.Entity<LichSuNapTien>()
                .Property(e => e.MaSMS)
                .IsUnicode(false);

            modelBuilder.Entity<TheLoai>()
                .Property(e => e.C_idUser)
                .IsUnicode(false);

            modelBuilder.Entity<TheLoai>()
                .HasMany(e => e.TheLoai11)
                .WithOptional(e => e.TheLoai2)
                .HasForeignKey(e => e.C_idTheLoaiCha);

            modelBuilder.Entity<User>()
                .Property(e => e.C_idUser)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Usename)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.BaiViets)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.C_idUserDang);

            modelBuilder.Entity<User>()
                .HasMany(e => e.BinhLuans)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.C_idUserDoc);

            modelBuilder.Entity<User>()
                .HasMany(e => e.LichSuNapTiens)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.C_idUserDang);

            modelBuilder.Entity<User>()
                .HasMany(e => e.LichSuNapTiens1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.C_idUserDoc);
        }
    }
}
