
using Kachow.Server.Data.Models;
using Kachow.Server.Services;
using Kachow.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace Kachow.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelNameController : ControllerBase
    {
        private readonly ParcelNameService _context;

        public ParcelNameController(ParcelNameService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParcelName>>> GetParcelName()
        {
            return await _context.GetParcelNames();
        }

        [HttpPost]
        public async Task<ActionResult<ParcelName>> PostParcelName([FromBody] ParcelNameDTO name)
        {
            var result = await _context.AddParcelName(name);
            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }
    }
}

