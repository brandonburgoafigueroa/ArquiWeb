using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App_Arqui.Pages
{
    public class RecordingModel : PageModel
    {

        [BindProperty]
        public string Message { set; get; }

        [BindProperty]
        public string Passcode { set; get; }
        [BindProperty]
        public string Error { set; get; }
        [BindProperty]
        public string Greeting { set; get; }
        public async Task OnGetAsync()
        {
            Greeting = await ApiConsumer.Consumer.GetGrreeting();
        }
        public async Task<IActionResult> OnPostSendMessageAsync()
        {
            //añadir mensage
            bool result = await ApiConsumer.Consumer.ExecuteCommandMessageAsync(Message);
            if (result)
                return RedirectToPage("/Connect");
            Error = "Algo sucedio";
            return Page();
            
        }
        public async Task<IActionResult> OnPostLoginAsync()
        {
            //estado
            bool result = await ApiConsumer.Consumer.ExecuteCommandAsync(Passcode);
            if (result)
                return RedirectToPage("/MailboxMenu");
            Error = "Codigo de acceso incorrecto, vuelva a intentar!";
            return Page();
        }
        public async Task<IActionResult> OnPostExit()
        {
            //estado
            bool result = await ApiConsumer.Consumer.ExecuteCommandAsync("H");
            if (result)
                return RedirectToPage("/Connect");
            Error = "Codigo de acceso incorrecto, vuelva a intentar!";
            return Page();
        }
    }
 
}