using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AllAboutFood.Models.EF
{
    public partial class AllAboutFoodContext : DbContext
    {
        public AllAboutFoodContext()
        {
        }

        public AllAboutFoodContext(DbContextOptions<AllAboutFoodContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Restaurant> Restaurant { get; set; }
        public virtual DbSet<RestaurantLanguage> RestaurantLanguage { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Table> Table { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=YUMINI;Database=AllAboutFood;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Restaurant_Item");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Lat).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Long).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RestaurantLanguage>(entity =>
            {
                entity.HasKey(e => new { e.RestaurantId, e.LanguageId });

                entity.ToTable("Restaurant_Language");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.RestaurantLanguage)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_Restaurant_Language_Language");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.RestaurantLanguage)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("FK_Restaurant_Language_Restaurant");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.RestaurantId)
                    .HasName("PK_ResHour");

                entity.Property(e => e.RestaurantId).ValueGeneratedNever();

                entity.HasOne(d => d.Restaurant)
                    .WithOne(p => p.Schedule)
                    .HasForeignKey<Schedule>(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResHour_Restaurant");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Table)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResConfiguration_Restaurant");
            });
        }
    }
}
