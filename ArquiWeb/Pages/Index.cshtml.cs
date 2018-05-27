using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArquiWeb.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            var verify = ApiConsumer.PathApi.Instance;
            if (verify.UrlApi ==null)
            {
                return RedirectToPage("/Config");
            }
            return RedirectToPage("/Connect");
        }
    }
}
