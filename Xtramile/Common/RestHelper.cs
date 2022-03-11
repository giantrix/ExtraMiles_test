using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xtramile.Models;

namespace Xtramile.Common
{
    public class RestHelper
    {

        public enum RequestType
        {
            Get,
            Post,
            Put,
            Delete
        }

        public static T SendRequest<T>(RequestType requestType, string url, object param, string token = "")
        {
            using (HttpClient client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(token.Trim()))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage responseMessage = null;
                try
                {

                    string postBody = string.Empty;
                    if (param != null)
                    {
                        postBody = JsonConvert.SerializeObject(param);
                    }
                    switch (requestType)
                    {
                        case RequestType.Post:
                            responseMessage = client.PostAsync(url, new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                            break;
                        case RequestType.Get:
                            responseMessage = client.GetAsync(url).Result;
                            break;
                        case RequestType.Put:
                            responseMessage = client.PutAsync(url, new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                            break;
                        case RequestType.Delete:
                            responseMessage = client.DeleteAsync(url).Result; ;
                            break;
                    }
                }
                catch
                {
                    return default(T);
                }
                if (responseMessage == null)
                    return default(T);
                else
                    return ResultHandler<T>(responseMessage);
            }
        }


        public static T ResultHandler<T>(HttpResponseMessage responseMessage)
        {
            string responseString = responseMessage.Content.ReadAsStringAsync().Result;
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                if (JSONHelper.IsValidJsonString(responseString))
                {
                    return JsonConvert.DeserializeObject<T>(responseString);
                }
                else
                {
                    return default(T);
                }
            }
            else if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                return default(T);
            }
            else
            {
                return default(T);
            }
        }
    }

    public class JSONHelper
    {
        public static bool IsValidJsonString(string jsonString)
        {
            try
            {
                JToken token = JToken.Parse(jsonString);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }


}
