namespace SkillMatrix.Common.Constants
{
    public class Global
    {
       

        public class AppSettings
        {
            public const string NeedSeedAfterMigration = "NeedSeedAfterMigration";
            public const string LanguageCookieKey = "languageCookieKey";
            public const string PaggingCount = "PaggingCount";
            public const string GlobalStoragePath = "GlobalStoragePath";
            public const string BlankAvatarFilePath = "BlankAvatarFilePath";




        }

        public class GlobalConsts
        {
            public const string IdToRoleContextKey = "IdToRole";
            public const string RoleToIdContextKey = "RoleToId";
            public const string IdToPermissionContextKey = "PermissionToId";
            public const string PermissionToIdContextKey = "IdToPermission";
            public const string PermissionTypeToNameContextKey = "PermissionTypeToName";
            public const string RoleIdToMappedContextKey = "RoleToMapped";

            public const string UserProfile = "UserProfile";
            public const string AppUser = "AppUser";
            public const string ExistUserProfile = "ExistUserProfile";
            public const string LanguageKey = "Language";
            public const string ExpirationField = "KeysExpired";

            public const string WelcomeMessagePathForNewUsers = "~/Views/Templates/WelcomeMessage.cshtml";
            public const string TableNotificationPath = "~/Views/Templates/TableNotification.cshtml";
        }

        public static class SessionKeys
        {
            public const string UserId = "UserID";
            public const string ProviderId = "ProviderId";
            public const string LocationId = "LocID";
            public const string RoleId = "RoleId";
            public const string PracticeId = "PracticeId";
            public const string UserDefaultSearchOption = "UserDefaultSearchOption";
            public const string UserName = "UserName";
            public const string UserLoginMode = "UserLoginMode";
            public const string IsRibbonMenuEnabled = "IsRibbonMenuEnabled";
            public const string BrowserName = "BrowserName";
            public const string BrowserVersion = "BrowserVersion";
        }
        
    }
}
