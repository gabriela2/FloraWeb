using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class FlowersWithTypesAndCategoriesSpecification : BaseSpecification<Flower>
    {
        public FlowersWithTypesAndCategoriesSpecification(FlowerSpecParams flowerParams)
            :base(x => 
            (string.IsNullOrEmpty(flowerParams.Search) || x.Name.ToLower().Contains(flowerParams.Search))&&
            (!flowerParams.CategoryId.HasValue || x.FlowerCategoryId==flowerParams.CategoryId)&&
            (!flowerParams.TypeId.HasValue || x.FlowerTypeId==flowerParams.TypeId)
            )
        {
            AddInclude(x => x.FlowerType);
            AddInclude(x => x.FlowerCategory);
            AddOrderBy(x => x.Name);
            ApplyPaging(flowerParams.PageSize * (flowerParams.PageIndex -1), flowerParams.PageSize);

            if(! string.IsNullOrEmpty(flowerParams.Sort))
            {
                switch(flowerParams.Sort){
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }

        }

        public FlowersWithTypesAndCategoriesSpecification(int id) : base(x =>x.Id == id)
        {
            AddInclude(x => x.FlowerType);
            AddInclude(x => x.FlowerCategory);
        }
    }
}