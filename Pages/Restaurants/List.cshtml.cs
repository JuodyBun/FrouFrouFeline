using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrouFrouFelineCafe.Core;
using FrouFrouFelineCafe.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

//This is the Page Model (typically performs data access and do all the hard work,
//to put together the data that the Razor Page will display)

//Typical pattern: Use the PageModel to inject services that will give me access to
//the data that I need, and then use those services, i.e. configuration service, to 
//fetch data and add that to properties that I will bind to inside of my Razor Page
namespace Frou_Frou_Feline_Cafe.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData) //constructor w/ IConfiguration (needs Extensions.Configuration)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }
        public void OnGet() //responds to the HTTP GET request
        {
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}