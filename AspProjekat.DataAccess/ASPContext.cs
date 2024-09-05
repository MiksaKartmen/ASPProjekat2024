using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace ASPProjekat.Domain
{
    public class ASPContext : DbContext
    {
        private readonly string _connectionString;
        public ASPContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public ASPContext()
        {
            _connectionString = "Data Source=DESKTOP-JC4HE8S\\SQLEXPRESS;Initial Catalog=ASPProjekat;Integrated Security=True;Trust Server Certificate=True";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(_connectionString);
                            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            modelBuilder.Entity<ErrorLog>().Property(x => x.StrackTrace).IsRequired();
            modelBuilder.Entity<ErrorLog>().Property(x => x.Message).IsRequired();
            modelBuilder.Entity<ErrorLog>().Property(x => x.Time).IsRequired();
            modelBuilder.Entity<ErrorLog>().HasKey(x => x.ErrorId);



            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            IEnumerable<EntityEntry> entries = this.ChangeTracker.Entries();

            foreach (EntityEntry entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is Entity e)
                    {

                        e.CreatedAt = DateTime.UtcNow;
                    }
                }

                if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.UpdatedAt = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChanges();
        }

       
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<MealTime> MealTimes { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItemMealTime> MenuItemMealTimes { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserImage> UserImages { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }

    }
}
