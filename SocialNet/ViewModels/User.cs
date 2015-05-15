using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialNet.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace SocialNet.ViewModels
{
    public class User
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        [Required]   
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public bool IsMale { get; set; }
        public bool IsSingle { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string AboutUser { get; set; }

        public virtual ICollection<Groups> GroupList { get; set; }
        public virtual ICollection<Photo> PhotoList { get; set; }
        public virtual ICollection<UserStatus> UserStatusList { get; set; }
        public virtual ICollection<User> FriendList { get; set; }

        public ICollection<Messenger> Messengers { get; set; }
       


    }
}