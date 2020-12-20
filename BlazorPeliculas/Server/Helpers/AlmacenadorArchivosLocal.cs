using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPeliculas.Server.Helpers
{
    public class AlmacenadorArchivosLocal : IAlmacenadorArchivos
    {
        private readonly IWebHostEnvironment Env;
        private readonly IHttpContextAccessor HttpContextAccessor;

        public AlmacenadorArchivosLocal(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            this.Env = env;
            this.HttpContextAccessor = httpContextAccessor;
        }
        public async Task<string> EditarArchivos(byte[] contenido, string extension, string nombreContenedor, string ruta)
        {
            if (!string.IsNullOrEmpty(ruta))
            {
                await EliminarArchivo(ruta, nombreContenedor);
            }

            return await GuardarArchivo(contenido, extension, nombreContenedor);
        }

        public Task EliminarArchivo(string ruta, string nombreContendor)
        {
            var filename = Path.GetFileName(ruta);
            string directorioArchivo = Path.Combine(Env.WebRootPath, nombreContendor, filename);
            if (File.Exists(directorioArchivo)) 
            {
                File.Delete(directorioArchivo);
            }
            return Task.FromResult(0);
        }

        public async Task<string> GuardarArchivo(byte[] contenido, string extension, string nombreContenedor)
        {
            var filename = $"{Guid.NewGuid()}.{extension}";
            string folder = Path.Combine(Env.WebRootPath, nombreContenedor);

            if (!Directory.Exists(folder)) 
            {
                Directory.CreateDirectory(folder);
            }

            string rutaGuardado = Path.Combine(folder, filename);
            await File.WriteAllBytesAsync(rutaGuardado, contenido);
            /* Devolvemos la ruta */
            var urlActual = $"{HttpContextAccessor.HttpContext.Request.Scheme}://{HttpContextAccessor.HttpContext.Request.Host}";
            var rutaParaDB = Path.Combine(urlActual, nombreContenedor, filename);
            return rutaParaDB;
        }
    }
}
