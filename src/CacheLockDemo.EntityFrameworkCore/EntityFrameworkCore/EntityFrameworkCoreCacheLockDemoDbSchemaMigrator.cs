using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CacheLockDemo.Data;
using Volo.Abp.DependencyInjection;

namespace CacheLockDemo.EntityFrameworkCore;

public class EntityFrameworkCoreCacheLockDemoDbSchemaMigrator
    : ICacheLockDemoDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreCacheLockDemoDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the CacheLockDemoDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<CacheLockDemoDbContext>()
            .Database
            .MigrateAsync();
    }
}
