using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web_App_Arqui.ApiConsumer
{
    public class Consumer
    {
        public static string url = ArquiWeb.ApiConsumer.PathApi.Instance.UrlApi;
        static HttpClient client = new HttpClient();

        public static async Task<bool> ExecuteCommandAsync(string command)
        {
            //enviar # mas
            bool result = false;
            HttpResponseMessage response = await client.GetAsync(url+"/executeCommand/" + command);
            if (response.IsSuccessStatusCode)
            {
                var data=await response.Content.ReadAsStringAsync();
                result=Convert.ToBoolean(data);
            }
            return result;
        }
        public static async Task<bool> ExecuteOptionAsync(string command)
        {
            //enviar # mas
            bool result = false;
            HttpResponseMessage response = await client.GetAsync(url + "/executeOption/" + command);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                result = Convert.ToBoolean(data);
            }
            return result;
        }
        public static async Task<string> GetCurrentMessage()
        {
            string result = "Error";
            HttpResponseMessage response = await client.GetAsync(url + "/currentMessage");
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
            HttpResponseMessage response = await client.GetAsync(url + "/saveMessage/" + message);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                result = Convert.ToBoolean(data);
            }
            return result;
        }

        public static async Task<string> GetGreeting()
        {
            string result = "Error";
            HttpResponseMessage response = await client.GetAsync(url + "/currentGreeting");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }
        public static async Task<bool> Ping()
        {
            bool result = true;
            url = ArquiWeb.ApiConsumer.PathApi.Instance.UrlApi;
            try
            {
                HttpResponseMessage response = await client.GetAsync(url + "/ping");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    result = Convert.ToBoolean(data);
                }
            }
            catch {
                result = false;
            }
            return result;
        }
    }
}
