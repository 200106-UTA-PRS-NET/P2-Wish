using System;
using System.Collections.Generic;
using System.Text;

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

        public virtual Medias medias { get; set; }
        public virtual Users users { get; set; }
    }
}
