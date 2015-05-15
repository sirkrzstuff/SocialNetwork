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
        [Display(Name = "Email")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Display(Name = "Gender")]
        public bool IsMale { get; set; }
        [Display(Name = "Relationship status")]
        public bool IsSingle { get; set; }
        [Display(Name = "Birth date")]
        public DateTime? DateOfBirth { get; set; }
        [Display(Name = "About me")]
        public string AboutUser { get; set; }

        public virtual ICollection<Groups> GroupList { get; set; }
        public virtual ICollection<Photo> PhotoList { get; set; }
        public virtual ICollection<UserStatus> UserStatusList { get; set; }
        public virtual ICollection<User> FriendList { get; set; }

        public ICollection<Messenger> Messengers { get; set; }
       


    }
}