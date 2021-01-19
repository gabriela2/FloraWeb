using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IFlowerRepository
    {
         Task<Flower> GetFlowerByIdAsync(int id);
         Task<IReadOnlyList<Flower>> GetFlowersAsync();
         Task<FlowerCategory> GetFlowerCategoryByIdAsync(int id);
         Task<IReadOnlyList<FlowerCategory>> GetFlowerCategoriesAsync();
         Task<FlowerType> GetFlowerTypeByIdAsync(int id);
         Task<IReadOnlyList<FlowerType>> GetFlowerTypesAsync();
    }
}