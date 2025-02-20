using CacheLockDemo.Localization;
using Volo.Abp.Application.Services;

namespace CacheLockDemo;

/* Inherit your application services from this class.
 */
public abstract class CacheLockDemoAppService : ApplicationService
{
    protected CacheLockDemoAppService()
    {
        LocalizationResource = typeof(CacheLockDemoResource);
    }
}
