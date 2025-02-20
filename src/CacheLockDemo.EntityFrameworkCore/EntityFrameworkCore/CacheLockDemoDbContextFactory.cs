using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CacheLockDemo.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class CacheLockDemoDbContextFactory : IDesignTimeDbContextFactory<CacheLockDemoDbContext>
{
    public CacheLockDemoDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        CacheLockDemoEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<CacheLockDemoDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new CacheLockDemoDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../CacheLockDemo.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
