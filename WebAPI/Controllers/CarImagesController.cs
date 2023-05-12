using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        //Firstly Let's create the Loosely Coopled...
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }



        //Used add naming to understand
        [HttpPost("add")]
        //Used CarImage to added entity for database
        public IActionResult Add([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            //carimage coming from UI then added the system
            var result = _carImageService.Add(file,carImage);
            if (result.Success)
            {
                //http 200 code
                return Ok(result);
            }
            //http 400 code
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file , [FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(file, carImage);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            //We find the which Id in DataBase
            var carDeleteImage = _carImageService.GetById(carImage.Id).Data;
            //then we deleted in the database
            var result = _carImageService.Delete(carDeleteImage);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetbyId(int id)
        {
            var result = _carImageService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getimagebycarid")]
        public IActionResult GetImagesByCarId(int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
