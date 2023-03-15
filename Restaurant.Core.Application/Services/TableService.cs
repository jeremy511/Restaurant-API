using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Application.Interfaces.Service;
using Restaurant.Core.Application.ViewModels.Table;
using Restaurant.Core.Domain.Entities;
using AutoMapper;

namespace Restaurant.Core.Application.Services
{
    public class TableService : GenericService<SaveTableViewModel,TableViewModel,Table>, ITableService
    {
        private readonly ITableRepository _repository;
        private readonly IMapper _mapper;

        public TableService(ITableRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
