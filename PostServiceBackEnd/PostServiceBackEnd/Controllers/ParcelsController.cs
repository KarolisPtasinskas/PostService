using Microsoft.AspNetCore.Mvc;
using PostServiceBackEnd.DTO;
using PostServiceBackEnd.Filters;
using PostServiceBackEnd.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostServiceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelsController : ControllerBase
    {
        private readonly ParcelService _parcelService;

        public ParcelsController(ParcelService parcelService)
        {
            _parcelService = parcelService;
        }

        [HttpGet]
        public async Task<ActionResult<ActionResult<List<ParcelGetAllDTO>>>> GetAll([FromQuery] ParcelFilter parcelFilter)
        {
            try
            {
                var parcels = await _parcelService.GetAllAsync(parcelFilter);
                return Ok(parcels);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong. Please try again.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(ParcelPostDTO parcel)
        {
            try
            {
                await _parcelService.AddAsync(parcel);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong. Please try again.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParcelPutDTO>> GetById(int id)
        {
            try
            {
                var parcel = await _parcelService.GetByIdAsync(id);
                return Ok(parcel);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong. Please try again.");
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(ParcelPutDTO parcel)
        {
            try
            {
                await _parcelService.UpdateAsync(parcel);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong. Please try again.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _parcelService.Delete(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong. Please try again.");
            }
        }
    }
}
