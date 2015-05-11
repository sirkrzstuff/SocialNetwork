using SocialNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SocialNet.ViewModels
{
    public class Persona
    {
        [Key]
        public string UserName { get; set; }

        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string AboutUser { get; set; }
        public Type? PersonaType { get; set; }

        public virtual ICollection<Groups> GroupList { get; set; }
        public virtual ICollection<Photo> PhotoList { get; set; }
        public virtual ICollection<UserStatus> UserStatusList { get; set; }
        public virtual ICollection<FollowerList> FollowerList { get; set; }

        public enum Type
        {
            Artist, Buisness, Organization, Sport, Political, Other
        }
    }
}