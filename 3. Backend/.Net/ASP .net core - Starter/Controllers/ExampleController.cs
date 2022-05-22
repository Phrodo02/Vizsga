using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Vizsga_ASP_NET.Models;

namespace Vizsga_ASP_NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public ExampleController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            return Ok
            (
                this._appDbContext.Set<Example>().Include(i => i.Name)  //Modellek is
                                    .Select( i => new
                                    {
                                        i.Id,
                                        //Kategoria = i.Kategoria.Nev
                                    })
            );
        }

        [HttpPost]
        public IActionResult Create(dynamic data)
        {
            try
            {
                var model = JsonSerializer.Deserialize<Example>(
                    data.ToString(),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );

                this._appDbContext.Set<Example>().Add(model);
                this._appDbContext.SaveChanges();
                return StatusCode(201, new
                {
                    model.Id
                });
            }
            catch
            {

                return BadRequest("Hiányos adatok.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = this._appDbContext.Set<Example>().FirstOrDefault(i => i.Id == id);

            if (result == null)
                return NotFound("Nem létezik.");

            this._appDbContext.Set<Example>().Remove(result);
            this._appDbContext.SaveChanges();

            return NoContent();
        }
    }
}
