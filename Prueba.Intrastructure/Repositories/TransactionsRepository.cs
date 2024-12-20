using Microsoft.EntityFrameworkCore;
using PostgresSql.Data;
using Prueba.Core.DTOs;
using Prueba.Core.Interfaces;

namespace Prueba.Intrastructure.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly CompanyRauloswaldogiraldoContext _context;
        private readonly IProductsRepository _repositoryProd;

        public TransactionsRepository(CompanyRauloswaldogiraldoContext context, IProductsRepository repository)
        {
            _context = context;
            _repositoryProd = repository;
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            var trans = await _context.Transactions.Include(x => x.TraProductos)
                                .Include(x => x.User).ThenInclude(x => x.UsersInRoles).ThenInclude(x => x.Rol)
                                .OrderBy(x => x.TraId).ToListAsync();
            return (trans);
        }

        public async Task<Transaction> Get(int Id)
        {
            var trans = await _context.Transactions
                                .Include(x => x.User).ThenInclude(x => x.UsersInRoles).ThenInclude(x => x.Rol)
                                .FirstOrDefaultAsync(x => x.TraId == Id && x.TraIsDeleted == false);
            return (trans);
        }
        public async Task<bool> Insert(Transaction transaction, int prod)
        {
            _context.Add(transaction);
            var regs = await _context.SaveChangesAsync();
            if (regs > 0)
            {
                var consProd = await _repositoryProd.Get(prod);
                ProductDTO productDTO = new ProductDTO();
                productDTO.ProId = prod;
                productDTO.ProName = consProd.ProName;
                productDTO.ProStock = (consProd.ProStock - transaction.TraUnits);
                var result = await _repositoryProd.Update(prod, productDTO);
            }
            return (regs > 0);

        }
        public async Task<bool> Update(int Id, TransactionDTO transactionDTO)
        {
            var currentTra = await Get(Id);
            currentTra.TraProId = transactionDTO.TraProId;
            currentTra.TraDate = transactionDTO.TraDate;
            currentTra.TraUnits = transactionDTO.TraUnits;

            var regs = await _context.SaveChangesAsync();
            return (regs > 0);
        }

        public async Task<bool> Delete(int Id)
        {
            var currentTra = await Get(Id);
            currentTra.TraIsDeleted = true;

            var regs = await _context.SaveChangesAsync();
            if (regs > 0)
            {
                var consProd = await _repositoryProd.Get(Id);
                ProductDTO productDTO = new ProductDTO();
                productDTO.ProId = Id;
                productDTO.ProName = consProd.ProName;
                productDTO.ProStock = (consProd.ProStock + currentTra.TraUnits);
                var result = await _repositoryProd.Update(Id, productDTO);
            }
            return (regs > 0);
        }
    }
}
