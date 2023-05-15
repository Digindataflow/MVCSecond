using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVCSecond.Models;
using MVCSecond.Services;

namespace MVCSecond.Pages
{
    public class PizzaListModel : PageModel
    {
        private readonly PizzaService _service;
        public IList<Pizza> PizzaList {get; set; } = default!;

        // bind the NewPizza property to the Razor Page
        // will be populated with the user's input in POST request
        [BindProperty]
        public Pizza NewPizza { get; set; } = default!;

        public PizzaListModel (PizzaService service) {
            _service = service; 
        }

        public void OnGet()
        {
            PizzaList = _service.GetPizzas();
        }

        public IActionResult OnPost()
        {
            // The validation rules are inferred from attributes 
            // (such as Required and Range) on the Pizza class
            if (!ModelState.IsValid || NewPizza == null)
            {
                return Page();
            }

            _service.AddPizza(NewPizza);

            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
            _service.DeletePizza(id);

            return RedirectToAction("Get");
        }
    }
}
