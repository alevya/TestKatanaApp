using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebHost.Modules
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    internal class HandlersModule
    {
        private readonly AppFunc _next;
        private readonly Dictionary<string, IHandler> _handlers;

        public HandlersModule(AppFunc next, Dictionary<string, IHandler> handlers)
        {
            _next = next;
            _handlers = handlers;
        }

        public Task Invoke(IDictionary<string, object> env)
        {
            try
            {

            }
            catch (Exception e)
            {
                var tcs = new TaskCompletionSource<object>();
                tcs.SetException(e);
                return tcs.Task;
            }
            return _next(env);
        }
    }
}