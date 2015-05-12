using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNet.ViewModels
{
    public class FollowerList
    {
        public int Id { get; set; }
        public string PersonaName { get; set; }
        public int PersonaId { get; set; }
        public string  FollowerName { get; set; }
        public int FollwerId { get; set;}
    }
}