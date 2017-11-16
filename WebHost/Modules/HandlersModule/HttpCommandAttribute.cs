using System;
using System.ComponentModel.Composition;

namespace WebHost.Modules.HandlersModule
{
    public interface IHttpCommandAttribute
    {
        string Url { get; }
    }

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Method)]
    public class HttpCommandAttribute : ExportAttribute, IHttpCommandAttribute
    {
        public HttpCommandAttribute(string url) : base("{DD74B74D-BEDD-48EC-981C-D85FEEBC55A6}", typeof(Func<HttpRequestParams, object>))
        {
            Url = url;
        }

        public string Url { get; }
    }
}