using Azure.Core;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace WebAPI.Controllers
{
    //Route=what kind of request.
    [Route("api/[controller]")]

    //ATTRIBUTE=it is givings us about class information...
    [ApiController] 
    public class CarsController : ControllerBase
    {
        //Loosely Coupled
        ICarService _carService; 
        public CarsController(ICarService carService)
        {
            //naming convencion
            _carService = carService;
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {

            var result = _carService.Add(car);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]

        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]

        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                //we used datas with HTTP protocols 
                return Ok(result);
            }
            return BadRequest(result);
        }
        

        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _carService.GetsCarsId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
