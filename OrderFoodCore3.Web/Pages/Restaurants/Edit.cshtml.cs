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
               
        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            if (restaurantId.HasValue)
                Restaurant = restaurantData.GetById(restaurantId.Value);
            else
                Restaurant = new Restaurant();
                
            if (Restaurant == null)
                return RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            //to use the data annotations we added in Restaurant class
            if (!ModelState.IsValid)
            {   Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (Restaurant.Id > 0)
                restaurantData.Update(Restaurant);
            else
                restaurantData.Add(Restaurant);

            restaurantData.Commit();

            //dictionary of key/value - after use will disapear
            TempData["Message"] = "Restaurant saved!";

            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}