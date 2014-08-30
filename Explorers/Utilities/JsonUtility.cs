using System;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;

namespace WowDotNetAPI.Utilities
{
    public static class JsonUtility
    {
        public static string GetJSON(string url)
        {
            var req = WebRequest.Create(url) as HttpWebRequest;
            return GetJSON(req);
        }

        public static string GetJSON(HttpWebRequest req)
        {
            var res = req.GetResponse() as HttpWebResponse;

            using (var streamReader = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
                return streamReader.ReadToEnd();
        }

        //JSON serialization - http://www.joe-stevens.com/2009/12/29/json-serialization-using-the-datacontractjsonserializer-and-c/
        public static T FromJSON<T>(string url) where T : class
        {
            var req = WebRequest.Create(url) as HttpWebRequest;
            return FromJSON<T>(req);
        }

        public static T FromJSON<T>(HttpWebRequest req) where T : class
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(GetJSON(req))))
                return new DataContractJsonSerializer(typeof(T)).ReadObject(stream) as T;
        }

        public static T FromJSON<T>(string url, string publicAuthKey, string privateAuthKey) where T : class
        {
            var req = WebRequest.Create(url) as HttpWebRequest;
            var date = DateTime.UtcNow;
            req.Date = date;

            var stringToSign = String.Format("{0}\n{1}\n{2}\n", req.Method, date.ToString("r"), req.RequestUri.AbsolutePath);
            var buffer = Encoding.UTF8.GetBytes(stringToSign);

            var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(privateAuthKey));
            var signature = Convert.ToBase64String(hmac.ComputeHash(buffer));
            
            req.Headers[HttpRequestHeader.Authorization]
                = String.Format("BNET {0}:{1}", publicAuthKey, signature);

            return FromJSON<T>(req);
        }

        public static string ToJSON<T>(T obj) where T : class
        {
            using (var stream = new MemoryStream())
            {
                new DataContractJsonSerializer(typeof(T)).WriteObject(stream, obj);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public static T FromJSONStream<T>(StreamReader sr) where T : class
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(sr.ReadToEnd())))
                return new DataContractJsonSerializer(typeof(T)).ReadObject(stream) as T;
        }

        public static T FromJSONString<T>(string str) where T : class
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(str)))
                return new DataContractJsonSerializer(typeof(T)).ReadObject(stream) as T;
        }

    }
}
