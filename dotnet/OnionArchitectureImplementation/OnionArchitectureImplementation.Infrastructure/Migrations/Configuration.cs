using System.Data.Entity.Migrations;

namespace OnionArchitectureImplementation.Infrastructure.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PaymentDetailContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "PaymentDetailContext";
        }

        protected override void Seed(PaymentDetailContext context)
        {
            // used to seed data lookup tables.
        }
    }
}
