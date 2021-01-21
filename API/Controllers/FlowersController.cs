using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class FlowersController : BaseApiController
    {
        private readonly IGenericRepository<Flower> _flowersRepo;
        private readonly IGenericRepository<FlowerCategory> _flowersCategoriesRepo;
        private readonly IGenericRepository<FlowerType> _flowerTypesRepo;
        private readonly IMapper _mapper;

        public FlowersController(IGenericRepository<Flower> flowersRepo,
                                  IGenericRepository<FlowerCategory> flowerCategoriesRepo,
                                  IGenericRepository<FlowerType> flowerTypesRepo,
                                  IMapper mapper)
        {
            _mapper = mapper;
            _flowersRepo = flowersRepo;
            _flowersCategoriesRepo = flowerCategoriesRepo;
            _flowerTypesRepo = flowerTypesRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<FlowerToReturnDto>>> GetFlowers([FromQuery]FlowerSpecParams flowerParams)
        {
            var spec = new FlowersWithTypesAndCategoriesSpecification(flowerParams);
            var countSpec =  new FlowerWithFiltersForCountSpecification(flowerParams);
            var totalItems = await _flowersRepo.CountAsync(countSpec);
            var flowers = await _flowersRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Flower>, IReadOnlyList<FlowerToReturnDto>>(flowers);
            return Ok( new Pagination<FlowerToReturnDto>(flowerParams.PageIndex, flowerParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FlowerToReturnDto>> GetFlower(int id)
        {
            var spec = new FlowersWithTypesAndCategoriesSpecification(id);
            var flower = await _flowersRepo.GetEntityWithSpec(spec);
            if (flower == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<Flower, FlowerToReturnDto>(flower);

        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<FlowerCategory>>> GetFlowerCategories()
        {
            var flowerCategories = await _flowersCategoriesRepo.ListAllAsync();
            return Ok(flowerCategories);
        }

        [HttpGet("brands/{id}")]
        public async Task<ActionResult<FlowerCategory>> GetFlowerCategory(int id)
        {
            return await _flowersCategoriesRepo.GetByIdAsync(id);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<FlowerType>>> GetFlowerTypes()
        {
            var flowerTypes = await _flowerTypesRepo.ListAllAsync();
            return Ok(flowerTypes);
        }

        [HttpGet("types/{id}")]
        public async Task<ActionResult<FlowerType>> GetFlowerType(int id)
        {
            return await _flowerTypesRepo.GetByIdAsync(id);
        }




    }
}