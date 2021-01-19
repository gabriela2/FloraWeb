using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlowersController : ControllerBase
    {
        private readonly IFlowerRepository _repo;

        public FlowersController(IFlowerRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult<List<Flower>>> GetFlowers()
        {
            var flowers = await _repo.GetFlowersAsync();
            return Ok(flowers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Flower>> GetFlower(int id)
        {
            return await _repo.GetFlowerByIdAsync(id);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<List<FlowerCategory>>> GetFlowerCategories()
        {
            var categories = await _repo.GetFlowerCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("categories/{id}")]
        public async Task<ActionResult<FlowerCategory>> GetFlowerCategory(int id)
        {
            return await _repo.GetFlowerCategoryByIdAsync(id);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<FlowerType>>> GetFlowerTypes()
        {
            var types = await _repo.GetFlowerTypesAsync();
            return Ok(types);
        }

        [HttpGet("types/{id}")]
        public async Task<ActionResult<FlowerType>> GetFlowerType(int id)
        {
            return await _repo.GetFlowerTypeByIdAsync(id);
        }




    }
}