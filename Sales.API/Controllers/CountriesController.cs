using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.Entities;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountriesController: ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context) 
        {
            this._context = context;
        }

        //METODO POST
        [HttpPost]
        public async Task<ActionResult> Post(Country country)
        {
            _context.Add(country);
            //_context.Countries.Add(country);

            //para guardar el registro
            await _context.SaveChangesAsync();
            
            //devuelve como fue llamado
            return Ok(country);
        }

        //METODO GET
        [HttpGet]

        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

    }
}
