using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace AremtyListener
{
    public class Error404Module
    {
        private readonly Func<IDictionary<string, object>, Task> next;

        public Error404Module(Func<IDictionary<string, object>, Task> next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public Task Invoke(IDictionary<string, object> env)
        {
            var body = Encoding.UTF8.GetBytes("404");

            var response = new OwinResponse(env)
            {
                ReasonPhrase = "",
                StatusCode = 404,
                ContentType = "text/plain;charset=utf-8",
                ContentLength = body.Length
            };

            return response.WriteAsync(body);
        }

    }
}
