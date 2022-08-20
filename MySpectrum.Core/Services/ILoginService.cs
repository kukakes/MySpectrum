using System.Threading.Tasks;

namespace MySpectrum.Core.Services
{
    public interface ILoginService
    {
        Task<bool> PerformLogin(string userName, string password);
    }
}