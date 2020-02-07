using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestData.Lib.Data;

namespace TestProject.Data
{
    public partial class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public virtual DbSet<Users> Users {get; set;}
        public virtual DbSet<Medias> Medias { get; set; }
        public virtual DbSet<WishLists> WishLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            if (!optionsBuilder.IsConfigured)

            {
                {
                    if (!optionsBuilder.IsConfigured)
                    {
                        optionsBuilder.UseSqlServer("Server=DESKTOP-9K2Q9T1\\SQLEXPRESS;Database=TestDB; Trusted_Connection=true");
                    }

                }
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>

            {

                entity.ToTable("Users", "TestProject");



                entity.HasIndex(e => e.Username)

                    .HasName("UQ__Users")

                    .IsUnique();



                entity.Property(e => e.Id).HasColumnName("id");



                entity.Property(e => e.Name)

                    .IsRequired()

                    .HasColumnName("name")

                    .HasMaxLength(50)

                    .IsUnicode(false);



                entity.Property(e => e.Password)

                    .IsRequired()

                    .HasColumnName("password")

                    .HasMaxLength(20)

                    .IsUnicode(false);



                entity.Property(e => e.Username)

                    .IsRequired()

                    .HasColumnName("username")

                    .HasMaxLength(20)

                    .IsUnicode(false);

                entity.Property(e => e.Email)

                    .IsRequired()

                    .HasColumnName("email")

                    .HasMaxLength(320)

                    .IsUnicode(false);

            });

          //  OnModelCreatingPartial(modelBuilder);

        }

    }
}
