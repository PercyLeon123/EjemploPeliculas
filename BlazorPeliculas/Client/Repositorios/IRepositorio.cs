using BlazorPeliculas.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPeliculas.Client.Repositorios
{
    public interface IRepositorio
    {
        Task<HttpResponsewrapper<T>> GET<T>(string url);
        List<Pelicula> ObtenerPeliculas();
        Task<HttpResponsewrapper<object>> Post<T>(string url, T enviar);
        Task<HttpResponsewrapper<TResponse>> Post<T, TResponse>(string url, T enviar);
    }
}
