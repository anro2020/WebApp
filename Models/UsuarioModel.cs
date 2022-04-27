using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class UsuarioModel
    {
        [Required]
        public string usu_correo { set; get; }
        public string usu_contrasenia { set; get; }
        public string usu_confirmarContrasenia { set; get; }
        public string usu_nombre { set; get; }
        public string mensaje { set; get; }

        public UsuarioModel() 
        {
            mensaje = string.Empty;
            usu_correo = string.Empty;
            usu_contrasenia = string.Empty;
            usu_confirmarContrasenia = string.Empty;
            usu_nombre = string.Empty;
        }
        
        
    }
}
