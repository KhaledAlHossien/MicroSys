namespace test_For_Microtik.Persistence
{
    using global::test_For_Microtik.Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    namespace test_For_Microtik.Infrastructure
    {
        public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\MSSQLLocalDB;Database=TestMikroTikDb;Trusted_Connection=True;MultipleActiveResultSets=true");

                return new AppDbContext(optionsBuilder.Options);
            }
        }
    }
}
