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
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDbContext Context;
        private readonly IAlmacenadorArchivos AlmacenadorArchivos;
        private readonly string Contenedor = "personas";

        public PersonasController(ApplicationDbContext context, IAlmacenadorArchivos almacenadorArchivos) 
        {
            this.Context = context;
            this.AlmacenadorArchivos = almacenadorArchivos;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Persona persona)
        {
            if (!string.IsNullOrEmpty(persona.Foto))
            {
                var fotoPersona = Convert.FromBase64String(persona.Foto);
                persona.Foto = await AlmacenadorArchivos.GuardarArchivo(fotoPersona, ".jpg", Contenedor);
            }

            Context.Add(persona);
            await Context.SaveChangesAsync();
            return persona.Id;
        }

    }
}
