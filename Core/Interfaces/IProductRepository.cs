using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
         Task<Product> GetProductByIdAsync(int id);
         Task<IReadOnlyList<Product>> GetProductsAsync();
         Task<FlowerCategory> GetFlowerCategoryByIdAsync(int id);
         Task<IReadOnlyList<FlowerCategory>> GetFlowerCategoriesAsync();
         Task<FlowerType> GetFlowerTypeByIdAsync(int id);
         Task<IReadOnlyList<FlowerType>> GetFlowerTypesAsync();
    }
}