using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VybesAPI.Vybes.Utils;

namespace VybesAPI.Vybes.Domain
{
    public class BaseProperty : IDomainInfo
    {
        [Column(Order = 0)]
        public Guid Id { get; set; }

        public Guid UsersId { get; set; }
        public Guid? CreatedBy { get; set; }
        [Column(TypeName = "timestamp")]
        public DateTime? CreatedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        [Column(TypeName = "timestamp")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(1)]
        public string? StatusRecord { get; set; }
    }
}
