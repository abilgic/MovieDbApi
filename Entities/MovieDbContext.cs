using Hangfire.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MovieDbApi.Entities
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
               : base(options)
        {
        }

        DbSet<Movie> Movie { get; set; }

    }

}
