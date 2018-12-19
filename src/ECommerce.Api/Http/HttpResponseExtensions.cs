using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ECommerce.Api.Http
{
    public static class HttpResponseExtensions
    {
        private static readonly JsonSerializer Serializer = new JsonSerializer
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public static async Task WriteJsonAsync(this HttpResponse @this, object value)
        {
            @this.ContentType = ContentTypes.JSON;
            var serializedValue = JsonConvert.SerializeObject(value);

            await @this.WriteAsync(serializedValue);
        }
    }
}
