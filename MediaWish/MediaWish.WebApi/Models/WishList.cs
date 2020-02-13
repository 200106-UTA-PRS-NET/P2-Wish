using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWish.WebApi.Models
{
    public class WishList
    {
        public int Id { get; set; }

        public string? MediaTitle { get; set; }

        public string? MediaPlatform { get; set; }
        public string? MediaDescription { get; set; }
        public int MediaID { get; set; }

        public int mediaTypeID { get; set; }
        public int userID { get; set; }

        //public virtual Library.Entities.Medias mediaTypes { get; set; }
        //public virtual Users users { get; set; }
    }

}
