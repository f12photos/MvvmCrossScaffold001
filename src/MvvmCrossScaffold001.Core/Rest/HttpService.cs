using System;
using System.Net.Http;
using System.Threading.Tasks;
using ModernHttpClient;
using Newtonsoft.Json;

namespace MvvmCrossScaffold001.Core.Rest
{
    public interface IHttpService
    {
        Task<T> ReadContentAsync<T>(HttpResponseMessage response);
    }

    public interface IBaseHttpService
    {
        Task<HttpResponseMessage> PostAsync(string url, object obj);
        Task<HttpResponseMessage> GetAsync(string url);
    }

    //--------------------------------------------------------------------------
    //--------------------------------------------------------------------------
    public class HttpService : IHttpService
    {
        public HttpService()
        {
        }

        public async Task<T> ReadContentAsync<T>(HttpResponseMessage response)
        {
            //throw new NotImplementedException();
            var message = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<T>(message);
            return content;
        }
    }

    public class BaseHttpService : IBaseHttpService
    {
        static readonly NativeMessageHandler nativeHandler = new NativeMessageHandler();

        public Task<HttpResponseMessage> PostAsync(string url, object obj = null)
        {
            //throw new NotImplementedException();
            using (var client = new HttpClient(nativeHandler))
            {
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string jsonData = JsonConvert.SerializeObject(obj);

                var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
                var response = client.PostAsync(url, content);
                return response;
            }
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            //throw new NotImplementedException();
            using (var client = new HttpClient(nativeHandler))
            {
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //string jsonData = JsonConvert.SerializeObject(obj);
                //var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
                var response = client.GetAsync(url);
                return response;
            }
        }
    }
}
