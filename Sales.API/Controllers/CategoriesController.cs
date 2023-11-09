using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.Entities;
using System.Linq.Expressions;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {

        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            this._context = context;
        }

        //METODO POST
        [HttpPost]
        public async Task<ActionResult> Post(Category category)
        {
            try
            {
                _context.Add(category);
                //_context.Categories.Add(category);

                //para guardar el registro
                await _context.SaveChangesAsync();

                //devuelve como fue llamado
                return Ok(category);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Perdons Ya existe un registro con el mismo ID");
                }
                return BadRequest("Perdons Ya existe un registro con el mismo ID");
                //return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        //METODO GET
        [HttpGet]

        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }


        //Metodo PUT
        [HttpPut]
        public async Task<ActionResult> PutAsync(Category category)
        {
            try
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
                return Ok(category);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest(";/ Ya existe un registro con el mismo ID");
                }
                return BadRequest(";/ Ya existe un registro con el mismo ID");
                //return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //Método Delete
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
