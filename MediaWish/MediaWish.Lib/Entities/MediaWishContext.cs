using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaWish.Library.Entities
{
    public partial class MediaWishContext : DbContext
    {
        public MediaWishContext()
        {

        }
        public MediaWishContext(DbContextOptions<MediaWishContext> options) : base(options)
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
                        optionsBuilder.UseSqlServer("Server=DESKTOP-9K2Q9T1\\SQLEXPRESS;Database=MediaWishDB; Trusted_Connection=true");
                    }

                }
            }
        }
    }
}
