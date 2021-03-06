﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrouFrouFelineCafe.Core;
using FrouFrouFelineCafe.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frou_Frou_Feline_Cafe.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public Restaurant Restaurant { get; set; }
        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId);
            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}