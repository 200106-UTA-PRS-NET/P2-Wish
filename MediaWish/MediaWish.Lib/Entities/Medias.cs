using System;
using System.Collections.Generic;
using System.Text;

namespace MediaWish.Library.Entities
{
    public partial class Medias
    {
        public Medias()
        {
            wishLists = new HashSet<WishList>();
        }



        public int Id { get; set; }

        public string MediaType { get; set; }



        public virtual ICollection<WishList> wishLists { get; set; }

    }
}
