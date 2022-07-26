using VybesAPI.Vybes.Services;

namespace VybesAPI.Vybes.Domain
{
    public class Items : BaseProperty
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Description { get; set; } = string.Empty;

        public virtual Users? User { get; set; }
    }
}
