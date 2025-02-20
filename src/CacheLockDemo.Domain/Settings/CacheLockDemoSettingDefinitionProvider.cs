using Volo.Abp.Settings;

namespace CacheLockDemo.Settings;

public class CacheLockDemoSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(CacheLockDemoSettings.MySetting1));
    }
}
