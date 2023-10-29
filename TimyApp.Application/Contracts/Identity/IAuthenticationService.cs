using TimyApp.Application.Models.Authentication;
using TimyApp.Application.Models.Identity;

namespace TimyApp.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Login(AuthenticationRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
