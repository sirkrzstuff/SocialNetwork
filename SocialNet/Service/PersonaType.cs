using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialNet.ViewModels;

namespace SocialNet.Service
{
    public class PersonaType
    {
        public Type? Type { get; set; }
    }

    public enum Type
    {
        Artist, Buisness, Organization, Sport, Political, Other
    }
}