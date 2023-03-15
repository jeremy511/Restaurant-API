using Restaurant.Core.Application.Dtos.Account;

namespace Restaurant.Core.Application.Interfaces.Account
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task LogOutAsync();
        Task<RegisterResponse> RegisterWaiterAsync(RegisterRequest request);

        Task<RegisterResponse> RegisterAdminAsync(RegisterRequest request);
    }
}