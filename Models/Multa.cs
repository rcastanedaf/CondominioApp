namespace Condominio.Models
{
    public class Multa
    {
        public Multa()
        {

        }
        public Multa(int idResidente, int idPropiedad, int idTipoInfraccion, string descripcion, decimal monto, DateOnly fechaInfraccion, DateOnly fechaVencimiento, int estado, string evidencia, int idFactura, int idApelacion, int idEmitida, int idAprobada, string observaciones, DateOnly fechaRegistro)
        {
            Id_Residente = idResidente;
            Id_Propiedad = idPropiedad;
            Id_Tipo_Infraccion = idTipoInfraccion;
            Descripcion = descripcion;
            Monto = monto;
            Fecha_Infraccion = fechaInfraccion;
            Fecha_Vencimiento = fechaVencimiento;
            Estado = estado;
            Evidencia = evidencia;
            Id_Factura = idFactura;
            Id_Apelacion = idApelacion;
            Id_Emitida = idEmitida;
            Id_Aprobada = idAprobada;
            Observaciones = observaciones;
            Fecha_Registro = fechaRegistro;
        }

        public int Id_Multa { get; set; }
        public int Id_Residente { get; set; }
        public int Id_Propiedad { get; set; }
        public int Id_Tipo_Infraccion { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public DateOnly Fecha_Infraccion { get; set; }
        public DateOnly Fecha_Vencimiento { get; set; }
        public int Estado { get; set; }
        public string Evidencia { get; set; }
        public int Id_Factura { get; set; }
        public int Id_Apelacion { get; set; }
        public int Id_Emitida { get; set; }
        public int Id_Aprobada { get; set; }
        public string Observaciones { get; set; }
        public DateOnly Fecha_Registro { get; set; }
    }
}
