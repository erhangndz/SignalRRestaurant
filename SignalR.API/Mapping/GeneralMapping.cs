using AutoMapper;
using SignalR.DTO.Dtos.AboutDtos;
using SignalR.DTO.Dtos.BasketDtos;
using SignalR.DTO.Dtos.BookingDtos;
using SignalR.DTO.Dtos.CashBoxDtos;
using SignalR.DTO.Dtos.CategoryDtos;
using SignalR.DTO.Dtos.ContactDtos;
using SignalR.DTO.Dtos.DiscountDtos;
using SignalR.DTO.Dtos.FeatureDtos;
using SignalR.DTO.Dtos.MenuTableDtos;
using SignalR.DTO.Dtos.NotificationDtos;
using SignalR.DTO.Dtos.OrderDetailDtos;
using SignalR.DTO.Dtos.OrderDtos;
using SignalR.DTO.Dtos.ProductDtos;
using SignalR.DTO.Dtos.SocialMediaDtos;
using SignalR.DTO.Dtos.TestimonialDtos;
using SignalR.Entity.Entities;

namespace SignalR.API.Mapping
{
    public class GeneralMapping : Profile
    {

        public GeneralMapping()
        {
            CreateMap<CreateAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();
            CreateMap<ResultAboutDto, About>().ReverseMap();

            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<UpdateBookingDto, Booking>().ReverseMap();
            CreateMap<ResultBookingDto, Booking>().ReverseMap();

            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            CreateMap<ResultCategoryDto, Category>().ReverseMap();

            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();
            CreateMap<ResultContactDto, Contact>().ReverseMap();

            CreateMap<CreateDiscountDto, Discount>().ReverseMap();
            CreateMap<UpdateDiscountDto, Discount>().ReverseMap();
            CreateMap<ResultDiscountDto, Discount>().ReverseMap();

            CreateMap<CreateFeatureDto, Feature>().ReverseMap();
            CreateMap<UpdateFeatureDto, Feature>().ReverseMap();
            CreateMap<ResultFeatureDto, Feature>().ReverseMap();

            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
            CreateMap<ResultProductDto, Product>().ReverseMap();
            CreateMap<ResultProductWithCategoryDto, Product>().ReverseMap();

            CreateMap<CreateSocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<ResultSocialMediaDto, SocialMedia>().ReverseMap();

            CreateMap<CreateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();


            CreateMap<ResultOrderDto,Order>().ReverseMap();
            CreateMap<CreateOrderDto,Order>().ReverseMap();
            CreateMap<UpdateOrderDto,Order>().ReverseMap();

            CreateMap<ResultOrderDetailDto, OrderDetail>().ReverseMap();
            CreateMap<CreateOrderDetailDto, OrderDetail>().ReverseMap();
            CreateMap<UpdateOrderDetailDto, OrderDetail>().ReverseMap();

            CreateMap<CreateCashBoxDto,CashBox>().ReverseMap(); 
            CreateMap<UpdateCashBoxDto,CashBox>().ReverseMap(); 
            CreateMap<ResultCashBoxDto,CashBox>().ReverseMap(); 


            CreateMap<CreateMenuTableDto, MenuTable>().ReverseMap();
            CreateMap<UpdateMenuTableDto, MenuTable>().ReverseMap();
            CreateMap<ResultMenuTableDto, MenuTable>().ReverseMap();


            CreateMap<CreateBasketDto, Basket>().ReverseMap();
            CreateMap<UpdateBasketDto, Basket>().ReverseMap();

            CreateMap<CreateNotificationDto, Notification>().ReverseMap();
            CreateMap<UpdateNotificationDto, Notification>().ReverseMap();
        }
    }
}
