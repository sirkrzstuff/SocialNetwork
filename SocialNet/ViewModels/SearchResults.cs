using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNet.ViewModels
{
    public class SearchResults
    {
        public string SearchString { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Persona> Personas { get; set; }
    }
}