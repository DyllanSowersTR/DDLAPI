using DDL.Models;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

namespace DDL.Services
{
    public class YelpQueryService
    {
        public static async Task<List<Restaurant>> GetRestaurants(RestaurantFilter filter)
        {
            List<Restaurant> restaurants = new List<Restaurant>();

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalAppData.Configuration["YelpConfig:Token"]);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("https://api.yelp.com/v3/businesses/search");

            // TODO: Good place to use the strategy pattern here? Inject a formatter? So could FormatForUrlParameters, and just append that to the yelp url. Look at how Google Maps API is queried. Could have API-specific (yelp, maps, etc.) query formatters
            stringBuilder.Append(filter.FormatForUrlParameters());

            HttpResponseMessage response = await httpClient.GetAsync(stringBuilder.ToString());
            string responseBody = await response.Content.ReadAsStringAsync();

            dynamic jsonResponse = JsonConvert.DeserializeObject(responseBody); // TODO: Need to do property existance checking on dynamic objects

            foreach (dynamic business in jsonResponse.businesses)
            {
                //restaurants.Add(JsonConvert.DeserializeObject<Restaurant>(business));
                // TODO: Can the below be moved to a custom deserializer so something close to just the above code can be ran here

                Restaurant restaurant = new Restaurant();
                restaurant.Name = business.name;

                Location location = new Location();
                location.StreetAddress = $"{business.location.address1} {business.location.address2} {business.location.address3}";
                location.City = business.location.city;
                location.State = business.location.state;
                location.Zipcode = business.location.zip_code;
                restaurant.Location = location;

                foreach (dynamic category in business.categories)
                {
                    restaurant.Categories.Add((string) category.alias);
                }

                restaurants.Add(restaurant);
            }

            // TODO: Max results. Yelp defaults to 20, max is 50. We can request up to 1000 from Yelp by navigating their pagination with the offset parameter

            return restaurants;
        }
    }
}
