using Microsoft.AspNetCore.Mvc;
using PostServiceBackEnd.DTO;
using PostServiceBackEnd.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostServiceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelMachinesController : ControllerBase
    {
        private readonly ParcelMachineService _parcelMachineService;

        public ParcelMachinesController(ParcelMachineService parcelMachineService)
        {
            _parcelMachineService = parcelMachineService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ParcelMachineGetAllDTO>>> GetAll()
        {
            return Ok(await _parcelMachineService.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult> AddDailyMenu(ParcelMachinePostDTO parcelMachine)
        {
            try
            {
                await _parcelMachineService.AddAsync(parcelMachine);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong. Please try again.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParcelMachinePutDTO>> GetById(int id)
        {
            try
            {
                var parcelMachine = await _parcelMachineService.GetByIdAsync(id);
                return Ok(parcelMachine);
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
        public async Task<ActionResult> Update(ParcelMachinePutDTO parcelMachine)
        {
            try
            {
                await _parcelMachineService.UpdateAsync(parcelMachine);
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
                await _parcelMachineService.Delete(id);
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
    }
}
