using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace WebHost.Modules.HandlersModule
{
    public class ResourceHandler : IHandler
    {
        private readonly object _lockObject = new object();
        private WeakReference<byte[]> _resWeakReference;
        private readonly Assembly _assembly;
        private readonly HttpResourceAttribute _attribute;

        public ResourceHandler(Assembly assembly, HttpResourceAttribute attribute)
        {
            _assembly = assembly;
            _attribute = attribute;
        }

        public Task ProcesseRequest(OwinRequest request)
        {
            var resource = _getResource();
            var response = new OwinResponse(request.Environment)
            {
                ContentType = _attribute.ContentType,
                ContentLength = resource.Length
            };

            return response.WriteAsync(resource);
        }

        private byte[] _getResource()
        {
            byte[] resBytes;

            if (_resWeakReference != null && _resWeakReference.TryGetTarget(out resBytes)) return resBytes;
            lock (_lockObject)
            {
                if (_resWeakReference != null && _resWeakReference.TryGetTarget(out resBytes)) return resBytes;

                resBytes = _attribute.GetContent(_assembly);
                _resWeakReference = new WeakReference<byte[]>(resBytes);
            }
            return resBytes;
        }
    }
}