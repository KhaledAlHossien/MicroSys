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
                    "Data Source=HOMAMNASSER;Initial Catalog=MicrotikDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");

                return new AppDbContext(optionsBuilder.Options);
            }
        }
    }
}
