using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class FlowerRepository : IFlowerRepository
    {
        private readonly StoreContext _context;
        public FlowerRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<FlowerCategory> GetFlowerCategoryByIdAsync(int id)
        {
            return await _context.FlowerCategories.FindAsync(id);;
        }

        public async Task<IReadOnlyList<FlowerCategory>> GetFlowerCategoriesAsync()
        {
            return await _context.FlowerCategories.ToListAsync();
        }

        public async Task<Flower> GetFlowerByIdAsync(int id)
        {
            
            return await _context.Flowers.Include(p => p.FlowerType).Include(p => p.FlowerCategory).FirstOrDefaultAsync(p => p.Id==id);
        }

        public async Task<IReadOnlyList<Flower>> GetFlowersAsync()
        {
            return await _context.Flowers.Include(p => p.FlowerType).Include(p => p.FlowerCategory).ToListAsync();
        }

        public async Task<FlowerType> GetFlowerTypeByIdAsync(int id)
        {
            return await _context.FlowerTypes.FindAsync(id);
        }

        public async Task<IReadOnlyList<FlowerType>> GetFlowerTypesAsync()
        {
             return await _context.FlowerTypes.ToListAsync();
        }
    }
}