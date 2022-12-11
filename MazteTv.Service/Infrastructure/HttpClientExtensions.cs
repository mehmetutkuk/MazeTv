using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MazteTv.Service.Infrastructure
{
    public static class HttpClientExtensions
    {
        public static async Task<TInput?> Send<TInput, TException>(this HttpClient client, HttpRequestMessage requestMessage,
          Func<string, string, string, HttpStatusCode, TException> getException = null) where TException : Exception
        {
            using var response = await client.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);


            if (response.StatusCode.Equals(HttpStatusCode.TooManyRequests))
            {
                Thread.Sleep(5000);
            }

            if (getException != null && !response.IsSuccessStatusCode)
                throw getException(response.ReasonPhrase, requestMessage.RequestUri.ToString(), client.BaseAddress.ToString(), response.StatusCode);


            var content = await response.Content.ReadAsStringAsync();
            TInput data;

            if (response.Content == null) return default;

            try
            {
                var serializer = new CustomJsonSerializator();
                data = await serializer.Deserialize<TInput>(content);
            }
            finally
            {
                response.Dispose();
            }

            return data;
        }

        public static CustomException SetException(this string message, string path, string title, HttpStatusCode httpStatusCode)
        {
            var exception = new CustomException(path, message, title, httpStatusCode);
            return exception;
        }
        public static string BuildUri(this string url, NameValueCollection parameters)
        {
            string text = parameters.ToQueryString();
            return url + text;
        }

        public static string ToQueryString(this NameValueCollection nvc)
        {
            NameValueCollection nvc2 = nvc;
            string[] value2 = (from key in nvc2.AllKeys
                               from value in nvc2.GetValues(key)
                               select HttpUtility.UrlEncode(key) + "=" + HttpUtility.UrlEncode(value)).ToArray();
            return "?" + string.Join("&", value2);
        }
    }
}
