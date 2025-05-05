using Data.Entity;
using System.Net;
using Data.Parameters.Product;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpGet("byId")]
        public async Task<IActionResult> GetById([FromQuery] GetProductByIdRequest request)
        {
            var responseService = await _service.GetById(request);
            var responseSuccess = new ResponseEntity
            {
                Ok = true,
                StatusCode = HttpStatusCode.OK,
                Body = responseService
            };
            return Ok(responseSuccess);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var responseService = await _service.GetAll();
            var responseSuccess = new ResponseEntity
            {
                Ok = true,
                StatusCode = HttpStatusCode.OK,
                Body = responseService
            };
            return Ok(responseSuccess);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                var response = new ResponseEntity
                {
                    Ok = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Error al agregar Producto",
                    Errors = errors,
                    Body = null
                };
                return BadRequest(response);
            }
            var responseService = await _service.Post(request);
            var responseSuccess = new ResponseEntity
            {
                Ok = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Producto agregado correctamente",
                Body = responseService
            };
            return Ok(responseSuccess);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                var response = new ResponseEntity
                {
                    Ok = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Error al actualizar Producto",
                    Errors = errors,
                    Body = null
                };
                return BadRequest(response);
            }
            var responseService = await _service.Update(request);
            var responseSuccess = new ResponseEntity
            {
                Ok = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Producto actualizado correctamente",
                Body = responseService
            };
            return Ok(responseSuccess);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteProductRequest request)
        {
            var responseService = await _service.Delete(request);
            var responseSuccess = new ResponseEntity
            {
                Ok = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Producto eliminado correctamente",
                Body = responseService
            };
            return Ok(responseSuccess);
        }
    }
}

