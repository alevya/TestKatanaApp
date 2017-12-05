using System.Reflection;
using System.Resources;

namespace WebHost.Modules.HandlersModule
{
    public class HttpEmbeddedResourceAttribute : HttpResourceAttribute
    {
        public HttpEmbeddedResourceAttribute(string url, string resourcePath,  string contentType = "text/plain") : base(url, contentType)
        {
            ResourcePath = resourcePath;
        }

        public string ResourcePath { get; }

        public override byte[] GetContent(Assembly assembly)
        {
            byte[] result;

            using (var stream = assembly.GetManifestResourceStream(ResourcePath))
            {
                if (stream != null)
                {
                    result = new byte[stream.Length];
                    stream.Read(result, 0, result.Length);
                }
                else
                {
                    var message = $"resource {ResourcePath} is not found";
                    throw new MissingManifestResourceException(message);
                }
            }

            return result;
        }
    }
}