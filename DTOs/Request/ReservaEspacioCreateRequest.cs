namespace Condominio.DTOs.Request
{
    public class ReservaEspacioCreateRequest
    {
        public int Id_Espacio { get; set; }
        public int Id_Residente { get; set; }
        public int Id_Propiedad { get; set; }
        public string Fecha_Reserva { get; set; }
        public string Hora_Inicio { get; set; }
        public string Hora_Fin { get; set; }
        public int Num_Personas { get; set; } = 1;
        public string Motivo { get; set; }
        public decimal Monto_Cobro { get; set; } = 0;
        public decimal Deposito_Cobrado { get; set; } = 0;
        public string Observaciones { get; set; }

    }
}
