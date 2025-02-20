using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using CacheLockDemo.Localization;

namespace CacheLockDemo.Web;

[Dependency(ReplaceServices = true)]
public class CacheLockDemoBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<CacheLockDemoResource> _localizer;

    public CacheLockDemoBrandingProvider(IStringLocalizer<CacheLockDemoResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
