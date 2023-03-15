
using Restaurant.Core.Domain.Common;
using Restaurant.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Infrastucture.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext (DbContextOptions<ApplicationContext> options) : base(options) { }

        DbSet<Dish> Dishes { get; set; }
        DbSet<Ingredients> Ingredients { get;set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Table> Tables { get; set; }
        DbSet<TableStatus> TableStatuses { get; set; }
        DbSet<OrderStatus> orderStatuses { get; set; }
        DbSet<DishCategory> dishCategories { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entity in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.CreatedDate = DateTime.Now;
                        entity.Entity.CreatedBy = "Default";
                        break;
                    
                    case EntityState.Modified:
                        entity.Entity.LastModified = DateTime.Now;
                        entity.Entity.LastModifiedBy = "Default";
                        break;
                        
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region "Tables"

                modelBuilder.Entity<Dish>().ToTable("Dishes");
                modelBuilder.Entity<Ingredients>().ToTable("Ingridients");
                modelBuilder.Entity<Order>().ToTable("Orders");
                modelBuilder.Entity<Table>().ToTable("Tables");
                modelBuilder.Entity<TableStatus>().ToTable("TableStatuses");
                modelBuilder.Entity<OrderStatus>().ToTable("OrderStatuses");
                modelBuilder.Entity<DishCategory>().ToTable("DishCategories");


            #endregion

            #region "Primary Key"

            modelBuilder.Entity<Dish>().HasKey(d => d.Id);
            modelBuilder.Entity<Ingredients>().HasKey( i => i.Id);
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Table>().HasKey(t => t.Id);
            modelBuilder.Entity<TableStatus>().HasKey(t => t.Id);
            modelBuilder.Entity<OrderStatus>().HasKey(o => o.Id);
            modelBuilder.Entity<DishCategory>().HasKey(c => c.Id);


            #endregion

            #region "Relations"

            modelBuilder.Entity<Table>()
                .HasMany<Order>(t => t.Order)
                .WithOne(o => o.Table)
                .HasForeignKey(o => o.TableId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<TableStatus>()
                .HasMany<Table>(t => t.Tables)
                .WithOne(o => o.TableStatus)
                .HasForeignKey(o => o.TableStatusId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderStatus>()
                .HasMany<Order>(t => t.Orders)
                .WithOne(o => o.OrderStatus)
                .HasForeignKey(o => o.OrderStatusId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DishCategory>()
                .HasMany<Dish>(t => t.Dishes)
                .WithOne(o => o.DishCategory)
                .HasForeignKey(o => o.DishCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

      





            #endregion

            #region "Properties Configuration"

            modelBuilder.Entity<Ingredients>().Property(i => i.Name).IsRequired().HasMaxLength(85);


            modelBuilder.Entity<Dish>().Property(d => d.Name ).IsRequired().HasMaxLength(80);
            modelBuilder.Entity<Dish>().Property(d => d.Price).IsRequired();
            modelBuilder.Entity<Dish>().Property(d => d.DishCategoryId).IsRequired();
            modelBuilder.Entity<Dish>().Property(d => d.IngredientList).IsRequired();


            modelBuilder.Entity<Table>().Property(t => t.NumberPeopleItCanHold ).IsRequired();
            modelBuilder.Entity<Table>().Property(t => t.TableStatusId).IsRequired();
            modelBuilder.Entity<Table>().Property(t => t.Description).HasMaxLength(255);



            modelBuilder.Entity<Order>().Property(o => o.SubTotal ).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.OrderStatusId ).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.SelectedDish ).IsRequired();

            modelBuilder.Entity<OrderStatus>().Property(o => o.status).IsRequired();
            modelBuilder.Entity<TableStatus>().Property(o => o.status).IsRequired();
            modelBuilder.Entity<DishCategory>().Property(o => o.Name).IsRequired();






            #endregion
        }
    }
}
