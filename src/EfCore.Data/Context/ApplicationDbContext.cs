using EfCore.Common;
using EfCore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; } 
       
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //make the configurations
                optionsBuilder.UseSqlServer(StringConstants.DbConnectionString);
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students");
                entity.Property(i => i.Id).HasColumnName("Id").HasColumnType("int").UseIdentityColumn().IsRequired();

                entity.Property(i => i.FirstName).HasColumnName("FirstName").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.LastName).HasColumnName("LastName").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.Number).HasColumnName("Number");
                entity.Property(i => i.BirthDate).HasColumnName("BirthDate");
                entity.Property(i => i.AddressId).HasColumnName("AddressId");
                entity.HasMany(i => i.Books)
                  .WithOne(i => i.Student)
                  .HasForeignKey(i => i.StudentId)
                  .HasConstraintName("student_book_id_fk");

            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teachers");

                entity.Property(i => i.Id).HasColumnName("Id").UseIdentityColumn();
                entity.Property(i => i.FirstName).HasColumnName("FirstName").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.LastName).HasColumnName("LastName").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.BirthDate).HasColumnName("BirthDate");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Courses");

                entity.Property(i => i.Id).HasColumnName("Id").UseIdentityColumn();
                entity.Property(i => i.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.IsActive).HasColumnName("IsActive");
            });

            modelBuilder.Entity<StudentAddress>(entity =>
            {
                entity.ToTable("StudentAddresses");

                entity.Property(i => i.Id).HasColumnName("Id").UseIdentityColumn().ValueGeneratedOnAdd(); // ValueGenerateOnAdd -- controller tarafında AddAsync metodu çalışır çalışmaz bunun id sini otomatik set edecek.
                entity.Property(i => i.City).HasColumnName("City").HasMaxLength(50);
                entity.Property(i => i.District).HasColumnName("District").HasMaxLength(100);
                entity.Property(i => i.Country).HasColumnName("Country").HasMaxLength(50);
                entity.Property(i => i.FullAddress).HasColumnName("FullAddress").HasMaxLength(1000);

                entity.HasOne(i => i.Student)
                    .WithOne(i => i.Address)
                    .HasForeignKey<Student>(i => i.AddressId)
                    .IsRequired(false)
                    .HasConstraintName("student_address_student_id_fk");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
