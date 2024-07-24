using OnionArchitectureImplementation.Domain.Configuration;
using OnionArchitectureImplementation.Domain.Entities;
using OnionArchitectureImplementation.Infrastructure.Migrations;
using System.Data.Entity;

namespace OnionArchitectureImplementation.Infrastructure
{
    public class PaymentDetailContext : DbContext
    {
        public PaymentDetailContext()
            : base("name=PaymentDetailConnectionString")
        {
            //disables the creation of dynamic proxy objects, likely optimizing performance 
            Configuration.ProxyCreationEnabled = false;

            //the related data will be loaded eagerly when the entity is loaded.
            Configuration.LazyLoadingEnabled = false;

            //automatically updating the database schema to the latest version
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PaymentDetailContext, Configuration>());
        }

        public virtual DbSet<PaymentDetail> PaymentDetail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Entity configuration using fluentValidation instead of Data-Annotation
            modelBuilder.Configurations.Add(new PaymentDetailConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}