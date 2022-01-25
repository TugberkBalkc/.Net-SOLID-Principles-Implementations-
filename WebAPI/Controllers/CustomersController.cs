using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            return result.Success == true
                 ? Ok(result)
                 : BadRequest(result.Title + " : " + result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.Delete(customer);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }

        [HttpPut("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }

        [HttpGet("getallbycityname")]
        public IActionResult GetAllByCityName(string cityName)
        {
            var result = _customerService.GetAllByCityName(cityName);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }

        [HttpGet("getallbycompanyname")]
        public IActionResult GetAllByCompanyName(string companyName)
        {
            var result = _customerService.GetAllByCompanyName(companyName);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }

        [HttpGet("getallbycontactname")]
        public IActionResult GetAllByContactName(string contactName)
        {
            var result = _customerService.GetAllByContactName(contactName);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(string id)                              
        {
            var result = _customerService.GetById(id);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }
    }
}
