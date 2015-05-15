using SocialNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNet.ViewModels
{
    public class Photo
    {

        public int Id { get; set; }
        public string PhotoCaption { get; set; }
        public string PhotoUrl { get; set; }
        public string UserName { get; set; }
        public DateTime? PhotoDate { get; set; }
        public int PhotoAlbum { get; set; }

        //public virtual ApplicationUser Author { get; set; }
        public virtual User User { get; set; }

        public Photo( )
		{
            //UserName = Author.UserName
			PhotoDate = DateTime.Now;
		}
    }

   

    
}