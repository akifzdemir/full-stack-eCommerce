using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        IOfferService _offerService;
        public OffersController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _offerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _offerService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getdetailsbyuser")]
        public IActionResult GetOffersByUserId(int userId)
        {
            var result = _offerService.GetOfferDetailsByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getdetailsbyproduct")]
        public IActionResult GetOffersByProductId(int productId)
        {
            var result = _offerService.GetOfferDetailsByProductId(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Offer offer)
        {
            var result = _offerService.Add(offer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Offer offer)
        {
            var result = _offerService.Delete(offer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Offer offer)
        {
            var result = _offerService.Update(offer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("updateisaccepted")]
        public IActionResult UpdateIsAccepted(int offerId,bool isAccepted)
        {
            var result = _offerService.UpdateIsAccepted(offerId, isAccepted);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
