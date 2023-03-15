using Restaurant.Core.Application.Dtos.Account;
using Restaurant.Core.Application.Interfaces.Account;
using Restaurant.Core.Application.ViewModels.Users;
using AutoMapper;

namespace Restaurant.Core.Application.Services.Users
{
    public class UserServices 
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        

        public UserServices (IAccountService accountService, IMapper mapper)
        {
           _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse>  LogInAsync(LoginViewModel vm)
        {
            AuthenticationRequest loginRequest = _mapper.Map<AuthenticationRequest>(vm);
            AuthenticationResponse  UserResponse = await _accountService.AuthenticateAsync(loginRequest);

            return UserResponse;
        }
    }
}
