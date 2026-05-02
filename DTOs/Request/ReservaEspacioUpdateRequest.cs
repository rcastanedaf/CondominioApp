namespace Condominio.DTOs.Request
{
    public class ReservaEspacioUpdateRequest : ReservaEspacioCreateRequest
    {
        public int Id_Reserva { get; set; }
        public string Estado { get; set; }
        public int? Aprobado_Por { get; set; }
        public int Deposito_Devuelto { get; set; }

    }
}
