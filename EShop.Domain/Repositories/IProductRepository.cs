using EShop.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Domain.Repositories
{
    public interface IProductRepository
    {
        #region Product
        Task<Product> GetProductAsync(int id);
        Task<Product> AddProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product user);
        Task<List<Product>> GetAllProductAsync();
        #endregion

    }

}
