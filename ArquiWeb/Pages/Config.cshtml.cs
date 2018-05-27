using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArquiWeb.Pages
{
    public class ConfigModel : PageModel
    {
        [BindProperty]
        public string Url { set; get; }
        public string Error { set; get; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            ArquiWeb.ApiConsumer.PathApi.Instance.UrlApi = Url;
            bool result = await Web_App_Arqui.ApiConsumer.Consumer.Ping();
            if (result)
            {
                return RedirectToPage("/Connect");
            }
           Error = "No se pudo establecer conexion";
            return Page();
        }
    }
}