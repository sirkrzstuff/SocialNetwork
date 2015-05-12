using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNet.ViewModels
{
    public class SearchBar
    {
        [Required]
        public string SearchString { get; set; }
    }
}