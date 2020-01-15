using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OrderFoodCore.Core;
using OrderFoodCore3.Data;
using System.Collections.Generic;

namespace OrderFoodCore3.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public readonly IRestaurantData restaurantData;

        public readonly IConfiguration config;

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }

        public void OnGet(string searchTerm)
        {
            //HttpContext.Request.Query: information about HTTP transaction

            //Message = "Hello World!";
            Message = config["Message"];
            //Restaurants = restaurantData.GetAll();
            Restaurants = restaurantData.GetRestaurantsByName(searchTerm);
        }
    }
}