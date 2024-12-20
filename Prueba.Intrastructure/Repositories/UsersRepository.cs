using Microsoft.EntityFrameworkCore;
using PostgresSql.Data;
using Prueba.Core.DTOs;
using Prueba.Core.Interfaces;

namespace Prueba.Intrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly CompanyRauloswaldogiraldoContext _context;
        private readonly IAutoMapperData mapper;

        public UsersRepository(CompanyRauloswaldogiraldoContext context, IAutoMapperData mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _context.Users.
                                Include(x => x.UsersInRoles).ThenInclude(x => x.Rol)
                                .OrderBy(x => x.UseId).ToListAsync();

            return (users);
        }

        public async Task<User> Get(int Id)
        {
            var user = await _context.Users.Include(x => x.UsersInRoles).ThenInclude(x => x.Rol)
                                .FirstOrDefaultAsync(x => x.UseId == Id);
            return (user);
        }
        public async Task<bool> Insert(UserCreacionDTO userCreacionDTO)
        {
            var users = mapper.DevolverUsersInRoles(userCreacionDTO);

            _context.Add(users);
            var regs = await _context.SaveChangesAsync();
            return (regs > 0);

        }
        public async Task<bool> Update(int Id, UserCreacionDTO userCreacionDTO)
        {
            var currentUser = await Get(Id);
            if (currentUser != null)
            {
                userCreacionDTO.UseId = Id;
            }
            
            var result = mapper.DevolverUsersInRoles(userCreacionDTO);
            currentUser.UseName = result.UseName;
            currentUser.UseDocument = result.UseDocument;
            currentUser.UsersInRoles = result.UsersInRoles; 

            var regs = await _context.SaveChangesAsync();
            return (regs > 0);
        }

        //public async Task<bool> Delete(string Id)
        //{
        //    var regs = await _context.DeleteOneAsync(p => p.Nit == Id);
        //    return (regs.DeletedCount >= 1 ? true : false);
        //}
    }
}
