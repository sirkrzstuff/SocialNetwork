﻿using System;
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
        [Key]
        public string UserName { get; set; }
 
        //For Normal user and Persona
        public DateTime? DateOfBirth { get; set; }
        public string AboutUser { get; set; }

        public virtual ICollection<Groups> GroupList { get; set; }
        public virtual ICollection<Photo> PhotoList { get; set; }
        public virtual ICollection<UserStatus> UserStatusList { get; set; }

        //Normal user
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsMale { get; set; }
        public bool IsSingle { get; set; }

        public virtual ICollection<FriendList> FriendList { get; set; }

        //Persona
        public string Name { get; set; }
        public Type? PersonaType { get; set; }

        public virtual ICollection<FollowerList> FollowerList { get; set; }

        public enum Type
        {
            Artist, Buisness, Organization, Sport, Political, Other
        }


    }
}