namespace VybesAPI.Vybes.ViewModel
{
    public class ItemsResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
