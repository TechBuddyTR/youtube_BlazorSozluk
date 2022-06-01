using BlazorSozluk.Common.Models.RequestModels;

namespace BlazorSozluk.WebApp.Infrastructure.Services.Interfaces;

public interface IIdentityService
{
    bool IsLoggedIn { get; }

    string GetUserToken();
    
    string GetUserName();

    Guid GetUserId();

    Task<bool> Login(LoginUserCommand command);
    
    void Logout();
}
