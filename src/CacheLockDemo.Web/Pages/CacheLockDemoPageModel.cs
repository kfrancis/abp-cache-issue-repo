using CacheLockDemo.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace CacheLockDemo.Web.Pages;

public abstract class CacheLockDemoPageModel : AbpPageModel
{
    protected CacheLockDemoPageModel()
    {
        LocalizationResourceType = typeof(CacheLockDemoResource);
    }
}
