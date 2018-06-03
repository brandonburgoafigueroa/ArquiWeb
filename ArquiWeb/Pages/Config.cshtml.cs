using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArquiWeb.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArquiWeb.Pages
{
    public class ConfigModel : PageModel
    {
        private readonly IConsumer consumer;

        public ConfigModel(IConsumer consumer)
        {
            this.consumer = consumer;
        }

        [BindProperty]
        public string Url { set; get; }
        public string Error { set; get; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            consumer.SetUrl(Url);
            bool result = await consumer.Ping();
            if (result)
            {
                return RedirectToPage("/Connect");
            }
           Error = "No se pudo establecer conexion";
            return Page();
        }
    }
}