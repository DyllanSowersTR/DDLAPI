using DDL.Services;
using DDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DDL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        public async Task<OkObjectResult> Get([FromQuery] RestaurantFilter filter)
        {
            List<Restaurant> restaurants = await YelpQueryService.GetRestaurants(filter);

            return Ok(JsonConvert.SerializeObject(restaurants));
        }
    }
}
