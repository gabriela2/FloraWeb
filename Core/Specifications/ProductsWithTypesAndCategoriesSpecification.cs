using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndCategoriesSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndCategoriesSpecification(ProductSpecParams productParams)
            :base(x => 
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search))&&
            (!productParams.CategoryId.HasValue || x.FlowerCategoryId==productParams.CategoryId)&&
            (!productParams.TypeId.HasValue || x.FlowerTypeId==productParams.TypeId)
            )
        {
            AddInclude(x => x.FlowerType);
            AddInclude(x => x.FlowerCategory);
            AddOrderBy(x => x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex -1), productParams.PageSize);

            if(! string.IsNullOrEmpty(productParams.Sort))
            {
                switch(productParams.Sort){
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

        public ProductsWithTypesAndCategoriesSpecification(int id) : base(x =>x.Id == id)
        {
            AddInclude(x => x.FlowerType);
            AddInclude(x => x.FlowerCategory);
        }
    }
}