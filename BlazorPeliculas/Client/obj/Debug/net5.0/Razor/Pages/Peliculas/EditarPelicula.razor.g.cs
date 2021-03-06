#pragma checksum "C:\Aplicaciones\net Core\BlazorPeliculas-6\BlazorPeliculas\Client\Pages\Peliculas\EditarPelicula.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e82c2bd2952b80b760fa99be01319618e32d3547"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorPeliculas.Client.Pages.Peliculas
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Aplicaciones\net Core\BlazorPeliculas-6\BlazorPeliculas\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Aplicaciones\net Core\BlazorPeliculas-6\BlazorPeliculas\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Aplicaciones\net Core\BlazorPeliculas-6\BlazorPeliculas\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Aplicaciones\net Core\BlazorPeliculas-6\BlazorPeliculas\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Aplicaciones\net Core\BlazorPeliculas-6\BlazorPeliculas\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Aplicaciones\net Core\BlazorPeliculas-6\BlazorPeliculas\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Aplicaciones\net Core\BlazorPeliculas-6\BlazorPeliculas\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Aplicaciones\net Core\BlazorPeliculas-6\BlazorPeliculas\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Aplicaciones\net Core\BlazorPeliculas-6\BlazorPeliculas\Client\_Imports.razor"
using BlazorPeliculas.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Aplicaciones\net Core\BlazorPeliculas-6\BlazorPeliculas\Client\_Imports.razor"
using BlazorPeliculas.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Aplicaciones\net Core\BlazorPeliculas-6\BlazorPeliculas\Client\_Imports.razor"
using BlazorPeliculas.Shared.Entidades;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Aplicaciones\net Core\BlazorPeliculas-6\BlazorPeliculas\Client\_Imports.razor"
using BlazorPeliculas.Client.Repositorios;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Aplicaciones\net Core\BlazorPeliculas-6\BlazorPeliculas\Client\_Imports.razor"
using BlazorPeliculas.Client.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Aplicaciones\net Core\BlazorPeliculas-6\BlazorPeliculas\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Services;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/peliculas/editar/{PeliculaId:int}")]
    public partial class EditarPelicula : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Editar Pelicula</h3>\n\n");
            __builder.OpenComponent<BlazorPeliculas.Client.Pages.Peliculas.FormularioPeliculas>(1);
            __builder.AddAttribute(2, "Pelicula", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorPeliculas.Shared.Entidades.Pelicula>(
#nullable restore
#line 5 "C:\Aplicaciones\net Core\BlazorPeliculas-6\BlazorPeliculas\Client\Pages\Peliculas\EditarPelicula.razor"
                               Pelicula

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 5 "C:\Aplicaciones\net Core\BlazorPeliculas-6\BlazorPeliculas\Client\Pages\Peliculas\EditarPelicula.razor"
                                                        Editar

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(4, "GenerosNoSeleccionados", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.List<BlazorPeliculas.Shared.Entidades.Genero>>(
#nullable restore
#line 6 "C:\Aplicaciones\net Core\BlazorPeliculas-6\BlazorPeliculas\Client\Pages\Peliculas\EditarPelicula.razor"
                                             GenerosNoSeleccionados

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "GenerosSeleccionados", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.List<BlazorPeliculas.Shared.Entidades.Genero>>(
#nullable restore
#line 7 "C:\Aplicaciones\net Core\BlazorPeliculas-6\BlazorPeliculas\Client\Pages\Peliculas\EditarPelicula.razor"
                                           GenerosSeleccionados

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 11 "C:\Aplicaciones\net Core\BlazorPeliculas-6\BlazorPeliculas\Client\Pages\Peliculas\EditarPelicula.razor"
       
    [Parameter] public int PeliculaId { get; set; }
    Pelicula Pelicula = new Pelicula();
    private List<Genero> GenerosSeleccionados = new List<Genero>();
    private List<Genero> GenerosNoSeleccionados = new List<Genero>();

    protected override void OnInitialized()
    {
        Pelicula = new Pelicula() { Id = PeliculaId, Titulo = "Mi Pelicula" };
        GenerosNoSeleccionados = new List<Genero>()
        {
            new Genero(){Id = 1, Nombre = "Comedia"},
            new Genero(){Id = 2, Nombre = "Drama"},

            new Genero(){Id = 4, Nombre = "Sci-fi"}
        };

        GenerosSeleccionados = new List<Genero>()
        {
            new Genero(){Id = 3, Nombre = "Acción"}
        };
    }

    private void Editar()
    {
        Console.WriteLine("Editando Pelicula");
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
