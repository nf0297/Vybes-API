using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VybesAPI.Vybes.Domain;
using VybesAPI.Vybes.Services;
using VybesAPI.Vybes.ViewModel;
using VybesAPI.Vybes.Persistence;

namespace VybesAPI.Vybes.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [ControllerName("Users")]
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class UsersController : ControllerBase
    {
        private readonly VybesContext _context;
        private readonly UsersServices _UsersService;

        public UsersController(VybesContext context)
        {
            _context = context;
            _UsersService = new UsersServices(context);
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(List<UsersResponseModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<UsersResponseModel> result = await _UsersService.GetAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                var msg = $"Error when getting User data By Id. {ex.Message}";

                if (ex.InnerException != null)
                    msg = $"Error when getting User data By Id. {ex.InnerException.Message}";

                return StatusCode(500, msg);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(UsersResponseModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            try
            {
                UsersResponseModel result = await _UsersService.GetByIdAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var msg = $"Error when getting User data By Id. {ex.Message}";
                
                if (ex.InnerException != null)
                    msg = $"Error when getting User data By Id. {ex.InnerException.Message}";

                return StatusCode(500, msg);
            }
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(Users), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateUser([FromBody] UsersRequestModel data)
        {
            try
            {
                Users result = await _UsersService.CreateAsync(data);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var msg = $"Error when creating User data. {ex.Message}";

                if (ex.InnerException != null)
                    msg = $"Error when creating User data. {ex.InnerException.Message}";

                return StatusCode(500, msg);
            }
        }

        [HttpPost]
        [Route("sign-in")]
        [ProducesResponseType(typeof(Users), StatusCodes.Status200OK)]
        public async Task<IActionResult> SignInUser([FromBody] SignInRequestModel data)
        {
            try
            {
                UsersResponseModel result = await _UsersService.SignInAsync(data);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var msg = $"Error when creating User data. {ex.Message}";

                if (ex.InnerException != null)
                    msg = $"Error when creating User data. {ex.InnerException.Message}";

                return StatusCode(500, msg);
            }
        }
    }
}
