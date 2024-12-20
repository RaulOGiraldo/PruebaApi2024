using InsttanttFlujos.Core.QueryFilters;
using PostgresSql.Data;
using Prueba.Core.DTOs;

namespace Prueba.Core.Interfaces
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAll(ProductQueryFilter filters);
        Task<Product> Get(int Id);
        Task<bool> Insert(Product product);
        Task<bool> Update(int Id, ProductDTO productDTO);
        Task<bool> Delete(int Id);
    }
}
