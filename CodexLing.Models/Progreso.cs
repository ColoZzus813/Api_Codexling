namespace CodexLing.Models
{
    public class Progreso
    {
        public int IdProgreso { get; set; }
        public int IdUsuario { get; set; }
        public int IdLeccion { get; set; }
        public bool Completado { get; set; }
        public System.DateTime Fecha { get; set; }
    }
}
