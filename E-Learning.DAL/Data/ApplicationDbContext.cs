using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var roleAdminId = Guid.NewGuid().ToString();
            var roleSuperAdminId = Guid.NewGuid().ToString();
            var roleUserId = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id=roleAdminId , Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = roleSuperAdminId, Name = "SuperAdmin", NormalizedName = "SUPERADMIN" },
                new IdentityRole { Id = roleUserId, Name = "User", NormalizedName = "USER" }


                );
            var hasher = new PasswordHasher<ApplicationUser>();

            var adminUser = new ApplicationUser
            {
                Id= Guid.NewGuid().ToString(),
                UserName="admin@Elearning.com",
                NormalizedUserName="ADMIN@ELEARNING.COM",
                Email= "admin@Elearning.com",
                NormalizedEmail= "ADMIN@ELEARNING.COM",
                EmailConfirmed=true,

            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Horia@123");

            var superAdmin= new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "superAdmin@Elearning.com",
                NormalizedUserName = "SUPERADMIN@ELEARNING.COM",
                Email = "superAdmin@Elearning.com",
                NormalizedEmail = "SUPERADMIN@ELEARNING.COM",
                EmailConfirmed = true,

            };
            superAdmin.PasswordHash = hasher.HashPassword(superAdmin, "Horia@123");


            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user@Elearning.com",
                NormalizedUserName = "USER@ELEARNING.COM",
                Email = "user@Elearning.com",
                NormalizedEmail = "USER@ELEARNING.COM",
                EmailConfirmed = true,

            };
            user.PasswordHash = hasher.HashPassword(user, "Horia@123");

            builder.Entity<ApplicationUser>().HasData(adminUser, superAdmin, user);
            builder.Entity<IdentityUserRole<String>>().HasData(
                new IdentityUserRole<string> { RoleId = roleUserId, UserId = user.Id },
                new IdentityUserRole<string> { RoleId = roleSuperAdminId, UserId = superAdmin.Id },
                new IdentityUserRole<string> { RoleId = roleAdminId, UserId = adminUser.Id }

                );
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
