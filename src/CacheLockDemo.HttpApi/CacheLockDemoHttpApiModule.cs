using Localization.Resources.AbpUi;
using CacheLockDemo.Localization;
using Volo.Abp.Account;
using Volo.Abp.SettingManagement;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.Localization;
using Volo.Abp.LanguageManagement;

namespace CacheLockDemo;

 [DependsOn(
    typeof(CacheLockDemoApplicationContractsModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpAccountAdminHttpApiModule),
    typeof(LanguageManagementHttpApiModule),
    typeof(AbpAccountPublicHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule)
    )]
public class CacheLockDemoHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<CacheLockDemoResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
