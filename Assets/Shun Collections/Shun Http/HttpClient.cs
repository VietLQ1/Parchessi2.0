

using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Shun_Collections.Shun_Http
{
    public class HttpClient
    {
        public static async Task<T> Get<T>(string url, Action<bool, T> callback = null)
        {
            var request = CreateRequest(url, RequestType.GET);
            request.SendWebRequest();
            
            while (!request.isDone)
            {
                await Task.Delay(10);
            }
            
            if (request.result is not UnityWebRequest.Result.Success 
                ||  request.isNetworkError || request.isHttpError)
            {
                Debug.LogError("Get Request " + request.error);
                callback?.Invoke(false, default);
                
                return default;
            }
            

            callback?.Invoke(true, JsonConvert.DeserializeObject<T>(request.downloadHandler.text));
            return JsonConvert.DeserializeObject<T>(request.downloadHandler.text);

        }
        
        public static async Task<T> Post<T>(string url, object data, Action<bool, T> callback = null)
        {
            var request = CreateRequest(url, RequestType.POST, data);
            request.SendWebRequest();
            
            while (!request.isDone)
            {
                await Task.Delay(10);
            }
            
            if (request.result is not UnityWebRequest.Result.Success 
                ||  request.isNetworkError || request.isHttpError)
            {
                Debug.LogError("Post Request " + request.error);
                callback?.Invoke(false, default);
                
                return default;
            }
            

            callback?.Invoke(true, JsonConvert.DeserializeObject<T>(request.downloadHandler.text));
            return JsonConvert.DeserializeObject<T>(request.downloadHandler.text);

        }
        
        public static async Task<T> Put<T>(string url, object data, Action<bool, T> callback = null)
        {
            var request = CreateRequest(url, RequestType.PUT, data);
            request.SendWebRequest();
            
            while (!request.isDone)
            {
                await Task.Delay(10);
            }
            
            if (request.result is not UnityWebRequest.Result.Success 
                ||  request.isNetworkError || request.isHttpError)
            {
                Debug.LogError("Put Request " + request.error);
                callback?.Invoke(false, default);
                
                return default;
            }
            

            callback?.Invoke(true, JsonConvert.DeserializeObject<T>(request.downloadHandler.text));
            return JsonConvert.DeserializeObject<T>(request.downloadHandler.text);

        }
        
        public static async Task<T> Delete<T>(string url, Action<bool, T> callback = null)
        {
            var request = CreateRequest(url, RequestType.DELETE);
            request.SendWebRequest();
            
            while (!request.isDone)
            {
                await Task.Delay(10);
            }
            
            if (request.result is not UnityWebRequest.Result.Success 
                ||  request.isNetworkError || request.isHttpError)
            {
                Debug.LogError("Delete Request " + request.error);
                callback?.Invoke(false, default);
                
                return default;
            }
            

            callback?.Invoke(true, JsonConvert.DeserializeObject<T>(request.downloadHandler.text));
            return JsonConvert.DeserializeObject<T>(request.downloadHandler.text);

        }
        
        public static async Task<T> Patch<T>(string url, object data, Action<bool, T> callback = null)
        {
            var request = CreateRequest(url, RequestType.PATCH, data);
            request.SendWebRequest();
            
            while (!request.isDone)
            {
                await Task.Delay(10);
            }
            
            if (request.result is not UnityWebRequest.Result.Success 
                ||  request.isNetworkError || request.isHttpError)
            {
                Debug.LogError("Patch Request " + request.error);
                callback?.Invoke(false, default);
                
                return default;
            }
            

            callback?.Invoke(true, JsonConvert.DeserializeObject<T>(request.downloadHandler.text));
            return JsonConvert.DeserializeObject<T>(request.downloadHandler.text);

        }

        private static UnityWebRequest CreateRequest(string url, RequestType type = RequestType.GET, object data = null)
        {
            var request = new UnityWebRequest(url, type.ToString());

            if (data != null)
            {
                var bodyRaw = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            }
            
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            
            return request;
        }
    }


    enum RequestType
    {
        GET,
        POST,
        PUT,
        DELETE,
        PATCH
    }
}