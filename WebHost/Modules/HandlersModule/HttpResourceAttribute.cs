using System;
using System.ComponentModel.Composition;
using System.Reflection;

namespace WebHost.Modules.HandlersModule
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public abstract class HttpResourceAttribute : ExportAttribute
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