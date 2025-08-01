
namespace BrcFoodApp.WebApi.Dtos.FeatureDtos
{
    public class GetByIdFeatureDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }
    }
}