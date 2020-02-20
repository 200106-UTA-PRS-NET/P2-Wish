
namespace MediaWish.Library.Entities
{
#nullable enable
    public partial class WishList
    {
        public int Id { get; set; }

        public string? MediaTitle { get; set; }

        public string? MediaPlatform { get; set; }
        public string? MediaDescription { get; set; }
        public int MediaID { get; set; }

        public virtual Medias mediaTypes { get; set; }
        public virtual Users users { get; set; }
    }
#nullable restore

}
