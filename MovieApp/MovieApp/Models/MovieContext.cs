using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {
            //Leave blank for now
        }

        public DbSet<MovieResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                
                new Category { CategoryID = 1, CategoryName = "Romance"},
                new Category { CategoryID = 2, CategoryName = "Action" },
                new Category { CategoryID = 3, CategoryName = "Family" },
                new Category { CategoryID = 4, CategoryName = "Adventure" },
                new Category { CategoryID = 5, CategoryName = "Comedy" }
            );

            mb.Entity<MovieResponse>().HasData(

                new MovieResponse
                {
                    MovieID = 1,
                    Title = "When in Rome",
                    Year = "2010",
                    Director = "Mark Steven Johnson",
                    Rating = "PG-13",
                    CategoryID = 1
                },
                new MovieResponse
                {
                    MovieID = 2,
                    Title = "Megamind",
                    Year = "2010",
                    Director = "Tom McGrath",
                    Rating = "PG",
                    CategoryID = 3
                },
                new MovieResponse
                {
                    MovieID = 3,
                    Title = "Captain America: The First Avenger",
                    Year = "2011",
                    Director = "Joe Johnston",
                    Rating = "PG-13",
                    CategoryID = 2
                }
            );
        }
    }
}
