using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Web.Http;
using UWPHttpManager;
using System.Diagnostics;

namespace DouBanFm.Core.Https
{
    static class BaseService
    {
        /// <summary>
        /// 向服务器发送get请求  返回服务器回复数据(string)
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async static Task<string> SendGetRequest(string url)
        {
            HttpClient client = new HttpClient();
            var headers = client.DefaultRequestHeaders;
            string header = "";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                // throw new Exception("Invalid header value: " + header);
            }
            header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            Uri requestUri = new Uri(url);
            try
            {
                httpResponse = await client.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                return await httpResponse.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Debug.Write("Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message);
                return null;
            }

        }
        /// <summary>
        /// 向服务器发送get请求  返回服务器回复数据(bytes)
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async static Task<IBuffer> SendGetRequestAsBytes(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                Uri uri = new Uri(url);

                HttpResponseMessage response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsBufferAsync();
            }
            catch
            {
                return null;
            }

        }
        /// <summary>
        /// 向服务器发送post请求 返回服务器回复数据(string)
        /// </summary>
        /// <param name="url"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async static Task<string> SendPostRequest(string url, string body)
        {
            try
            {
                HttpRequestMessage mSent = new HttpRequestMessage(HttpMethod.Post, new Uri(url));
                mSent.Content = new HttpStringContent(body, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json; charset=utf-8");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.SendRequestAsync(mSent);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
