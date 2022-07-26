using VybesAPI.Vybes.Services;

namespace VybesAPI.Vybes.Domain
{
    public class Users : BaseProperty
    {
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
