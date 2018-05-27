using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App_Arqui.Pages
{
    public class ChangePasscodeModel : PageModel
    {
        [BindProperty]
        public string Passcode { set; get; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            bool result = await ApiConsumer.Consumer.ExecuteCommandAsync(Passcode);
            if (result)
            {
                return RedirectToPage("/MailboxMenu");
            }
            return Page();
        }
    }
}