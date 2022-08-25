using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using moduloRh.Domain.Model;

namespace moduloRh.Infra.Data.Context
{
    public class RhContext : DbContext
    {
        //internal IConfiguration _configuration;

        //public RhContext(DbContextOptions options, IConfiguration configuration) : base(options)
        //{
        //    _configuration = configuration;
        //}

        public RhContext(DbContextOptions options) : base(options)
        { }

        public DbSet<UserModel> User { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured ||
        //        (!optionsBuilder.Options.Extensions.OfType<RelationalOptionsExtension>().Any(ext => !string.IsNullOrEmpty(ext.ConnectionString) || ext.Connection != null) &&
        //         !optionsBuilder.Options.Extensions.Any(ext => !(ext is RelationalOptionsExtension) && !(ext is CoreOptionsExtension))))
        //    {
        //        optionsBuilder.UseNpgsql(GetConnectionString());
        //    }
        //    base.OnConfiguring(optionsBuilder);
        //}

        //public virtual string GetConnectionString()
        //{
        //    return _configuration == null ? "" : _configuration["ConnectionStrings:ConnectionString"];
        //}

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
