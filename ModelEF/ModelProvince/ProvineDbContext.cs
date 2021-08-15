using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ModelEF.ModelProvince
{
	public partial class ProvineDbContext : DbContext
	{
		public ProvineDbContext()
			: base("name=ProvineDbContext")
		{
		}

		public virtual DbSet<District> Districts { get; set; }
		public virtual DbSet<Province> Provinces { get; set; }
		public virtual DbSet<Ward> Wards { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<District>()
				.HasMany(e => e.Wards)
				.WithRequired(e => e.District)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Province>()
				.HasMany(e => e.Districts)
				.WithRequired(e => e.Province)
				.WillCascadeOnDelete(false);
		}
	}
}
