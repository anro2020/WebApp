using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        public async Task<IActionResult> Registrar(UsuarioModel usuario)
        {
            var contenidoJson = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("usu_nombre", usuario.usu_nombre),
            new KeyValuePair<string, string>("usu_correo", usuario.usu_correo),
            new KeyValuePair<string, string>("usu_contrasenia", usuario.usu_contrasenia),
            new KeyValuePair<string, string>("confirmarContrasenia", usuario.usu_confirmarContrasenia)
        });

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsync("http://127.0.0.1:8000/api/NuevoUsuario", contenidoJson);

            usuario.mensaje = string.Empty;

            if (response.IsSuccessStatusCode)
            {
                usuario.mensaje = await response.Content.ReadAsStringAsync();
            }

            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Dashboard()
        {
            var respuesta = new List<UsuarioModel>();

            HttpClient httpClient = new HttpClient();

            using (var response = await httpClient.GetAsync("http://127.0.0.1:8000/api/Usuarios"))
            {
                string apiReponse = await response.Content.ReadAsStringAsync();

                respuesta = JsonConvert.DeserializeObject<List<UsuarioModel>>(apiReponse);
            };

            return View(respuesta);
        }
    }
}
