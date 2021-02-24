using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        //IProductService tipinde bir nesne oluşturduk.
        IProductService _productService;
        //IProductService , gevşek bağlılık loosely coupled.
        //Soyut bağlılığı manager değişince , service sorun değil . 
        //Constructor nesnesine erişemediğimiz için , bu yüzden bir variable a eşitledik...

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]

        //HTTP get tipinde get methodu yazıldı.
        public IActionResult GetAll()
        {

            var result = _productService.getAllProducts();
            if(result.Success == true )
            {
                //İşlem başarılı ise , data ve 200 gönderiyor.
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
                
        }
        [HttpGet("getbyid")]
        public IActionResult GetByID(int productID)
        {
            var result = _productService.getProductByID(productID);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Data);
            }
        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
