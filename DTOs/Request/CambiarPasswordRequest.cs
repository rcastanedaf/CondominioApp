namespace Condominio.DTOs.Request
{
    public class CambiarPasswordRequest
    {
        public int Id_Usuario { get; set; }
        public string Password_Actual { get; set; }
        public string Password_Nueva { get; set; }
    }
}
