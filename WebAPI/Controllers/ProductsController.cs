
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Business.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        private IStockControlService _stockControlService;
        public ProductsController
            (
                IProductService productService,
                IStockControlService stockControlService
            )
        {
            _productService = productService;
            _stockControlService = stockControlService;
        }


        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }

        [HttpPut("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title+" : "+result.Message);
        }


        [HttpGet("getallbycategoryid")]
        public IActionResult GetAllByCategoryId(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }


        [HttpGet("getallbyunitsinstockmin")]
        public IActionResult GetAllByUnitsInStockMin(short minStock)
        {
            var result = _productService.GetAllByUnitsInStock(minStock);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }

        [HttpGet("getallbyunitsinstock")]
        public IActionResult GetAllByUnitsInStock(short minStock, short maxStock)
        {
            var result = _productService.GetAllByUnitsInStock(minStock,maxStock);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }


        [HttpGet("getallbyunitpricemin")]
        public IActionResult GetAllByUnitPriceMin(decimal minPrice)
        {
            var result = _productService.GetAllByUnitPrice(minPrice);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }

        [HttpGet("getallbyunitprice")]
        public IActionResult GetAllByUnitPrice(decimal minPrice, decimal maxPrice)
        {
            var result = _productService.GetAllByUnitPrice(minPrice, maxPrice);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }


        [HttpGet("getallbyproductname")]
        public IActionResult GetAllByProductName(string productName)
        {
            var result = _productService.GetAllByProductName(productName);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result);
        }
        
    }
}
