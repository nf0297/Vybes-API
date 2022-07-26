namespace VybesAPI.Vybes.Utils
{
    public static class DomainExtensionMethods
    {
        private static DateTime DateTimeGMT7 = DateTime.Today;
        public static string StatusRecordInsert = "I";
        public static string StatusRecordUpdate = "U";
        public static string StatusRecordDelete = "D";

        public static void CreatedBy(this IDomainInfo domain, Guid userId)
        {
            domain.CreatedBy = userId;
            domain.CreatedDate = DateTimeGMT7;
            domain.StatusRecord = StatusRecordInsert;
            domain.UsersId = userId;
        }

        public static void ModifiedBy(this IDomainInfo domain, Guid userId)
        {
            domain.ModifiedBy = userId;
            domain.ModifiedDate = DateTimeGMT7;
            domain.StatusRecord = StatusRecordUpdate;
        }

        public static void DeletedBy(this IDomainInfo domain, Guid userId)
        {
            domain.ModifiedBy = userId;
            domain.ModifiedDate = DateTimeGMT7;
            domain.StatusRecord = StatusRecordDelete;
        }
    }
}
