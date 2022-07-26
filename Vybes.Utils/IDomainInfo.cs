namespace VybesAPI.Vybes.Utils
{
    public interface IDomainInfo
    {
        public Guid Id { get; set; }
        public Guid UsersId { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        string? StatusRecord { get; set; }
    }
}
