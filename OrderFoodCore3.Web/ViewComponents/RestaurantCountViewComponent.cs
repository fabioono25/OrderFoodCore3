﻿using Microsoft.AspNetCore.Mvc;
using OrderFoodCore3.Data;

namespace OrderFoodCore3.Web.ViewComponents
{
    public class RestaurantCountViewComponent
        : ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetCountOfRestaurants();

            return View(count);
        }
    }
}
