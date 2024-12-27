using InsttanttFlujos.Core.QueryFilters;
using PostgresSql.Data;
using Prueba.Core.DTOs;
using Prueba.Core.Interfaces;

namespace Prueba.Core.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _repository;
        public ProductsService(IProductsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAll(ProductQueryFilter filters)
        {
            var prods = await _repository.GetAll();
            if (filters.Tipo == "E")
            {
                prods = prods.Where(x => x.ProIsdeleted == true);
            }
            if (filters.Tipo == "A")
            {
                prods = prods.Where(x => x.ProIsdeleted == false);
            }

            return prods;
        }

        public async Task<Product> Get(int Id)
        {
            return await _repository.Get(Id);
        }

        public async Task<bool> Insert(ProductCreacionDTO product)
        {
            var regx = await _repository.Insert(product);
            return regx;
        }
        public async Task<bool> Update(int Id, ProductDTO productDTO)
        {
            return await _repository.Update(Id, productDTO);
        }

        public async Task<bool> Delete(int Id)
        {
            return await _repository.Delete(Id);
        }
    }
}
