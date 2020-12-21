using BlazorPeliculas.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPeliculas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext Context;

        public GenerosController(ApplicationDbContext context) 
        {
            this.Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genero>>> Get()
        {
            return await Context.Generos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Genero genero) 
        {
            Context.Add(genero);//guardamos a la base de datos
            await Context.SaveChangesAsync(); // Guradamos los cambio a la DB
            return genero.Id;
        }
    }
}
