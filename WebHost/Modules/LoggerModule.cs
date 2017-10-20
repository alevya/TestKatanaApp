using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Owin.Types;


namespace WebHost.Modules
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    internal class LoggerModule
    {
        private readonly AppFunc _next;
        private readonly string _prefix;
        public LoggerModule(AppFunc next, string prefix)
        {
            _next = next ?? throw new ArgumentNullException("next");
            _prefix = !string.IsNullOrEmpty(prefix) ? prefix : throw new ArgumentException("Parameter <prefix> cannot be null or empty");

        }

        public Task Invoke(IDictionary<string, object> env)
        {
            try
            {
                Debug.WriteLine("{0} Request: {1}", _prefix, env[OwinConstants.RequestPath]);
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