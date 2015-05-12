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
        public string PhotoName { get; set; }
        public DateTime? PhotoDate { get; set; }
        public int PhotoAlbum { get; set; }

        public string UserName { get; set; }

        public Photo( )
		{
			PhotoDate = DateTime.Now;
		}
    }

    
}