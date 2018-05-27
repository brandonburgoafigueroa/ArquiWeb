using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App_Arqui.Pages
{
    public class MessageMenuModel : PageModel
    {
        [BindProperty]
        public string Message { set; get; }
        [BindProperty]
        public string CurrentMessageText { set; get; }
        public string Error { set; get; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostListenAsync()
        {
            string result = await ApiConsumer.Consumer.GetCurrentMessage();
                CurrentMessageText = result;
                Message = "Mensaje actual";
                Error = "";
                return Page();
        }
        public async Task<IActionResult> OnPostSaveAsync()
        {
            bool result = await ApiConsumer.Consumer.ExecuteCommandAsync("2");
            if (result) { 
                Error = "";
            return Page();
            }
            Error = "Algo salio mal";
            return Page();

        }
        public async Task<IActionResult> OnPostDeleteAsync()
        {
            bool result = await ApiConsumer.Consumer.ExecuteCommandAsync("3");
            if (result) { 
                Error = "";
            return Page();
        }
        Error = "Algo salio mal";
            return Page();
        }
        
        public async Task<IActionResult> OnPostMailBoxMenuAsync()
        {
            bool result = await ApiConsumer.Consumer.ExecuteCommandAsync("4");
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