using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsingStatusesController : ControllerBase
    {
        IUsingStatusService _usingStatusService;
        public UsingStatusesController(IUsingStatusService usingStatusService)
        {
            _usingStatusService = usingStatusService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _usingStatusService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _usingStatusService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(UsingStatus usingStatus)
        {
            var result = _usingStatusService.Add(usingStatus);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(UsingStatus usingStatus)
        {
            var result = _usingStatusService.Delete(usingStatus);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(UsingStatus usingStatus)
        {
            var result = _usingStatusService.Update(usingStatus);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }

}
