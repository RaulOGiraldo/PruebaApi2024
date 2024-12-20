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
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;
        private readonly IAutoMapperData _mapper;

        public UsersController(IUsersService userService, IAutoMapperData mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtinene todos los registros de Users
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            if (users == null) { return NotFound(); }

            var listUsers = _mapper.MapearUsersInRoles(users.ToList());
            var response = new ApiResponse<IEnumerable<UsersInRolesDTO>>(listUsers);
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
            var user = await _userService.Get(Id);
            if (user == null)
            {
                return NotFound();
            }
            var result = _mapper.MapearUserInRol(user);
            var response = new ApiResponse<UsersInRolesDTO>(result);
            return Ok(response);
        }

        /// <summary>
        /// Inserta un registro de Users
        /// </summary>
        /// <param name="tbProveedor"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert(UserCreacionDTO user)
        {
            string menx = Tools.Constantes.FAIL_INSERT_MESSAGE;
            var respx = await _userService.Insert(user);
            if (respx) { menx = Tools.Constantes.SUCCESS_INSERT_MESSAGE; }
            var response = new ApiResponse<string>(menx);
            return Ok(response);
        }

        /// <summary>
        /// Actualiza un registro mediante el Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="tbProveedor"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int Id, UserCreacionDTO userDTO)
        {
            string menx = Tools.Constantes.FAIL_UPDATE_MESSAGE;
            var user = await _userService.Get(Id);
            if (user == null) { return NotFound(); }

            //tbProveedor.Id = Id;
            var respx = await _userService.Update(Id, userDTO);
            if (respx) { menx = Tools.Constantes.SUCCESS_UPDATE_MESSAGE; }
            var response = new ApiResponse<string>(menx);
            return Ok(response);
        }

        /// <summary>
        /// Elimina un registro mediante el Nit
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(string Id)
        //{
        //    string menx = Tools.Constantes.FAIL_DELETE_MESSAGE;
        //    var flu = await _proveedorService.Get(Id);
        //    if (flu == null) { return NotFound(); }

        //    var respx = await _proveedorService.Delete(Id);
        //    if (respx) { menx = Tools.Constantes.SUCCESS_DELETE_MESSAGE; }
        //    var response = new ApiResponse<string>(menx);
        //    return Ok(response);
        //}
    }
}
