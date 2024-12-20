using PostgresSql.Data;
using Prueba.Core.DTOs;

namespace Prueba.Core.Interfaces
{
    public interface IUsersService
    {
        Task<List<User>> GetAll();
        Task<User> Get(int Id);
        Task<bool> Insert(UserCreacionDTO tbCampo);
        Task<bool> Update(int Id, UserCreacionDTO userCreacionDTO);

        //Task<bool> Delete(string Id);
    }
}
