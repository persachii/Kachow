
using Kachow.Server.Data.Models;
using Kachow.Server.Services;
using Kachow.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;



namespace Kachow.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelController : ControllerBase
    {
        private readonly ParcelService _context;

        public ParcelController(ParcelService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parcel>>> GetParcels()
        {

            try
            {
                var parcels = await _context.GetParcels();


                if (parcels == null)
                {
                    return NotFound();
                }
                return parcels;


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");

            }
            /*
            return await _context.GetParcels(); */
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Parcel>> GetParcel(int id)
        {
            try
            {
                var parcel = await _context.GetParcel(id);

                if (parcel == null)
                {
                    return NotFound();
                }

                return parcel;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");

            }
        } 

        [HttpPost]
        public async Task<ActionResult<Parcel>> PostParcel([FromBody] ParcelDTO parcel)
        {
            var result = await _context.AddParcel(parcel);
            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParcel(int id)
        {
            var parcel = await _context.DeleteParcel(id);
            if (parcel)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("trackedparcel")]
        public async Task<ActionResult<List<TrackedParcelDTO>>> GetTrackedParcels()
        {
            try
            {
                var parcels = await _context.GetTrackedParcels();
                if (parcels == null)
                {
                    return NotFound();
                }

                return parcels;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");

            }
            //return await _context.GetTrackedParcels();
        }

        [HttpGet("trackedparcel/{id}")]
        public async Task<ActionResult<TrackedParcelDTO>> GetTrackedParcel(int id)
        {
            try
            {
                var parcel = await _context.GetTrackedParcel(id);
                if (parcel == null)
                {
                    return NotFound();
                }

                return parcel;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");

            }

            //return await _context.GetTrackedParcel(id);
        }

    }

}


