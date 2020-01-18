using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrderFoodCore.Core;
using OrderFoodCore3.Data;

namespace OrderFoodCore3
{
    public class DetailModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public Restaurant Restaurant { get; set; }
        public IRestaurantData restaurantData { get; }

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId);

            if (Restaurant == null)
                return RedirectToPage("./NotFound");

            return Page();
        }
    }
}