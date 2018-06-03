using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArquiWeb.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App_Arqui.Pages
{
    public class ChangePasscodeModel : PageModel
    {
        private readonly IConsumer consumer;

        public ChangePasscodeModel(IConsumer consumer)
        {
            this.consumer = consumer;
        }

        [BindProperty]
        public string Passcode { set; get; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            bool result = await consumer.ExecuteCommandAsync(Passcode);
            if (result)
            {
                return RedirectToPage("/MailboxMenu");
            }
            return Page();
        }
    }
}