namespace GestionMarchePublic.Permissions;

public class GestionMarchePublicPermissions
{
    public const string GroupName = "GestionMarchePublic";
    
    public static class Demands
    {
        public const string Default = GroupName + ".Demand";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    // *** ADDED a NEW NESTED CLASS ***
    public static class Dossier
    {
        public const string Default = GroupName + ".Dossier";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}