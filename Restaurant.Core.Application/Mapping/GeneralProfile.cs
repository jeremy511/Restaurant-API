using Restaurant.Core.Application.Dtos.Account;
using Restaurant.Core.Application.ViewModels.Table;
using Restaurant.Core.Application.ViewModels.Users;
using Restaurant.Core.Domain.Entities;
using AutoMapper;


namespace Restaurant.Core.Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile ()
        {
            CreateMap<AuthenticationRequest, LoginViewModel>()
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, SaveUserViewModel>()
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Dish, SaveDishViewModel>()
                .ReverseMap()
                .ForMember(x => x.CreatedDate, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Dish, DishViewModel>()
               .ReverseMap()
               .ForMember(x => x.CreatedDate, opt => opt.Ignore())
               .ForMember(x => x.CreatedBy, opt => opt.Ignore())
               .ForMember(x => x.LastModified, opt => opt.Ignore())
               .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Table, SaveTableViewModel>()
               .ReverseMap()
               .ForMember(x => x.CreatedDate, opt => opt.Ignore())
               .ForMember(x => x.CreatedBy, opt => opt.Ignore())
               .ForMember(x => x.LastModified, opt => opt.Ignore())
               .ForMember(x => x.Order, opt => opt.Ignore())
               .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Table, TableViewModel>()
              .ReverseMap()
              .ForMember(x => x.CreatedDate, opt => opt.Ignore())
              .ForMember(x => x.CreatedBy, opt => opt.Ignore())
              .ForMember(x => x.LastModified, opt => opt.Ignore())
              .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Ingredients, SaveIngredientViewModel>()
              .ReverseMap()
              .ForMember(x => x.CreatedDate, opt => opt.Ignore())
              .ForMember(x => x.CreatedBy, opt => opt.Ignore())
              .ForMember(x => x.LastModified, opt => opt.Ignore())
              .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Ingredients, IngredientViewModel>()
               .ReverseMap()
               .ForMember(x => x.CreatedDate, opt => opt.Ignore())
               .ForMember(x => x.CreatedBy, opt => opt.Ignore())
               .ForMember(x => x.LastModified, opt => opt.Ignore())
               .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Order, SaveOrderViewModel>()
               .ReverseMap()
               .ForMember(x => x.CreatedDate, opt => opt.Ignore())
               .ForMember(x => x.CreatedBy, opt => opt.Ignore())
               .ForMember(x => x.LastModified, opt => opt.Ignore())
               .ForMember(x => x.Table, opt => opt.Ignore())
               .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Order, OrderViewModel>()
              .ReverseMap()
              .ForMember(x => x.CreatedDate, opt => opt.Ignore())
              .ForMember(x => x.CreatedBy, opt => opt.Ignore())
              .ForMember(x => x.LastModified, opt => opt.Ignore())
              .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());


            CreateMap<OrderStatus, SaveOrderStatusViewModel>()
                .ReverseMap()
                .ForMember(x => x.Orders, opt => opt.Ignore());


            CreateMap<TableStatus, SaveTableStatusViewModel>()
               .ReverseMap()
               .ForMember(x => x.Tables, opt => opt.Ignore());

            CreateMap<DishCategory, SaveDishCategoryViewModel>()
              .ReverseMap()
              .ForMember(x => x.Dishes, opt => opt.Ignore());




        }
    }
}
