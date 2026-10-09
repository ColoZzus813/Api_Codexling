namespace CodexLing.Models
{
    public class Mensaje
    {
        public int IdMensaje { get; set; }
        public int IdUsuario { get; set; }
        public string Contenido { get; set; }
        public System.DateTime Fecha { get; set; }
    }
}
