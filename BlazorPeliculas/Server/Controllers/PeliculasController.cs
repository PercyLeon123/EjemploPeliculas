using BlazorPeliculas.Server.Helpers;
using BlazorPeliculas.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPeliculas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculasController : ControllerBase
    {
        private readonly ApplicationDbContext Context;
        private readonly IAlmacenadorArchivos AlmacenadorArchivos;
        private readonly string Contenedor = "peliculas";

        public PeliculasController(ApplicationDbContext context, IAlmacenadorArchivos almacenadorArchivos)
        {
            this.Context = context;
            this.AlmacenadorArchivos = almacenadorArchivos;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Pelicula pelicula)
        {
            if (!string.IsNullOrEmpty(pelicula.Poster))
            {
                var fotoPersona = Convert.FromBase64String(pelicula.Poster);
                pelicula.Poster = await AlmacenadorArchivos.GuardarArchivo(fotoPersona, ".jpg", Contenedor);
            }

            Context.Add(pelicula);
            await Context.SaveChangesAsync();
            return pelicula.Id;
        }
    }
}
