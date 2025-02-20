using CacheLockDemo.Localization;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.OpenIddict;
using Volo.Abp.BlobStoring.Database;
using Volo.Abp.LanguageManagement;
using Volo.Abp.GlobalFeatures;

namespace CacheLockDemo;

[DependsOn(
    typeof(AbpBackgroundJobsDomainSharedModule),
    typeof(AbpFeatureManagementDomainSharedModule),
    typeof(AbpPermissionManagementDomainSharedModule),
    typeof(AbpSettingManagementDomainSharedModule),
    typeof(AbpIdentityProDomainSharedModule),
    typeof(AbpOpenIddictProDomainSharedModule),
    typeof(LanguageManagementDomainSharedModule),
    typeof(AbpGlobalFeaturesModule),
    typeof(BlobStoringDatabaseDomainSharedModule)
    )]
public class CacheLockDemoDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        CacheLockDemoGlobalFeatureConfigurator.Configure();
        CacheLockDemoModuleExtensionConfigurator.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CacheLockDemoDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<CacheLockDemoResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/CacheLockDemo");

            options.DefaultResourceType = typeof(CacheLockDemoResource);
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("CacheLockDemo", typeof(CacheLockDemoResource));
        });
    }
}
