using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainterWebApplication.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Painter> Painters { get; set; }
        public DbSet<Set> Sets { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
