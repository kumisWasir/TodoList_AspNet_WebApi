using Microsoft.EntityFrameworkCore;

using ToDoList.Model;
namespace ToDoList.DataContext
{
    public class Connection : DbContext
    {
        public Connection(DbContextOptions<Connection> options) : base(options){
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            
            modelBuilder.Entity<Tugas>().HasIndex(t => t.Deskripsi).IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> category {get;set;}
        public DbSet<Tugas> tugas {get;set;}
    }
}