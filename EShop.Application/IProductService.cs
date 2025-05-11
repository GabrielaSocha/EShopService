using EShop.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Application
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllAsync();
        Task<Product> GetAsync(int id);
        Task<Product> UpdateAsync(Product product);
        Task<Product> AddAsync(Product product);
        Product Add(Product product);
    }
}
