using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Application.Interfaces.Service;
using Restaurant.Core.Application.ViewModels.Table;
using Restaurant.Core.Domain.Entities;
using AutoMapper;

namespace Restaurant.Core.Application.Services
{
    public class OrderService : GenericService<SaveOrderViewModel, OrderViewModel, Order>, IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;
        private readonly IDishRepository _dishRepository;

        public OrderService(IOrderRepository repository, IMapper mapper, IDishRepository dishRepository) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _dishRepository = dishRepository;
        }

        public async Task<List<OrderViewModel>> GetTableOrders(int tableId)
        {
            var OrderList = await _repository.GetAllWithIncludes(new List<string> { "Table", "OrderStatus"});
            
            return OrderList.Where(order => order.TableId == tableId && order.OrderStatusId == 2).Select(order => new OrderViewModel
            {
               Id = order.Id,
               OrderStatusId = order.OrderStatus.status,
               SelectedDish = order.SelectedDish,
               SubTotal = order.SubTotal,
               TableId = order.TableId
               

            }).ToList();
        }




        public async Task<List<OrderViewModel>> GetAllViewModel()
        {


            var list = await _repository.GetAllWithIncludes(new List<string> { "OrderStatus" });
            List<OrderViewModel> result = list.Select(all => new OrderViewModel
            {
                OrderStatusId = all.OrderStatus.status.ToString(),
                SelectedDish = all.SelectedDish,
                Id = all.Id,
                SubTotal = all.SubTotal,
                TableId = all.TableId,
                
            }).ToList();

            List<OrderViewModel> ResultD = new();

            foreach (var item in result)
            {

                List<string> dishes = new();
                string[] Ids = item.SelectedDish.Split(",");
                foreach (var i in Ids)
                {
                    Dish viewModel = await _dishRepository.GetViewModelById(Convert.ToInt32(i));
                    dishes.Add(viewModel.Name);

                }

                string str = String.Join(",", dishes);
                OrderViewModel dish = new();
                dish.Id = item.Id;
                dish.OrderStatusId = item.OrderStatusId;
                dish.SelectedDish = str;
                dish.SubTotal = item.SubTotal;
                dish.TableId = item.TableId;
            
                ResultD.Add(dish);



            }

            return ResultD;
        }


        public async Task<OrderViewModel> GetId(int id)
        {

            var list = await _repository.GetAllWithIncludes(new List<string> { "OrderStatus" });
            OrderViewModel result = list.Where(i => i.Id == id).Select(all => new OrderViewModel
            {
                OrderStatusId = all.OrderStatus.status.ToString(),
                SelectedDish = all.SelectedDish,
                Id = all.Id,
                SubTotal = all.SubTotal,
                TableId = all.TableId,

            }).FirstOrDefault();

            List<string> dishes = new();
            string[] Ids = result.SelectedDish.Split(",");
            foreach (var i in Ids)
            {
                Dish viewModel = await _dishRepository.GetViewModelById(Convert.ToInt32(i));
                dishes.Add(viewModel.Name);

            }
            string str = String.Join(",", dishes);
            result.SelectedDish = str;
            return result;
        }




    }



}
