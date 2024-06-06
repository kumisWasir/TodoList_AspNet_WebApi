<<<<<<< HEAD
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
=======
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
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Tugas)
                .WithOne(c => c.Category_FK)
                .HasForeignKey(c => c.Category_ID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            
            modelBuilder.Entity<Tugas>().HasIndex(t => t.Deskripsi).IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> category {get;set;}
        public DbSet<Tugas> tugas {get;set;}
    }
>>>>>>> 0df3ff7bcdd67abb3a637370e01cfcea36a2e8c6
}
