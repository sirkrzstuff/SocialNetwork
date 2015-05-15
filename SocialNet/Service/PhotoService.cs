using SocialNet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialNet.Models;

namespace SocialNet.Service
{
    public class PhotoService
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public IEnumerable<Photo> GetPhotosFromUserName(string userName)
        {
            var model = (from photos in db.Photos
                         where photos.UserName == userName
                         orderby photos.PhotoDate
                         select photos).ToList();
            return model;
        }

        public IEnumerable<Photo> GetAllPhotos()
        {
            var model = (from photos in db.Photos
                         orderby photos.PhotoDate
                         select photos).ToList();
            return model;
        }

    }
}