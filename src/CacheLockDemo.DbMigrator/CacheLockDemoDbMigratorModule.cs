using CacheLockDemo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace CacheLockDemo.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CacheLockDemoEntityFrameworkCoreModule),
    typeof(CacheLockDemoApplicationContractsModule)
)]
public class CacheLockDemoDbMigratorModule : AbpModule
{
}
