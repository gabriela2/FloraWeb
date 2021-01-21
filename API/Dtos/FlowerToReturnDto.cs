namespace API.Dtos
{
    public class FlowerToReturnDto
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string FlowerType { get; set; }
        public string FlowerCategory { get; set; }
           
    }
}