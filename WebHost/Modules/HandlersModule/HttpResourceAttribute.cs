using System;
using System.Reflection;

namespace WebHost.Modules.HandlersModule
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public abstract class HttpResourceAttribute : Attribute
    {
        protected HttpResourceAttribute(string url, string contentType)
        {
            Url = url;
            ContentType = contentType;
        }

        public string Url { get; }

        public string ContentType { get; }

        public abstract byte[] GetContent(Assembly assembly);

    }
}