using System.Threading.Tasks;
using CacheLockDemo.Localization;
using CacheLockDemo.Permissions;
using CacheLockDemo.MultiTenancy;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.LanguageManagement.Navigation;

namespace CacheLockDemo.Web.Menus;

public class CacheLockDemoMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<CacheLockDemoResource>();

        //Home
        context.Menu.AddItem(
            new ApplicationMenuItem(
                CacheLockDemoMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fa fa-home",
                order: 1
            )
        );

        //HostDashboard
        context.Menu.AddItem(
            new ApplicationMenuItem(
                CacheLockDemoMenus.HostDashboard,
                l["Menu:Dashboard"],
                "~/HostDashboard",
                icon: "fa fa-line-chart",
                order: 2
            ).RequirePermissions(CacheLockDemoPermissions.Dashboard.Host)
        );
    

        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 5;

        //Administration->Identity
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);

        //Administration->Language Management
        administration.SetSubItemOrder(LanguageManagementMenuNames.GroupName, 4);

        //Administration->Settings
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 7);
        
        return Task.CompletedTask;
    }
}
