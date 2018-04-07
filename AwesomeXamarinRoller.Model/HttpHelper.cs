using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeXamarinAndroidRoller.Model
{
    internal class HttpHelper
    {
        private HttpClient _httpClient;

        //private static readonly string LOG_TAG = "HttpClient";

        public HttpHelper()
        {
            _httpClient = new HttpClient(new NativeMessageHandler());

#if DEBUG
            _httpClient.Timeout = new TimeSpan(1, 0, 0, 0);
#endif
        }

        internal async Task<T> GetAsync<T>(string url, object param)
        {
            string actualUrl = url.ToQuery(param);

            try
            {

                HttpResponseMessage response = null;

                Stopwatch stopWatch = new Stopwatch();

                stopWatch.Start();

                //_log.WriteLog(LOG_TAG, string.Format("Connecting to url: {0}", actualUrl), LogLevel.Info);

                response = await _httpClient.GetAsync(actualUrl);

                stopWatch.Stop();

                var code = response.StatusCode;

                if (code == System.Net.HttpStatusCode.OK)
                {
                    //_log.WriteLog(LOG_TAG, string.Format("Connection to url: {0} successful, {1} msec", actualUrl, stopWatch.ElapsedMilliseconds), LogLevel.Info);

                    var json = await response.Content.ReadAsStringAsync();

                    //_log.WriteLog(LOG_TAG, string.Format("Received {0} bytes", json.Length), LogLevel.Info);

                    //_log.WriteLog(LOG_TAG, string.Format("Starting deserializing {0} response", url), LogLevel.Info);

                    stopWatch.Restart();

                    T retVal = JsonConvert.DeserializeObject<T>(json);

                    stopWatch.Stop();

                    //_log.WriteLog(LOG_TAG, string.Format("Finished deserializing, {0} msec", stopWatch.ElapsedMilliseconds), LogLevel.Info);

                    return retVal;
                }
                else
                {
                    //_log.WriteLog(LOG_TAG, string.Format("Connection to url: {0} failed", actualUrl), LogLevel.Error);

                    throw new WebException("Network Error", (WebExceptionStatus)code);
                }
            }
            catch (Exception ex)
            {
                //_log.WriteLog(LOG_TAG, string.Format("Connection to url: {0} failed with exception {1}", actualUrl, ex.ToString()), LogLevel.Error);

                throw ex;
            }
        }

        internal async Task<T> PostAsync<T>(string url, object data)
             where T : class
        {
            try
            {
                Stopwatch stopWatch = new Stopwatch();

                //_log.WriteLog(LOG_TAG, "Serializing server request", LogLevel.Info);

                stopWatch.Start();

                var dataJson = JsonConvert.SerializeObject(data);
                var contentJson = new StringContent(dataJson,
                    Encoding.UTF8, "application/json");
                //var r = url.ToQuery(data);

                stopWatch.Stop();

                //_log.WriteLog(LOG_TAG, string.Format("Serialized server request, {0} msec", stopWatch.ElapsedMilliseconds), LogLevel.Info);

                //_log.WriteLog(LOG_TAG, string.Format("Posting {0} bytes to url: {1}", dataJson.Length, url), LogLevel.Info);

                stopWatch.Restart();

                var response = await _httpClient.PostAsync(url, contentJson).ConfigureAwait(false);

                stopWatch.Stop();

                var code = response.StatusCode;

                if (code == System.Net.HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    //_log.WriteLog(LOG_TAG, string.Format("Connection to url: {0} successful, {1} msec. Received {2} bytes", url, stopWatch.ElapsedMilliseconds, json.Length), LogLevel.Info);

                    //_log.WriteLog(LOG_TAG, string.Format("Starting deserializing {0} response", url), LogLevel.Info);

                    stopWatch.Restart();

                    T res = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(json)).ConfigureAwait(false);

                    stopWatch.Stop();

                    //_log.WriteLog(LOG_TAG, string.Format("Finished deserializing, {0} msec", stopWatch.ElapsedMilliseconds), LogLevel.Info);

                    return res;
                }
                else if (code == HttpStatusCode.InternalServerError)
                {
                    //_log.WriteLog(LOG_TAG, string.Format("Server Error for url: {0}", url), LogLevel.Error);

                    throw new Exception(response.ReasonPhrase);
                }
                else
                {
                    //_log.WriteLog(LOG_TAG, string.Format("Connection to url: {0} failed", url), LogLevel.Error);

                    throw new WebException("Network Error", (WebExceptionStatus)code);
                }
            }
            catch (Exception ex)
            {
                //_log.WriteLog(LOG_TAG, string.Format("Connection to url: {0} failed with exception {1}", url, ex.ToString()), LogLevel.Error);

                throw ex;
            }
        }

        //public void SetLog(ILog log)
        //{
        //    _log = log;
        //}
    }
}
