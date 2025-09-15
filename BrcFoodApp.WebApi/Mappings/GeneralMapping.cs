
using AutoMapper;
using BrcFoodApp.WebApi.Dtos.FeatureDtos;
using BrcFoodApp.WebApi.Dtos.MessageDtos;
using BrcFoodApp.WebApi.Dtos.NotificationDtos;
using BrcFoodApp.WebApi.Dtos.ProductDtos;
using BrcFoodApp.WebApi.Entities;

namespace BrcFoodApp.WebApi.Mappings
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();

            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
            CreateMap<Message, GetByIdMessageDto>().ReverseMap();


            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
            CreateMap<Notification, GetByIdNotificationDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>()
            .ForMember(x => x.CategoryName, y => y.MapFrom(c => c.Category.CategoryName)).ReverseMap();
        }
    }
}