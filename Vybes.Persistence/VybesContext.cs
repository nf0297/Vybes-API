using Microsoft.EntityFrameworkCore;
using VybesAPI.Vybes.Domain;
using VybesAPI.Vybes.Utils;

namespace VybesAPI.Vybes.Persistence
{
    public class VybesContext: DbContext
    {
        private readonly string connectionString = Environment.GetEnvironmentVariable("VybesConnectionString");

        private readonly IHttpContextAccessor _httpContextAccessor;
        private string User { get; set; }
        private string Username { get; set; }
        private Guid UsersId { get; set; }

        public VybesContext(){ }

        public VybesContext(Guid usersId)
        {
            UsersId = usersId;
        }

        public VybesContext(DbContextOptions<VybesContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            if (httpContextAccessor != null)
                try
                {
                    User = _httpContextAccessor.HttpContext.Request.Headers["User"];
                    UsersId = User == string.Empty || User == null ? Guid.Empty : Guid.Parse(User);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" error Customer Header{ex}");
                }

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Items> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=vybes;Username=postgres;Password=P@ssw0rd;Minimum Pool Size=5;Maximum Pool Size=10;");
            //optionsBuilder.UseNpgsql(connectionString);
        }
        public void GetUsersId(string userName)
        {
            Users user = Users.Where(x => x.Username == Username).SingleOrDefault();
            if (user != null)
            {
                UsersId = new Guid(user.Id.ToString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Filter for soft-deleted data
            modelBuilder.Entity<Users>().HasQueryFilter(x => x.StatusRecord != Constants.StatusRecordDelete);
            modelBuilder.Entity<Items>().HasQueryFilter(x => x.StatusRecord != Constants.StatusRecordDelete);

            // Restrict the delete operation for the dependant data.
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
