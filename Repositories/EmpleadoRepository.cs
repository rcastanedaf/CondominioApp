using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly string _conn;
        public EmpleadoRepository(IConfiguration cfg) => _conn = cfg.GetConnectionString("DefaultConnection")!;
        public async Task<List<EmpleadoModel>> GetAllAsync() { 
            using IDbConnection db = new OracleConnection(_conn); 
            return (await db.QueryAsync<EmpleadoModel>(@"SELECT ID_EMPLEADO,ID_PERSONA,ID_CARGO,CODIGO_EMPLEADO, TO_CHAR(FECHA_INGRESO,'YYYY-MM-DD'),TO_CHAR(FECHA_BAJA,'YYYY-MM-DD'), SALARIO,TIPO_JORNADA,ESTADO,OBSERVACIONES FROM EMPLEADO ORDER BY FECHA_INGRESO DESC")).ToList(); 
        }
        public async Task<EmpleadoCreateRequest> Create(EmpleadoCreateRequest r) { 
            using IDbConnection db = new OracleConnection(_conn); await db.ExecuteAsync("INSERT INTO EMPLEADO(ID_PERSONA,ID_CARGO,CODIGO_EMPLEADO,FECHA_INGRESO,SALARIO,TIPO_JORNADA,ESTADO,OBSERVACIONES) VALUES(:Id_Persona,:Id_Cargo,:Codigo_Empleado,TO_DATE(:Fecha_Ingreso,'YYYY-MM-DD'),:Salario,:Tipo_Jornada,:Estado,:Observaciones)", r);
            return r;
        }
        public async Task<EmpleadoUpdateRequest> Update(EmpleadoUpdateRequest r) { 
            using IDbConnection db = new OracleConnection(_conn); await db.ExecuteAsync("UPDATE EMPLEADO SET ID_CARGO=:Id_Cargo,CODIGO_EMPLEADO=:Codigo_Empleado,SALARIO=:Salario,TIPO_JORNADA=:Tipo_Jornada,ESTADO=:Estado,FECHA_BAJA=TO_DATE(:Fecha_Baja,'YYYY-MM-DD'),OBSERVACIONES=:Observaciones WHERE ID_EMPLEADO=:Id_Empleado", r);
            return r; 
        }
        public async Task<bool> Delete(int id) {
            using IDbConnection db = new OracleConnection(_conn); 
            await db.ExecuteAsync("UPDATE EMPLEADO SET ESTADO='BAJA' WHERE ID_EMPLEADO=:id", new { id }); 
            return true;
        }

    }
}
