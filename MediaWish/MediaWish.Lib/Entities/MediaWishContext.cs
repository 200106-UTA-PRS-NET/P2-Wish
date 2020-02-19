using Microsoft.EntityFrameworkCore;

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
                        optionsBuilder.UseSqlServer("Server=tcp:mediawishserver.database.windows.net,1433;Initial Catalog=MediaWishDB;Persist Security Info=False;User ID=Steven;Password=Revature123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                    }

                }
            }
        }
    }
}
