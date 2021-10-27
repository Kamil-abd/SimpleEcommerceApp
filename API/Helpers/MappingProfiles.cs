using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.OrderAggregate;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(dest => dest.ProductBrand, 
                    opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dest => dest.ProductType,
                    opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(dest => dest.PictureUrl, 
                    opt => opt.MapFrom<ProducUrlResolver>());
            CreateMap<Core.Identity.Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<AddressDto, Core.Entities.OrderAggregate.Address>();
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(dest => dest.DeliveryMethod,
                    opt => opt.MapFrom(src => src.DeliveryMethod.ShortName))
                .ForMember(dest => dest.ShippingPrice, 
                    opt => opt.MapFrom(src => src.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductId,
                    opt => opt.MapFrom(src => src.ItemOrdered.ProductItemId))
                .ForMember(dest => dest.ProductName,
                    opt => opt.MapFrom(src => src.ItemOrdered.ProductName))
                .ForMember(dest => dest.PictureUrl,
                    opt => opt.MapFrom(src => src.ItemOrdered.PictureUrl))
                    .ForMember(dest => dest.PictureUrl,
                    opt => opt.MapFrom<OrderItemUrlResolver>());
            CreateMap<Photo, PhotoToReturnDto>()
                .ForMember(d => d.PictureUrl,
                    o => o.MapFrom<PhotoUrlResolver>());
        }
    }
}