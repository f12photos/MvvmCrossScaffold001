using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
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
            //https://forums.xamarin.com/discussion/64176/how-to-upload-image-to-the-server-using-api-in-xamarin-forms
            //https://stackoverflow.com/questions/53740665/send-image-with-httpclient-to-post-webapi-and-consume-the-data
            //https://johnthiriet.com/efficient-post-calls/#
            //throw new NotImplementedException();
            using (var client = new HttpClient(nativeHandler))
            {
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.a
                //nativeHandler.a

                //MultipartFormDataContent content = new MultipartFormDataContent();

                //var upfilebytes = File.ReadAllBytes(file);
                //ByteArrayContent baContent = new ByteArrayContent(upfilebytes);
                //content.Add(baContent, "File", "filename.ext");

                //StringContent studentIdContent = new StringContent("2123");
                //content.Add(studentIdContent, "StudentId");

                string jsonData = JsonConvert.SerializeObject(obj);
                //StringContent strContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
                //content.Add(strContent);

                //var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

                var content = CreateHttpContent(obj);

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

        //======================================================================
        //private async Task PostStreamAsync(object content, CancellationToken cancellationToken)
        //{
        //    using (var client = new HttpClient())
        //    using (var request = new HttpRequestMessage(HttpMethod.Post, Url))
        //    using (var httpContent = CreateHttpContent(content))
        //    {
        //        request.Content = httpContent;

        //        using (var response = await client
        //            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
        //            .ConfigureAwait(false))
        //        {
        //            response.EnsureSuccessStatusCode();
        //        }
        //    }
        //}

        private HttpContent CreateHttpContent(object content)
        {
            HttpContent httpContent = null;

            if (content != null)
            {
                var ms = new MemoryStream();
                SerializeJsonIntoStream(content, ms);
                ms.Seek(0, SeekOrigin.Begin);
                httpContent = new StreamContent(ms);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return httpContent;
        }

        public void SerializeJsonIntoStream(object value, Stream stream)
        {
            using (var sw = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
            using (var jtw = new JsonTextWriter(sw) { Formatting = Formatting.None })
            {
                var js = new JsonSerializer();
                js.Serialize(jtw, value);
                jtw.Flush();
            }
        }


    }
}
