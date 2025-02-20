using Volo.Abp.Account;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.LanguageManagement;

namespace CacheLockDemo;

[DependsOn(
    typeof(CacheLockDemoDomainSharedModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpAccountPublicApplicationContractsModule),
    typeof(AbpAccountAdminApplicationContractsModule),
    typeof(LanguageManagementApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule)
)]
public class CacheLockDemoApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        CacheLockDemoDtoExtensions.Configure();
    }
}
