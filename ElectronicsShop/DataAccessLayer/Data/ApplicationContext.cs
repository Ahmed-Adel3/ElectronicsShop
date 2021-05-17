using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {}

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Seed(modelBuilder);
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            string AdminId = "66374cf0–7hur–bnu5-rf57-3r5706d72bgt";
            string CustomerId = "4ty74cf0–7h67–bnu5-fh67-45t706d72huy";
            string RoleId = "3417fyr-adr4–4f5e-afbf-58mrryi72gyk";

            modelBuilder.Entity<ProductType>().HasData(
               new ProductType { ProductTypeId = 1, TypeNameAr = "جهاز تلفزيون", TypeNameEn = "Televisions" },
               new ProductType { ProductTypeId = 2, TypeNameAr = "جهاز لابتوب", TypeNameEn = "Laptops" },
               new ProductType { ProductTypeId = 3, TypeNameAr = "نظام صوت", TypeNameEn = "Sound Systems" });

            //seed admin role
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Id = RoleId,
                ConcurrencyStamp = RoleId
            });

            //create user
            var AdminUser = new ApplicationUser
            {
                Id = AdminId,
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                EmailConfirmed = true,
                FullName = "Application Admin",
                LockoutEnabled = false,
                PhoneNumber = "01112222345"
            };

            var CustomerUser = new ApplicationUser
            {
                Id = CustomerId,
                UserName = "ahmed.al.adl333@gmail.com",
                Email = "ahmed.al.adl333@gmail.com",
                EmailConfirmed = true,
                FullName = "Ahmed Adel",
                LockoutEnabled = false,
                PhoneNumber = "01112222345"
            };

            //set user password
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            AdminUser.PasswordHash = ph.HashPassword(AdminUser, "admin");
            CustomerUser.PasswordHash = ph.HashPassword(AdminUser, "customer");

            //seed user
            modelBuilder.Entity<ApplicationUser>().HasData(AdminUser);
            modelBuilder.Entity<ApplicationUser>().HasData(CustomerUser);


            //set user role to admin
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                { 
                    RoleId = RoleId,
                    UserId = AdminId 
                } );
        }
    }
}
