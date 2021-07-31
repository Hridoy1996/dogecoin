using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogeCoin.Services
{
    public static class DogeToUsdService
    {
        public static string GetRequestContent()
        {
            try
            {
                RestClient getClient = new RestClient();
                getClient = new RestClient("https://sochain.com");
                RestRequest GetRequest = null;
                GetRequest = new RestRequest("//api//v2//get_price//DOGE//USD", Method.GET);
           
                var GetResponse = getClient.Execute(GetRequest);
                var GetContent = GetResponse.Content;
                return GetContent;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
           
           
        }
       
    }
}

