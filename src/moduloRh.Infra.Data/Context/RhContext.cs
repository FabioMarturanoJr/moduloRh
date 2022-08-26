using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using moduloRh.Domain.Model;

namespace moduloRh.Infra.Data.Context
{
    public class RhContext : DbContext
    {
        public RhContext(DbContextOptions options) : base(options)
        { }


        public DbSet<UserModel> User { get; set; }

        internal void ValidateChangeTracker<T>(T dataToUpdate) where T : class
        {
            var dataToUpdateId = typeof(T).GetProperty("Id").GetValue(dataToUpdate);
            var tracker = Set<T>()
                .Local
                .FirstOrDefault(
                x => x.GetType().GetProperty("Id").GetValue(x).Equals(dataToUpdateId));

            if (tracker != null)
                Entry(tracker).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RhContext).Assembly);
        }
    }
}
