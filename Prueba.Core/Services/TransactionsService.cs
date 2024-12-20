using InsttanttFlujos.Core.QueryFilters;
using PostgresSql.Data;
using Prueba.Core.DTOs;
using Prueba.Core.Interfaces;

namespace Prueba.Core.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsRepository _repository;
        public TransactionsService(ITransactionsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Transaction>> GetAll(TransactionsQueryFilter filters)
        {
            // Para busqueda por Estado
            var trans = await _repository.GetAll();
            if (filters.Tipo == "E")
            {
                trans = trans.Where(x => x.TraIsDeleted == true);
            }
            if (filters.Tipo == "A")
            {
                trans = trans.Where(x => x.TraIsDeleted == false);
            }

            // Para busqueda por Producto
            if (filters.ProductId > 0)
            {
                trans = trans.Where(x => x.TraProId == filters.ProductId);
            }

            // Para busqueda por Usuario
            if (filters.UsuarioId > 0)
            {
                trans = trans.Where(x => x.TraUseId == filters.UsuarioId);
            }

            return trans;
        }

        public async Task<Transaction> Get(int Id)
        {
            return await _repository.Get(Id);
        }

        public async Task<bool> Insert(Transaction transactionCreacionDTO, int prod)
        {
            var regx = await _repository.Insert(transactionCreacionDTO, prod);
            return regx;
        }
        public async Task<bool> Update(int Id, TransactionDTO transactionDTO)
        {
            return await _repository.Update(Id, transactionDTO);
        }

        public async Task<bool> Delete(int Id)
        {
            return await _repository.Delete(Id);
        }
    }
}
