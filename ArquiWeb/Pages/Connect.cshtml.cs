using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArquiWeb.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App_Arqui.Pages
{
    public class InitialPromtModel : PageModel
    {
        [BindProperty]
        public string Message { set; get; }
        [BindProperty]
        public string IDMailbox { set; get; }
        private static string MessageInitial = "Ingrese el numero de buzon y presione llamar";
        private static string MessageErrorConnection = "Numero de buzon incorrecto. Intentelo de nuevo!";
        private readonly IConsumer consumer;

        public InitialPromtModel(IConsumer consumer)
        {
            this.consumer = consumer;
        }

        public void OnGet()
        {
            Message = MessageInitial;
        }
        public async Task<IActionResult> OnPost()
        {
            bool result = await consumer.ExecuteCommandAsync(IDMailbox);
            if (result)
                return RedirectToPage("/Recording");
            Message = MessageErrorConnection;
            return Page();
        }

    }
}