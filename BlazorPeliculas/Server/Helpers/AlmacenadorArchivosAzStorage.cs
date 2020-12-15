using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPeliculas.Server.Helpers
{
    public class AlmacenadorArchivosAzStorage : IAlmacenadorArchivos
    {
        private string ConnectionString;
        public AlmacenadorArchivosAzStorage(IConfiguration configuration) 
        {
            ConnectionString = configuration.GetConnectionString("AzureStorage");
        }

        public async Task<string> EditarArchivos(byte[] contenido, string extension, string nombreContenedor, string ruta)
        {
            if (!string.IsNullOrEmpty(ruta)) 
            {
                await EliminarArchivo(ruta, nombreContenedor);
            }
            
            return await GuardarArchivo(contenido, extension, nombreContenedor);
        }

        public async Task EliminarArchivo(string ruta, string nombreContendor)
        {
            if (string.IsNullOrEmpty(ruta)) 
            {
                return;
            }

            var cliente = new BlobContainerClient(ConnectionString, nombreContendor);
            await cliente.CreateIfNotExistsAsync();
            var nombreArchivo = Path.GetFileName(nombreContendor);
            var blob = cliente.GetBlobClient(nombreArchivo);
            await blob.DeleteIfExistsAsync();
        }

        public async Task<string> GuardarArchivo(byte[] contenido, string extension, string nombreContenedor)
        {
            var cliente = new BlobContainerClient(ConnectionString, nombreContenedor);
            await cliente.CreateIfNotExistsAsync();
            cliente.SetAccessPolicy(Azure.Storage.Blobs.Models.PublicAccessType.Blob);

            var archivoNombre = $"{Guid.NewGuid()}{extension}";
            var blob = cliente.GetBlobClient(archivoNombre);

            using (var ms = new MemoryStream(contenido)) 
            {
                await blob.UploadAsync(ms);
            }

            return blob.Uri.ToString();
        }
    }
}
