namespace Condominio.Models
{
    public class ReservaEspacioModel
    {
        public int Id_Reserva { get; set; }
        public int Id_Espacio { get; set; }
        public int Id_Residente { get; set; }
        public int Id_Propiedad { get; set; }
        public string Fecha_Reserva { get; set; }
        public string Hora_Inicio { get; set; }
        public string Hora_Fin { get; set; }
        public int Num_Personas { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }
        public decimal Monto_Cobro { get; set; }
        public decimal Deposito_Cobrado { get; set; }
        public int Deposito_Devuelto { get; set; }
        public int? Id_Factura { get; set; }
        public int? Aprobado_Por { get; set; }
        public string Observaciones { get; set; }
        public string Fecha_Registro { get; set; }

    }
}
