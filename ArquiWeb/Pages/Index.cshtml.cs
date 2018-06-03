using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArquiWeb.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArquiWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConsumer consumer;

        public IndexModel(IConsumer consumer)
        {
            this.consumer = consumer;
        }
        public IActionResult OnGet()
        {
            var verify = consumer.HasUrl();
            if (verify)
            {
                return RedirectToPage("/Config");
            }
            return RedirectToPage("/Connect");
        }
    }
}
