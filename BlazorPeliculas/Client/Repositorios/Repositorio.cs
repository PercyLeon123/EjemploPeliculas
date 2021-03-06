﻿using BlazorPeliculas.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorPeliculas.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
        private readonly HttpClient HttpClient;
        public Repositorio(HttpClient httpClient) 
        {
            this.HttpClient = httpClient;
        }

        private JsonSerializerOptions OpcionesPorDefectoJSON =>
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public async Task<HttpResponsewrapper<T>> GET<T>(string url)
        {
           
            var responseHttp = await HttpClient.GetAsync(url);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await DeserializarRespuesta<T>(responseHttp, OpcionesPorDefectoJSON);
                return new HttpResponsewrapper<T>(response, false, responseHttp);
            }
            else 
            {
                return new HttpResponsewrapper<T>(default, true, responseHttp);
            }
        }

        public async Task<HttpResponsewrapper<object>> Post<T>(string url, T enviar) 
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await HttpClient.PostAsync(url, enviarContent);
            return new HttpResponsewrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        public async Task<HttpResponsewrapper<TResponse>> Post<T, TResponse>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await HttpClient.PostAsync(url, enviarContent);

            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await DeserializarRespuesta<TResponse>(responseHttp, OpcionesPorDefectoJSON);
                return new HttpResponsewrapper<TResponse>(response, false, responseHttp);
            }
            else 
            {
                return new HttpResponsewrapper<TResponse>(default, true, responseHttp);
            }
            
        }

        private async Task<T> DeserializarRespuesta<T>(HttpResponseMessage httpResponse, JsonSerializerOptions jsonDocumentOptions) 
        {
            var responseString = await httpResponse.Content.ReadAsByteArrayAsync();
            return JsonSerializer.Deserialize<T>(responseString, jsonDocumentOptions);
        }

        public List<Pelicula> ObtenerPeliculas()
        {
            return new List<Pelicula>()
            {
                    new Pelicula(){Titulo = "Spider-Man: Far From Home",
                        Lanzamiento  = new DateTime(2019, 7, 2),
                    Poster = "https://m.media-amazon.com/images/M/MV5BMGZlNTY1ZWUtYTMzNC00ZjUyLWE0MjQtMTMxN2E3ODYxMWVmXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_UX182_CR0,0,182,268_AL_.jpg"},
                    new Pelicula(){Titulo = "Moana", Lanzamiento  = new DateTime(2016, 11, 23),
                    Poster = "https://m.media-amazon.com/images/M/MV5BMjI4MzU5NTExNF5BMl5BanBnXkFtZTgwNzY1MTEwMDI@._V1_UX182_CR0,0,182,268_AL_.jpg"},
                    new Pelicula(){Titulo = "Inception", Lanzamiento  = new DateTime(2010, 7, 16),
                    Poster = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg"}
            };
        }
    }
}
