using Data.Entity;
using System.Net;
using Data.Parameters.Category;
using Data.Parameters.Product;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        [HttpGet("byId")]
        public async Task<IActionResult> GetById([FromQuery] GetCategoryByIdRequest request)
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
        public async Task<IActionResult> Post([FromBody] PostCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                var response = new ResponseEntity
                {
                    Ok = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Error al crear categoría",
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
                Message = "Categoría creada correctamente",
                Body = responseService
            };
            return Ok(responseSuccess);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                var response = new ResponseEntity
                {
                    Ok = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Error al actualizar categoría",
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
                Message = "Categoría actualizada correctamente",
                Body = responseService
            };
            return Ok(responseSuccess);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteCategoryRequest request)
        {
            var responseService = await _service.Delete(request);
            var responseSuccess = new ResponseEntity
            {
                Ok = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Categoría eliminada correctamente",
                Body = responseService
            };
            return Ok(responseSuccess);
        }
    }
}
