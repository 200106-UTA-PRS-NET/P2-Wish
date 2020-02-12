
namespace MediaWish.Library.Entities
{
    public partial class WishList
    {
        public int Id { get; set; }

        //public int? UserId { get; set; }

        //public int? MediaId { get; set; }

        public string? MediaTitle { get; set; }

        public string? MediaPlatform { get; set; }
        public string? MediaDescription { get; set; }
        public int MediaID { get; set; }

        public virtual Medias mediaTypes { get; set; }
        public virtual Users users { get; set; }
    }
}
