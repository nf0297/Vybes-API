using VybesAPI.Vybes.Domain;
using VybesAPI.Vybes.ViewModel;
using VybesAPI.Vybes.Persistence;
using VybesAPI.Vybes.Utils;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace VybesAPI.Vybes.Services
{
    public class ItemsServices : BaseService
    {
        Mapper mapper;
        MapperConfiguration config = new MapperConfiguration(cfg => {
            cfg.AllowNullCollections = true;
            cfg.AllowNullDestinationValues = true;
            cfg.CreateMap<Items, UsersResponseModel>().ReverseMap();
        });

        public ItemsServices(VybesContext context) : base(context)
        {
            context = context;
            this.mapper = new Mapper(config);
        }

        public ItemsServices(VybesContext context, string customer) : base(context, customer)
        {
            context = context;
            this.mapper = new Mapper(config);
        }

        /// <summary>
        /// Digunakan untuk menambah data Items
        /// </summary>
        /// <param name="data">Merupakan data Items yang ingin ditambahkan</param>
        /// <returns>Data Items yang baru ditambahkan</returns>
        public async Task<Items> CreateAsync(ItemsRequestModel data)
        {
            var users = new Items()
            {
                Id = Guid.NewGuid(),
                Name = data.Name,
                Quantity = data.Quantity,
                Description = data.Description,
            };
            users.CreatedBy(UsersId);

            await context.Items.AddAsync(users);
            await context.SaveChangesAsync();

            return users;
        }

        /// <summary>
        /// Digunakan untuk membaca data Items
        /// </summary>
        /// <returns>Semua Data Items</returns>
        public async Task<List<ItemsResponseModel>> GetAsync()
        {
            var result = await context.Items
                .Select(x => new ItemsResponseModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Quantity = x.Quantity,
                    Description = x.Description,
                }).ToListAsync();

            return result;
        }

        /// <summary>
        /// Digunakan untuk membaca data Items
        /// </summary>
        /// <param name="usersId">Merupakan Id Items yang ingin di baca</param>
        /// <returns>Data Items Terkait</returns>
        public async Task<ItemsResponseModel> GetByIdAsync(Guid itemsId)
        {
            var result = await context.Items
                    .Where(x => x.Id == itemsId)
                    .Select(x => new ItemsResponseModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Quantity = x.Quantity,
                        Description = x.Description,
                    }).FirstOrDefaultAsync();

            return result;
        }

        /// <summary>
        /// Digunakan untuk membaca data Items
        /// </summary>
        /// <param name="usersId">Merupakan Id Items yang ingin di baca</param>
        /// <returns>Data Items Terkait</returns>
        public async Task<string> DeleteByIdAsync(Guid itemsId)
        {
            var item = await context.Items.Where(x => x.Id == itemsId).FirstOrDefaultAsync();
            if (item != null)
            {
                item.DeletedBy(UsersId);
                await context.SaveChangesAsync();
            }

            return "Item successfully deleted!";
        }
    }
}
