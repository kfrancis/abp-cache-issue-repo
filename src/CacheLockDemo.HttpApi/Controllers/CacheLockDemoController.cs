using CacheLockDemo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CacheLockDemo.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CacheLockDemoController : AbpControllerBase
{
    protected CacheLockDemoController()
    {
        LocalizationResource = typeof(CacheLockDemoResource);
    }
}
