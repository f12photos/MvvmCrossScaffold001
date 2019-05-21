using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Base;
using MvvmCross.Logging;
using MvvmCross.Plugin.Network.Rest;

namespace MvvmCrossScaffold001.Core.Rest
{
    // https://stackoverflow.com/questions/38784741/working-example-of-mvxrestclient-makerequestasync-with-mvxjsonrequest
    // https://jsonplaceholder.typicode.com/
    // https://kodejava.org/how-do-i-send-post-request-with-a-json-body-using-the-httpclient/
    // nuget Mvvmcross.plugin.network

    //public interface IMvxRestClient
    //{
    //    void ClearSetting(string key);
    //    void SetSetting(string key, object value);

    //    void MakeRequest(MvxRestRequest restRequest, Action<MvxRestResponse> successAction,
    //                     Action<Exception> errorAction);

    //    void MakeRequest(MvxRestRequest restRequest, Action<MvxStreamRestResponse> successAction,
    //                     Action<Exception> errorAction);
    //}

    //public interface IMvxJsonRestClient
    //{
    //    Func<IMvxJsonConverter> JsonConverterProvider
    //    {
    //        get;
    //        set;
    //    }

    //    void MakeRequestFor<T>(MvxRestRequest restRequest, Action<MvxDecodedRestResponse<T>> successAction,
    //                           Action<Exception> errorAction);
    //}

    public interface IRestClient
    {
        Task<TResult> MakeApiCall<TResult>(string url, HttpMethod method, object data = null)
            where TResult : class;
    }

    //--------------------------------------------------------------------------
    //--------------------------------------------------------------------------

    public class RestClient : IRestClient
    {
        private readonly IMvxJsonConverter _jsonConverter;
        private readonly IMvxLog _mvxLog;

        public RestClient(IMvxJsonConverter jsonConverter, IMvxLog mvxLog)
        {
            _jsonConverter = jsonConverter;
            _mvxLog = mvxLog;
        }

        public async Task<TResult> MakeApiCall<TResult>(string url, HttpMethod method, object data = null) where TResult : class
        {
            url = url.Replace("http://", "https://");

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage { RequestUri = new Uri(url), Method = method })
                {
                    // add content
                    if (method != HttpMethod.Get)
                    {
                        var json = _jsonConverter.SerializeObject(data);
                        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                    }

                    HttpResponseMessage response = new HttpResponseMessage();
                    try
                    {
                        response = await httpClient.SendAsync(request).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        _mvxLog.ErrorException("MakeApiCall failed", ex);
                    }

                    var stringSerialized = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    // deserialize content
                    return _jsonConverter.DeserializeObject<TResult>(stringSerialized);
                }
            }
        }
    }
}
