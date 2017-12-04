using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Newtonsoft.Json;

namespace WebHost.Modules.HandlersModule
{
    public class ApiHandler : IHandler
    {
        private readonly Func<HttpRequestParams, object> _action;

        public ApiHandler(Func<HttpRequestParams, object> action)
        {

            _action = action ?? throw new ArgumentNullException();
        }
       

        public Task ProcesseRequest(OwinRequest request)
        {
            var parameters = _getHttpRequestParams(request);
            var res = _action(parameters);
            var json = JsonConvert.SerializeObject(res);
            var jsonBytes = Encoding.UTF8.GetBytes(json);
            var response = new OwinResponse(request.Environment)
            {
                Headers =
                {
                    {"Cache-Control", new []{"no-store", "no-cache"}},
                    {"Pragma", new []{"no-cache"}}
                },
                ContentType = "application/json;charset=utf-8",
                ContentLength = jsonBytes.Length
            };
            return response.WriteAsync(jsonBytes);
        }

        private HttpRequestParams _getHttpRequestParams(IOwinRequest request)
        {
            var t = request.ReadFormAsync();
            t.Wait();
            
            return new HttpRequestParams(request.Query, t.Result);
        }
    }
}