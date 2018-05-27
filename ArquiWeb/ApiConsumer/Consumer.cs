using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web_App_Arqui.ApiConsumer
{
    public static class Consumer
    {
        static HttpClient client = new HttpClient();

        public static async Task<bool> ExecuteCommandAsync(string command)
        {
            //enviar # mas
            bool result = false;
            HttpResponseMessage response = await client.GetAsync("http://arquiapi.azurewebsites.net/Api/Values/ExecuteCommand/"+command);
            if (response.IsSuccessStatusCode)
            {
                var data=await response.Content.ReadAsStringAsync();
                result=Convert.ToBoolean(data);
            }
            return result;
        }
        public static async Task<string> GetCurrentMessage()
        {
            string result = "Error";
            HttpResponseMessage response = await client.GetAsync("http://arquiapi.azurewebsites.net/Api/Values/GetCurrentMessage/");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }

        public static async Task<bool> ExecuteCommandMessageAsync(string message)
        {
            ///enviar con h
            bool result = false;
            HttpResponseMessage response = await client.GetAsync("http://arquiapi.azurewebsites.net/Api/Values/ExecuteCommand/" + message);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                result = Convert.ToBoolean(data);
            }
            return result;
        }

        public static async Task<string> GetGrreeting()
        {
            string result = "Error";
            HttpResponseMessage response = await client.GetAsync("http://arquiapi.azurewebsites.net/Api/Values/GetGreeting/");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }
    }
}
