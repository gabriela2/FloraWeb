namespace Core.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public FlowerType FlowerType { get; set; }
        public int FlowerTypeId { get; set; }
        public FlowerCategory FlowerCategory { get; set; }
        public int FlowerCategoryId { get; set;} 
    }
}