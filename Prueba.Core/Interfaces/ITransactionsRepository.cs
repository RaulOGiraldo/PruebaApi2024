using PostgresSql.Data;
using Prueba.Core.DTOs;

namespace Prueba.Core.Interfaces
{
    public interface ITransactionsRepository
    {
        Task<IEnumerable<Transaction>> GetAll();
        Task<Transaction> Get(int Id);
        Task<bool> Insert(Transaction transaction, int prod);
        Task<bool> Update(int Id, TransactionDTO transactionDTO);
        Task<bool> Delete(int Id);
    }
}
