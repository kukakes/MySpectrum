using System.Threading.Tasks;
using MySpectrum.Core.Models;
using MySpectrum.Core.Services;

namespace MySpectrum.Services
{
    public class LoginService : ILoginService
    {
        public Task<bool> PerformLogin(string userName, string password) =>
            PerformRemoteLogin(new LoginRequest()
            {
                UserName = userName,
                Password = password
            });

        private Task<bool> PerformRemoteLogin(LoginRequest loginRequest) =>
            Task.FromResult(true);
    }
}