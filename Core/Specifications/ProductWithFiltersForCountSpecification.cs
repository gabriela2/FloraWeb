using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecification :BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams):
            base( x =>
                (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search))&&
                (!productParams.CategoryId.HasValue || x.FlowerCategoryId == productParams.CategoryId) &&
                (!productParams.TypeId.HasValue || x.FlowerTypeId == productParams.TypeId)
            )
        {
        }
    }
}