using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApiCoreIdentitySample.Data
{
    public class IdentityDbContext: IdentityDbContext<User>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().Property(x => x.FriendlyName).HasMaxLength(250);

            //not supported with SqLite-DB builder.HasDefaultSchema("identity");
        }
    }
}
