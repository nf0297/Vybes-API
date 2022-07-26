using VybesAPI.Vybes.Domain;
using VybesAPI.Vybes.Persistence;
using VybesAPI.Vybes.ViewModel;
using Microsoft.EntityFrameworkCore;
using VybesAPI.Vybes.Utils;

namespace VybesAPI.Vybes.Services
{
    public class UsersServices : BaseService
    {
        public UsersServices(VybesContext context) : base(context)
        {
            context = context;
        }
        //public UsersServices(VybesContext context, string customerName) : base(context, customerName)
        //{
        //    context = context;
        //}

        /// <summary>
        /// Digunakan untuk menambah data Users
        /// </summary>
        /// <param name="data">Merupakan data Users yang ingin ditambahkan</param>
        /// <returns>Data Users yang baru ditambahkan</returns>
        public async Task<Users> CreateAsync(UsersRequestModel data)
        {
            var users = new Users()
            {
                Id =  Guid.NewGuid(),
                Name = data.Name,
                Username = data.Username,
                Password = data.Password,
            };

            users.CreatedBy(users.Id);

            await context.Users.AddAsync(users);
            await context.SaveChangesAsync();

            return users;
        }

        /// <summary>
        /// Digunakan untuk melakukan Sign In Users
        /// </summary>
        /// <param name="data">Merupakan data Users yang ingin Sign In</param>
        /// <returns>Data Users yang Sign In jika benar</returns>
        public async Task<UsersResponseModel> SignInAsync(SignInRequestModel signInRequestModel)
        {
            var result = await context.Users
                .Where(x => x.Username == signInRequestModel.Username && 
                            x.Password == signInRequestModel.Password)
                .Select(x => new UsersResponseModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Username = x.Username,
                    Password = x.Password,
                }).FirstOrDefaultAsync();

            return result;
        }

        /// <summary>
        /// Digunakan untuk membaca data Users
        /// </summary>
        /// <returns>Semua Data Users</returns>
        public async Task<List<UsersResponseModel>> GetAsync()
        {
            var result = await context.Users
                .Select(x => new UsersResponseModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Username = x.Username,
                    Password= x.Password,
                }).ToListAsync();

            return result;
        }

        /// <summary>
        /// Digunakan untuk membaca data Users
        /// </summary>
        /// <param name="usersId">Merupakan Id Users yang ingin di baca</param>
        /// <returns>Data Users Terkait</returns>
        public async Task<UsersResponseModel> GetByIdAsync(Guid usersId)
        {
            var result = await context.Users
                .Where(x => x.Id == usersId)
                .Select(x => new UsersResponseModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Username = x.Username,
                    Password = x.Password,
                }).FirstOrDefaultAsync();

            return result;
        }
    }
}
