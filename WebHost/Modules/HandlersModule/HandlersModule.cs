using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebHost.Modules.HandlersModule
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    internal class HandlersModule
    {
        private readonly AppFunc _next;
        private readonly ConcurrentDictionary<string, IHandler> _handlers;
       
        public HandlersModule(AppFunc next, ConcurrentDictionary<string, IHandler> handlers)
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