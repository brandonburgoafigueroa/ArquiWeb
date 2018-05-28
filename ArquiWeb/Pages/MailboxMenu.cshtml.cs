using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App_Arqui.Pages
{
    public class MailboxMenuModel : PageModel
    {

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostListenAsync()
        {
            bool result = await ApiConsumer.Consumer.ExecuteOptionAsync("1");
            if (result)
            {
                return RedirectToPage("/MessageMenu");
            }
            return Page();
            
        }
        public async Task<IActionResult> OnPostPasscodeAsync()
        {
            bool result = await ApiConsumer.Consumer.ExecuteOptionAsync("2");
            if (result)
            {
                return RedirectToPage("/ChangePasscode");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostGreetingAsync()
        {
            bool result = await ApiConsumer.Consumer.ExecuteOptionAsync("3");
            if (result)
            {
                return RedirectToPage("/ChangeGreeting");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostExitAsync()
        {
            bool result = await ApiConsumer.Consumer.ExecuteOptionAsync("H");
            if (result)
            {
                return RedirectToPage("/Connect");
            }
            return Page();
        }
    }
}