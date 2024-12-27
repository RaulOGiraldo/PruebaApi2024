using InsttanttFlujos.Core.QueryFilters;
using Microsoft.AspNetCore.Mvc;
using Prueba.Api.Responses;
using Prueba.Core.DTOs;
using Prueba.Core.Helpers;
using Prueba.Core.Interfaces;

namespace Prueba.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _service;
        private readonly IAutoMapperData _mapper;
        private readonly IProductsService _productService;
        private readonly IUsersService _userService;

        public TransactionsController(ITransactionsService service, IAutoMapperData mapper, IProductsService productService, IUsersService userService)
        {
            _service = service;
            _mapper = mapper;
            _productService = productService;
            _userService = userService;
        }

        /// <summary>
        /// Obtinene todos los registros de Transactions
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TransactionsQueryFilter filters)
        {
            var result = await _service.GetAll(filters);
            if (result == null) { return NotFound(); }

            var listTransac = _mapper.MapearTransactions(result.ToList());
            var response = new ApiResponse<IEnumerable<TransactionDTO>>(listTransac);
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
            var trans = await _service.Get(Id);
            if (trans == null)
            {
                return NotFound();
            }

            var result = _mapper.MapearOneTransaction(trans);
            var response = new ApiResponse<TransactionDTO>(result);
            return Ok(response);
        }

        /// <summary>
        /// Inserta un registro de Transactions
        /// </summary>
        /// <param name="tbProveedor"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert(TransactionCreacionDTO transacCreacionDTO)
        {
            string menx = Tools.Constantes.FAIL_INSERT_MESSAGE;

            var prod = await _productService.Get(transacCreacionDTO.TraProId);
            if (prod != null) {
                if (_mapper.ValidarSaldo(prod, transacCreacionDTO) >= 0)
                {
                    var user = await _userService.Get(transacCreacionDTO.TraUseId);
                    if (_mapper.BuscarPermisos(user, 1)) // 1.Ingresar
                    {
                        var transac = _mapper.ConsultaDataTransaction(transacCreacionDTO, prod, user);
                        var respx = await _service.Insert(transac, prod.ProId);
                        if (respx) { menx = Tools.Constantes.SUCCESS_INSERT_MESSAGE; }
                    }
                    else { menx = "The user does not have permissions to perform this operation"; }
                } else { menx = "There is no balance available for that sale"; }
            } else {  menx = "The product ID does not exist";  }

            var response = new ApiResponse<string>(menx);
            return Ok(response);
        }

        /// <summary>
        /// Actualiza un registro mediante el Id de Transaction
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="tbProveedor"></param>
        /// <returns></returns>
        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> Update(int Id, TransactionDTO transactionDTO)
        //{
        //    string menx = Tools.Constantes.FAIL_UPDATE_MESSAGE;
        //    var trans = await _service.Get(Id);
        //    if (trans == null) { return NotFound(); }

        //    var respx = await _service.Update(Id, transactionDTO);
        //    if (respx) { menx = Tools.Constantes.SUCCESS_UPDATE_MESSAGE; }
        //    var response = new ApiResponse<string>(menx);
        //    return Ok(response);
        //}

        /// <summary>
        /// Elimina un registro mediante el Id de Transactions
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int Id, [FromQuery] EliminarTransacQueryFilter filtro)
        {
            string menx = Tools.Constantes.FAIL_DELETE_MESSAGE;
            var trans = await _service.Get(Id);
            if (trans == null) { return NotFound(); }

            var user = await _userService.Get(filtro.Usuario);
            if (user != null)
            {
                if (_mapper.BuscarPermisos(user, 3))  //3. Eliminar
                {
                    var respx = await _service.Delete(Id);
                    if (respx) { menx = Tools.Constantes.SUCCESS_DELETE_MESSAGE; }
                }
                else { menx = "The user does not have permissions to perform this operation"; }
            }
            else { menx = "That user id does not exist"; }

            var response = new ApiResponse<string>(menx);
            return Ok(response);
        }
    }
}
