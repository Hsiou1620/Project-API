using game_shop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace game_shop.Data
{
    public class ApplicationDBContext(DbContextOptions dbContextOptions) : IdentityDbContext<User>(dbContextOptions)
    {
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<IdentityRole> roles =
            [
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            ];
            modelBuilder.Entity<IdentityRole>().HasData(roles);
            /*modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1,
                    Name = "name",
                    Image = "image",
                    Description = "description",
                    Price = 69.99
                },
                new Game
                {
                    Id = 2,
                    Name = "name2",
                    Image = "image2",
                    Description = "description2",
                    Price = 69.99
                }, new Game
                {
                    Id = 3,
                    Name = "name3",
                    Image = "image3",
                    Description = "description3",
                    Price = 69.99
                },
                new Game
                {
                    Id = 4,
                    Name = "name4",
                    Image = "image4",
                    Description = "description4",
                    Price = 69.99
                }
            );*/
        }
    }
}