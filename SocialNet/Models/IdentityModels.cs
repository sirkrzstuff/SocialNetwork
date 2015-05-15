using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SocialNet.ViewModels;
using System;
using SocialNet.Service;

namespace SocialNet.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
       // //User
       // public string FirstName { get; set; }
       // public string LastName { get; set; }
       // public bool IsMale { get; set; }
       // public bool IsSingle { get; set; }

       // //Persona
       // public string Name { get; set; }
       //// public PersonaType PersonaType { get; set; }
        
       // //Both
       // public DateTime BirthDay { get; set; }
       // public string AboutUser { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<User> Users { get; set; }
        //public DbSet<Persona> Personas { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FriendList> FriendLists { get; set; }
        public DbSet<FollowerList> FollowerLists { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Groups> GroupsList { get; set;}
        

        public ApplicationDbContext()
            : base("HrConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<SocialNet.ViewModels.Persona> Personas { get; set; }

        public System.Data.Entity.DbSet<SocialNet.ViewModels.Messenger> Messengers { get; set; }

        public System.Data.Entity.DbSet<SocialNet.ViewModels.Profile> Profiles { get; set; }
    }
}