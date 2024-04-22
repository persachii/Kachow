using Kachow.Server.Data.Models;
using Kachow.Server.Services;
using Kachow.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Kachow.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryMethodController : ControllerBase
    {
        private readonly DeliveryMethodService _context;

        public DeliveryMethodController(DeliveryMethodService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryMethod>>> GetDeliveryMethod()
        {
            return await _context.GetDeliveryMethods();
        }

        [HttpPost]
        public async Task<ActionResult<DeliveryMethod>> PostDeliveryMethod([FromBody] DeliveryMethodDTO method)
        {
            var result = await _context.AddDeliveryMethod(method);
            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }

    }
}

