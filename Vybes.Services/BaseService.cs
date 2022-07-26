using AutoMapper;
using VybesAPI.Vybes.Persistence;
using VybesAPI.Vybes.ViewModel;
using VybesAPI.Vybes.Domain;

namespace VybesAPI.Vybes.Services
{
    public class BaseService
    {
        public DateTime TodayDate = DateTime.Now;//TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneConverter.TZConvert.GetTimeZoneInfo("SE Asia Standard Time"));

        public Guid UsersId = Guid.Empty;
        public string Username = "";
        public VybesContext context;
        public Mapper mapper;
        public BaseService() : this(new VybesContext(), "Andal")
        {

        }

        public BaseService(VybesContext dbContext) : this(dbContext, "Andal")
        {
            this.mapper = new Mapper(config);
            this.context = context;
        }

        public BaseService(VybesContext dbContext, string users)
        {
            this.context = dbContext;
            var dataCustomer = dbContext.Users.Where(s => s.Id.ToString() == users).SingleOrDefault();
            if (dataCustomer != null)
            {
                this.UsersId = dataCustomer.Id;
                this.Username = dataCustomer.Username;
            }
        }

        #region Mapper
        private MapperConfiguration config = new MapperConfiguration(c =>
        {
            c.AllowNullCollections = true;
            c.AllowNullDestinationValues = true;
            c.CreateMap<UsersRequestModel, Users>().ReverseMap();
            c.CreateMap<ItemsRequestModel, Items>().ReverseMap();
        });
        #endregion Mapper
    }
}
