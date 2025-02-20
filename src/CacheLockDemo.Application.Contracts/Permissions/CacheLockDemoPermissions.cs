namespace CacheLockDemo.Permissions;

public static class CacheLockDemoPermissions
{
    public const string GroupName = "CacheLockDemo";

    public static class Dashboard
    {
        public const string DashboardGroup = GroupName + ".Dashboard";
        public const string Host = DashboardGroup + ".Host";
    }

    
    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
}
