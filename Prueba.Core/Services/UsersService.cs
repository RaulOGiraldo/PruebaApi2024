using PostgresSql.Data;
using Prueba.Core.DTOs;
using Prueba.Core.Interfaces;

namespace Prueba.Core.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repository;
        public UsersService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _repository.GetAll();
            return users;
        }

        public async Task<User> Get(int Id)
        {
            return await _repository.Get(Id);
        }

        public async Task<bool> Insert(UserCreacionDTO user)
        {
            var regx = await _repository.Insert(user);
            return regx;
        }
        public async Task<bool> Update(int Id, UserCreacionDTO userCreacionDTO)
        {
            return await _repository.Update(Id, userCreacionDTO);
        }

        //public async Task<bool> Delete(string Id)
        //{
        //    return await _repository.Delete(Id);
        //}

    }
}
