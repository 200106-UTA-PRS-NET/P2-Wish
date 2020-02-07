using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Lib.Entites
{
    public partial class Context : DbContext
    {
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Users> users { get; set; }
        public DbSet<Medias> medias { get; set; }

        public DbSet<WishList> wishLists { get; set; }

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
    }
}


