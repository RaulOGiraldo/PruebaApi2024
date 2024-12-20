using Microsoft.EntityFrameworkCore;
using PostgresSql.Data;
using Prueba.Core.DTOs;
using Prueba.Core.Interfaces;

namespace Prueba.Intrastructure.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly CompanyRauloswaldogiraldoContext _context;

        public ProductsRepository(CompanyRauloswaldogiraldoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var prods = await _context.Products.OrderBy(x => x.ProId).ToListAsync();
            return (prods);
        }

        public async Task<Product> Get(int Id)
        {
            var prods = await _context.Products.FirstOrDefaultAsync(x => x.ProId == Id && x.ProIsdeleted == false);
            return (prods);
        }
        public async Task<bool> Insert(Product product)
        {
            _context.Add(product);
            var regs = await _context.SaveChangesAsync();
            return (regs > 0);

        }
        public async Task<bool> Update(int Id, ProductDTO productDTO)
        {
            var currentUser = await Get(Id);
            currentUser.ProName = productDTO.ProName;
            currentUser.ProStock = productDTO.ProStock;

            var regs = await _context.SaveChangesAsync();
            return (regs > 0);
        }

        public async Task<bool> Delete(int Id)
        {
            var currentUser = await Get(Id);
            currentUser.ProIsdeleted = true;

            var regs = await _context.SaveChangesAsync();
            return (regs > 0);
        }
    }
}
