namespace VybesAPI.Vybes.ViewModel
{
    public class ItemsRequestModel
    {
        public Guid UsersId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
