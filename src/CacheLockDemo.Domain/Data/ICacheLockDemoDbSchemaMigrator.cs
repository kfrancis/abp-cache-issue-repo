using System.Threading.Tasks;

namespace CacheLockDemo.Data;

public interface ICacheLockDemoDbSchemaMigrator
{
    Task MigrateAsync();
}
