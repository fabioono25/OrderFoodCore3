using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ListModel> logger;
        public readonly IConfiguration config;

        public ListModel(IConfiguration config, IRestaurantData restaurantData, ILogger<ListModel> logger)
        {
            this.config = config;
            this.restaurantData = restaurantData;
            this.logger = logger;
        }

        public void OnGet(string searchTerm)
        {
            logger.LogError("Executing ListModel");

            //HttpContext.Request.Query: information about HTTP transaction

            //Message = "Hello World!";
            Message = config["Message"];
            //Restaurants = restaurantData.GetAll();
            Restaurants = restaurantData.GetRestaurantsByName(searchTerm);
        }
    }
}