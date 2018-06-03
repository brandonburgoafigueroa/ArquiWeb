using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArquiWeb.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App_Arqui.Pages
{
    public class ChangeGreetingModel : PageModel
    {
        private readonly IConsumer consumer;

        [BindProperty]
        public string Greeting { set; get; }
        public void OnGet()
        {

        }
        public ChangeGreetingModel(IConsumer consumer)
        {
            this.consumer = consumer;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            bool result = await consumer.ExecuteCommandAsync(Greeting);
            if (result)
            {
                return RedirectToPage("/MailboxMenu");
            }
            return Page();
        }
    }
}