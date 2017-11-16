using System.Threading.Tasks;
using Microsoft.Owin;

namespace WebHost.Modules.HandlersModule
{
    public interface IHandler
    {
        Task ProcesseRequest(OwinRequest request);
    }
}
