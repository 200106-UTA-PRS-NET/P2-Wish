namespace MediaWish.WebApi.Models
{
    #nullable enable
    public class WishList
    {
        public int Id { get; set; }
        public string? MediaTitle { get; set; }
        public string? MediaPlatform { get; set; }
        public string? MediaDescription { get; set; }
        public int MediaID { get; set; }
        public int mediaTypeID { get; set; }
        public int userID { get; set; }
    }
    #nullable restore
}