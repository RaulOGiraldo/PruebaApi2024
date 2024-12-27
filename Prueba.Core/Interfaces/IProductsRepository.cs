using PostgresSql.Data;
using Prueba.Core.DTOs;

namespace Prueba.Core.Interfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Get(int Id);
        Task<bool> Insert(ProductCreacionDTO product);
        Task<bool> Update(int Id, ProductDTO productDTO);
        Task<bool> Delete(int Id);
    }
}
