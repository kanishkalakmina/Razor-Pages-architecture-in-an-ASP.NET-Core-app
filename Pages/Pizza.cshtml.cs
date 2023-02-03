using RazorPagesPizza.Models;
using RazorPagesPizza.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesPizza.Pages
{
    public class PizzaModel : PageModel
    {
        [BindProperty]
        public Pizza NewPizza { get; set; } = new();

        public List<Pizza> pizzas = new();
        public void OnGet()
        {
            pizzas = PizzaService.GetAll();
            
        }
        public IActionResult OnPost()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                PizzaService.Add(NewPizza);
                    return RedirectToAction("Get");
            }
        public IActionResult OnPostDelete(int id)
            {
                PizzaService.Delete(id);
                return RedirectToAction("Get");
            }
            
        public string GlutenFreeText(Pizza pizza)
            {
                return pizza.IsGlutenFree ? "Gluten Free": "Not Gluten Free";
            }
        
    }
}
