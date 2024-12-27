using InsttanttFlujos.Core.QueryFilters;
using Microsoft.AspNetCore.Mvc;
using PostgresSql.Data;
using Prueba.Api.Responses;
using Prueba.Core.DTOs;
using Prueba.Core.Helpers;
using Prueba.Core.Interfaces;

namespace Prueba.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productService;

        public ProductsController(IProductsService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Obtinene todos los registros de Products
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ProductQueryFilter filters)
        {
            var pasos = await _productService.GetAll(filters);
            if (pasos == null) { return NotFound(); }

            var response = new ApiResponse<IEnumerable<Product>>(pasos);
            return Ok(response);
        }

        /// <summary>
        /// Obtiene un registro mediante el Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int Id)
        {
            var prod = await _productService.Get(Id);
            if (prod == null)
            {
                return NotFound();
            }
            var response = new ApiResponse<Product>(prod);
            return Ok(response);
        }

        /// <summary>
        /// Inserta un registro de Products
        /// </summary>
        /// <param name="tbProveedor"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert(ProductCreacionDTO product)
        {
            string menx = Tools.Constantes.FAIL_INSERT_MESSAGE;
            var respx = await _productService.Insert(product);
            if (respx) { menx = Tools.Constantes.SUCCESS_INSERT_MESSAGE; }
            var response = new ApiResponse<string>(menx);
            return Ok(response);
        }

        /// <summary>
        /// Actualiza un registro mediante el Id de Product
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="tbProveedor"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int Id, ProductDTO productDTO)
        {
            string menx = Tools.Constantes.FAIL_UPDATE_MESSAGE;
            var prod = await _productService.Get(Id);
            if (prod == null) { return NotFound(); }

            var respx = await _productService.Update(Id, productDTO);
            if (respx) { menx = Tools.Constantes.SUCCESS_UPDATE_MESSAGE; }
            var response = new ApiResponse<string>(menx);
            return Ok(response);
        }

        /// <summary>
        /// Elimina un registro mediante el Id de product
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            string menx = Tools.Constantes.FAIL_DELETE_MESSAGE;
            var prod = await _productService.Get(Id);
            if (prod == null) { return NotFound(); }

            var respx = await _productService.Delete(Id);
            if (respx) { menx = Tools.Constantes.SUCCESS_DELETE_MESSAGE; }
            var response = new ApiResponse<string>(menx);
            return Ok(response);
        }
    }
}
