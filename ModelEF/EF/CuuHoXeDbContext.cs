using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ModelEF.EF
{
	public partial class CuuHoXeDbContext : DbContext
	{
		public CuuHoXeDbContext()
			: base("name=CuuHoXeDbContext")
		{
		}

		public virtual DbSet<ChiTietSuDungDV> ChiTietSuDungDVs { get; set; }
		public virtual DbSet<CoSoDichVu> CoSoDichVus { get; set; }
		public virtual DbSet<DichVu> DichVus { get; set; }
		public virtual DbSet<GiayPhepCSDV> GiayPhepCSDVs { get; set; }
		public virtual DbSet<HinhAnhDV> HinhAnhDVs { get; set; }
		public virtual DbSet<LePhi> LePhis { get; set; }
		public virtual DbSet<SuDungDichVu> SuDungDichVus { get; set; }
		public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
		public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ChiTietSuDungDV>()
				.Property(e => e.MaSDDV)
				.IsUnicode(false);

			modelBuilder.Entity<ChiTietSuDungDV>()
				.Property(e => e.MaDV)
				.IsUnicode(false);

			modelBuilder.Entity<ChiTietSuDungDV>()
				.Property(e => e.GiaDV)
				.HasPrecision(18, 0);

			modelBuilder.Entity<CoSoDichVu>()
				.Property(e => e.MaNCC)
				.IsUnicode(false);

			modelBuilder.Entity<CoSoDichVu>()
				.Property(e => e.TenTK)
				.IsUnicode(false);

			modelBuilder.Entity<CoSoDichVu>()
				.Property(e => e.TrangThaiDK)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<DichVu>()
				.Property(e => e.MaDV)
				.IsUnicode(false);

			modelBuilder.Entity<DichVu>()
				.Property(e => e.GiaDV)
				.HasPrecision(18, 0);

			modelBuilder.Entity<DichVu>()
				.Property(e => e.TrangThai)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<DichVu>()
				.Property(e => e.MaNCC)
				.IsUnicode(false);

			modelBuilder.Entity<DichVu>()
				.HasMany(e => e.ChiTietSuDungDVs)
				.WithRequired(e => e.DichVu)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<GiayPhepCSDV>()
				.Property(e => e.MaAnh)
				.IsUnicode(false);

			modelBuilder.Entity<GiayPhepCSDV>()
				.Property(e => e.MaNCC)
				.IsUnicode(false);

			modelBuilder.Entity<HinhAnhDV>()
				.Property(e => e.MaAnh)
				.IsUnicode(false);

			modelBuilder.Entity<HinhAnhDV>()
				.Property(e => e.MaDV)
				.IsUnicode(false);

			modelBuilder.Entity<LePhi>()
				.Property(e => e.MaLP)
				.IsUnicode(false);

			modelBuilder.Entity<LePhi>()
				.Property(e => e.MaNCC)
				.IsUnicode(false);

			modelBuilder.Entity<LePhi>()
				.Property(e => e.TrangThai)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<SuDungDichVu>()
				.Property(e => e.MaSDDV)
				.IsUnicode(false);

			modelBuilder.Entity<SuDungDichVu>()
				.Property(e => e.TenTK)
				.IsUnicode(false);

			modelBuilder.Entity<SuDungDichVu>()
				.Property(e => e.TrangThai)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<SuDungDichVu>()
				.Property(e => e.MaNCC)
				.IsUnicode(false);

			modelBuilder.Entity<SuDungDichVu>()
				.HasMany(e => e.ChiTietSuDungDVs)
				.WithRequired(e => e.SuDungDichVu)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<TaiKhoan>()
				.Property(e => e.TenTK)
				.IsUnicode(false);

			modelBuilder.Entity<TaiKhoan>()
				.Property(e => e.MatKhau)
				.IsUnicode(false);

			modelBuilder.Entity<TaiKhoan>()
				.Property(e => e.PhanQuyen)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<TaiKhoan>()
				.Property(e => e.SoDienThoai)
				.IsUnicode(false);

			modelBuilder.Entity<TaiKhoan>()
				.Property(e => e.Email)
				.IsUnicode(false);

			modelBuilder.Entity<TaiKhoan>()
				.HasMany(e => e.CoSoDichVus)
				.WithRequired(e => e.TaiKhoan)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<TaiKhoan>()
				.HasMany(e => e.SuDungDichVus)
				.WithRequired(e => e.TaiKhoan)
				.WillCascadeOnDelete(false);
		}
	}
}
