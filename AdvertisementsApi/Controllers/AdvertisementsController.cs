using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdvertisementsApi.Data;
using AdvertisementsApi.Models;

namespace AdvertisementsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementsController : ControllerBase
    {
        private readonly AdvertisementsApiContext _context;

        public AdvertisementsController(AdvertisementsApiContext context)
        {
            _context = context;
        }

        // GET: api/Advertisements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Advertisement>>> GetAdvertisement()
        {
            return await _context.Advertisement.ToListAsync();
        }

        // GET: api/Advertisements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Advertisement>> GetAdvertisement(int id)
        {
            var advertisement = await _context.Advertisement.FindAsync(id);

            if (advertisement == null)
            {
                return NotFound();
            }

            return advertisement;
        }
    }
}
