using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderFoodCore.Core;
using OrderFoodCore3.Data;
using System.Collections.Generic;

namespace OrderFoodCore3
{
    public class EditModel : PageModel
    {
        private readonly IHtmlHelper htmlHelper;

        public IRestaurantData restaurantData { get; }
        
        [BindProperty] //now it's input and output
        public Restaurant Restaurant { get; set; } //output
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData,
                         IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
               
        public IActionResult OnGet(int restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            Restaurant = restaurantData.GetById(restaurantId);

            if (Restaurant == null)
                return RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            //to use the data annotations we added in Restaurant class
            if (ModelState.IsValid)
            {
                restaurantData.Update(Restaurant);
                restaurantData.Commit();                
            }

            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            
            return Page();
        }
    }
}