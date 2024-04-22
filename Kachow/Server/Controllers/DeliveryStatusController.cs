

using Kachow.Server.Data.Models;
using Kachow.Server.Services;
using Kachow.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kachow.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryStatusController : ControllerBase
    {
        private readonly DeliveryStatusService _context;

        public DeliveryStatusController(DeliveryStatusService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryStatus>>> GetDeliveryStatus()
        {
            return await _context.GetDeliveryStatuses();
        }

        [HttpPost]
        public async Task<ActionResult<DeliveryMethod>> PostDeliveryStatus([FromBody] DeliveryStatusDTO status)
        {
            var result = await _context.AddDeliveryStatus(status);
            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }

    }
}

