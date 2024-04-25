using System.Reflection;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Common.Persistence;

public class GymManagementDbContext : DbContext, IUnitOfWork
{
   public DbSet<Subscription> Subscriptions { get; set; }

   public GymManagementDbContext(DbContextOptions<GymManagementDbContext> options) : base(options)
   {
   }

   public Task CommitChangesAsync()
   {
      return base.SaveChangesAsync();
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
      base.OnModelCreating(modelBuilder);
   }
}