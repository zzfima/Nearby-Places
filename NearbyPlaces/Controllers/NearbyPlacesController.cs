using Microsoft.AspNetCore.Mvc;
using NearbyPlaces.Models;

namespace NearbyPlaces.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NearbyPlacesController : Controller
    {
        [HttpGet(Name = "GetAllPlaces")]
        public IEnumerable<Place> GetAll()
        {
            IList<Place> places = new List<Place>();
            places.Add(new Place
            {
                Name = "Jerusalem",
                City = "Jerusalem",
                Country = "Israel",
                Latitude = 31.7719,
                Longitude = 35.2170,
                Type = PlaceType.City
            });
            places.Add(new Place
            {
                Name = "Aroma",
                City = "Jerusalem",
                Country = "Israel",
                Latitude = 31.7730,
                Longitude = 35.2180,
                Type = PlaceType.Cafe,
                Rating = 4.5
            });
            places.Add(new Place
            {
                Name = "Paz Gas Station",
                City = "Jerusalem",
                Country = "Israel",
                Latitude = 31.7750,
                Longitude = 35.2200,
                Type = PlaceType.GasStation
            });
            return places;
        }
    }
}
