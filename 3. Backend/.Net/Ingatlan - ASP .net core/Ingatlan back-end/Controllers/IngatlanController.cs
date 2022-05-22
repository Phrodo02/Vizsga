using Ingatlan_back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ingatlan_back_end.Controllers
{
    [ApiController]
    public class IngatlanController : ControllerBase
    {
        private readonly AppContext appContext;

        public IngatlanController(AppContext appContext)
        {
            this.appContext = appContext;
        }

        [HttpGet("/api/ingatlan")]
        public IActionResult GetAll()
        {
            return Ok(
                appContext.Set<IngatlanModel>().Include(i => i.Kategoria)
                          .Select(i => new
                          {
                              i.Id,
                              Kategoria = i.Kategoria.Nev,
                              i.Leiras,
                              HirdetesDatuma = i.HirdetesDatuma.ToString("yyyy-MM-dd"),
                              i.Tehermentes,
                              i.Ar,
                              i.KepUrl
                          })
            );

        }

        [HttpPost("/api/ingatlan")]
        public IActionResult New(dynamic data)
        {
            try
            {
                var model = JsonSerializer.Deserialize<IngatlanModel>(
                    data.ToString(),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );

                appContext.Set<IngatlanModel>().Add(model);
                appContext.SaveChanges();
                return StatusCode(201, new
                {
                    model.Id
                });
            }
            catch
            {
                return BadRequest("Hiányos adatok");
            }
        }

        [HttpDelete("/api/ingatlan/{id}")]
        public IActionResult Delete(int id)
        {
            var model = appContext.Set<IngatlanModel>().FirstOrDefault(i => i.Id == id);
            if (model == null)
                return NotFound("Az ingatlan nem létezik");

            appContext.Set<IngatlanModel>().Remove(model);
            appContext.SaveChanges();

            return NoContent();
        }
    }
}
