using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CacheLockDemo.Data;

/* This is used if database provider does't define
 * ICacheLockDemoDbSchemaMigrator implementation.
 */
public class NullCacheLockDemoDbSchemaMigrator : ICacheLockDemoDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
