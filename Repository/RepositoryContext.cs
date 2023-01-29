using Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {

        }
        
        public DbSet<Admin> admins { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Post> posts { get; set; }
        public DbSet<Report> reports { get; set; }
        public DbSet<Station> stations { get; set; }
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<Train> trains { get; set; }
        
    }
}
