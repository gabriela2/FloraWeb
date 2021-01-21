using Core.Entities;

namespace Core.Specifications
{
    public class FlowerWithFiltersForCountSpecification :BaseSpecification<Flower>
    {
        public FlowerWithFiltersForCountSpecification(FlowerSpecParams flowerParams):
            base( x =>
                (string.IsNullOrEmpty(flowerParams.Search) || x.Name.ToLower().Contains(flowerParams.Search))&&
                (!flowerParams.CategoryId.HasValue || x.FlowerCategoryId == flowerParams.CategoryId) &&
                (!flowerParams.TypeId.HasValue || x.FlowerTypeId == flowerParams.TypeId)
            )
        {
        }
    }
}