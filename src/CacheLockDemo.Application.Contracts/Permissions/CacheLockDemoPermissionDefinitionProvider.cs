using CacheLockDemo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace CacheLockDemo.Permissions;

public class CacheLockDemoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CacheLockDemoPermissions.GroupName);

        myGroup.AddPermission(CacheLockDemoPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(CacheLockDemoPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CacheLockDemoResource>(name);
    }
}
