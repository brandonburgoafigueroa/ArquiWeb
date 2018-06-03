using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArquiWeb.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App_Arqui.Pages
{
    public class MessageMenuModel : PageModel
    {
        private readonly IConsumer consumer;

        [BindProperty]
        public string Message { set; get; }
        [BindProperty]
        public string CurrentMessageText { set; get; }
        public string Error { set; get; }
        public MessageMenuModel(IConsumer consumer)
        {
            this.consumer = consumer;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostListenAsync()
        {
            bool executed = await consumer.ExecuteOptionAsync("1");
            string result = await consumer.GetCurrentMessage();
                CurrentMessageText = result;
                Message = "Mensaje actual";
                Error = "";
                return Page();
        }
        public async Task<IActionResult> OnPostSaveAsync()
        {
            bool result = await consumer.ExecuteOptionAsync("2");
            if (result) { 
                Error = "";
            return Page();
            }
            Error = "Algo salio mal";
            return Page();

        }
        public async Task<IActionResult> OnPostDeleteAsync()
        {
            bool result = await consumer.ExecuteOptionAsync("3");
            if (result) { 
                Error = "";
            return Page();
        }
        Error = "Algo salio mal";
            return Page();
        }
        
        public async Task<IActionResult> OnPostMailBoxMenuAsync()
        {
            bool result = await consumer.ExecuteOptionAsync("4");
            if (result)
            {
                Error = "";
                return RedirectToPage("/MailBoxMenu");
            }
            Error = "Algo salio mal";
            return Page();
        }
        


    }
}