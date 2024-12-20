using InsttanttFlujos.Core.QueryFilters;
using PostgresSql.Data;
using Prueba.Core.DTOs;

namespace Prueba.Core.Interfaces
{
    public interface ITransactionsService
    {
        Task<IEnumerable<Transaction>> GetAll(TransactionsQueryFilter filters);
        Task<Transaction> Get(int Id);
        Task<bool> Insert(Transaction transactionCreacionDTO, int prod);
        Task<bool> Update(int Id, TransactionDTO transactionDTO);
        Task<bool> Delete(int Id);
    }
}
