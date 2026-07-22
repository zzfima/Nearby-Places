using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NearbyPlaces.Data;
using NearbyPlaces.Models;
using NearbyPlaces.Redis;

namespace NearbyPlaces.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NearbyPlacesController : Controller
    {
        private readonly NearbyPlacesDbContext _db;

        public NearbyPlacesController(NearbyPlacesDbContext db)
        {
            _db = db;
        }

        [HttpGet(Name = "GetAllPlaces")]
        public async Task<IEnumerable<Place>> GetAll()
        {
            string res = await TestRedisGet();
            return await _db.Places.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Place place)
        {
            _db.Places.Add(place);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = place.Id }, place);
        }

        public async Task<string> TestRedisGet()
        {
            RedisCrud redisCrud = new RedisCrud();
            await redisCrud.Connect();
            string res = await redisCrud.RetrieveValue("tr");
            await redisCrud.Disonnect();
            return res;
        }
    }
}
