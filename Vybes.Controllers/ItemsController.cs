using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VybesAPI.Vybes.ViewModel;
using VybesAPI.Vybes.Services;
using VybesAPI.Vybes.Domain;
using VybesAPI.Vybes.Persistence;


namespace VybesAPI.Vybes.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [ControllerName("Items")]
    [Route("api/v{version:apiVersion}/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly VybesContext _context;
        private readonly ItemsServices _ItemsService;

        public ItemsController(VybesContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            //var authorization = httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            var user = httpContextAccessor.HttpContext.Request.Headers["User"];
            _ItemsService = new ItemsServices(context, user);
        }


        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(List<ItemsResponseModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<ItemsResponseModel> result = await _ItemsService.GetAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                var msg = $"Error when getting Items data By Id. {ex.Message}";

                if (ex.InnerException != null)
                    msg = $"Error when getting Items data By Id. {ex.InnerException.Message}";

                return StatusCode(500, msg);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Items), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetItemsById([FromRoute] Guid id)
        {
            try
            {
                if (id == Guid.Empty || id == null) return BadRequest();

                ItemsResponseModel result = await _ItemsService.GetByIdAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var msg = $"Error when getting Items data By Id. {ex.Message}";

                if (ex.InnerException != null)
                    msg = $"Error when getting Items data By Id. {ex.InnerException.Message}";

                return StatusCode(500, msg);
            }
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(Items), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateItems([FromBody] ItemsRequestModel data)
        {
            try
            {
                Items result = await _ItemsService.CreateAsync(data);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var msg = $"Error when creating Items data. {ex.Message}";

                if (ex.InnerException != null)
                    msg = $"Error when creating Items data. {ex.InnerException.Message}";

                return StatusCode(500, msg);
            }
        }

        [HttpDelete]
        [Route("{itemsId}")]
        public async Task<IActionResult> DeleteItems([FromRoute] Guid itemsId)
        {
            try
            {
                if (itemsId == Guid.Empty || itemsId == null) return BadRequest();

                string result = await _ItemsService.DeleteByIdAsync(itemsId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var msg = $"Error when deleting Items data. {ex.Message}";

                if (ex.InnerException != null)
                    msg = $"Error when deleting Items data. {ex.InnerException.Message}";

                return StatusCode(500, msg);
            }
        }
    }
}
