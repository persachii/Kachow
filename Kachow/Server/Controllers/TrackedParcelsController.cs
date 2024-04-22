
using Microsoft.AspNetCore.Mvc;

using Kachow.Server.Services;
using Kachow.Shared.DTOs;

namespace Kachow.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackedParcelController : ControllerBase
    {
        private readonly ParcelService _context;

        public TrackedParcelController(ParcelService context)
        {
            _context = context;
        }




    }
}

