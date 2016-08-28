using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web;
using System;

namespace ContactManager.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
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
        public ApplicationDbContext()
            : base("ContactsContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ContactManager.Models.Contact> Contacts { get; set; }

        public override int SaveChanges()
        {
            AddAuditData();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            AddAuditData();
            return await base.SaveChangesAsync();
        }

        private void AddAuditData()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseAuditEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var currentUsername = !string.IsNullOrEmpty(HttpContext.Current?.User?.Identity?.Name)
                ? HttpContext.Current.User.Identity.Name
                : "Anonymous";

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseAuditEntity)entity.Entity).CreatedUtc = DateTime.UtcNow;
                    ((BaseAuditEntity)entity.Entity).UserCreated = currentUsername;
                }

                ((BaseAuditEntity)entity.Entity).ModifiedUtc = DateTime.UtcNow;
                ((BaseAuditEntity)entity.Entity).UserModified = currentUsername;
            }
        }
    }
}