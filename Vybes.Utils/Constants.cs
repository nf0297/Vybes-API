namespace VybesAPI.Vybes.Utils
{
    public class Constants
    {
        public static string EnvName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        public const string StatusRecordInsert = "I";
        public const string StatusRecordUpdate = "U";
        public const string StatusRecordDelete = "D";

        public static readonly Guid VybesUsersId = new Guid("f0898d3f-568d-42d5-b605-6ed35413b736");
    }
}
