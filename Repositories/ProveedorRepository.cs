using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly string _conn;
        public ProveedorRepository(IConfiguration cfg) => _conn = cfg.GetConnectionString("DefaultConnection")!;
        public async Task<List<ProveedorModel>> GetAllAsync() { using IDbConnection db = new OracleConnection(_conn); 
            return (await db.QueryAsync<ProveedorModel>("SELECT ID_PROVEEDOR Id_Proveedor,NOMBRE_EMPRESA Nombre_Empresa,NIT,RUBRO,TELEFONO,EMAIL,CONTACTO_NOMBRE Contacto_Nombre,CONTACTO_TELEFONO Contacto_Telefono,DIRECCION,ACTIVO,OBSERVACIONES FROM PROVEEDOR ORDER BY NOMBRE_EMPRESA")).ToList(); 
        }
        public async Task<ProveedorCreateRequest> Create(ProveedorCreateRequest r) { 
            using IDbConnection db = new OracleConnection(_conn); await db.ExecuteAsync("INSERT INTO PROVEEDOR(NOMBRE_EMPRESA,NIT,RUBRO,TELEFONO,EMAIL,CONTACTO_NOMBRE,CONTACTO_TELEFONO,DIRECCION,ACTIVO,OBSERVACIONES) VALUES(:Nombre_Empresa,:Nit,:Rubro,:Telefono,:Email,:Contacto_Nombre,:Contacto_Telefono,:Direccion,:Activo,:Observaciones)", r); 
            return r; 
        }
        public async Task<ProveedorUpdateRequest> Update(ProveedorUpdateRequest r) {
            using IDbConnection db = new OracleConnection(_conn); await db.ExecuteAsync("UPDATE PROVEEDOR SET NOMBRE_EMPRESA=:Nombre_Empresa,NIT=:Nit,RUBRO=:Rubro,TELEFONO=:Telefono,EMAIL=:Email,CONTACTO_NOMBRE=:Contacto_Nombre,CONTACTO_TELEFONO=:Contacto_Telefono,DIRECCION=:Direccion,ACTIVO=:Activo,OBSERVACIONES=:Observaciones WHERE ID_PROVEEDOR=:Id_Proveedor", r);
            return r; 
        }
        public async Task<bool> Delete(int id) { using IDbConnection db = new OracleConnection(_conn); await db.ExecuteAsync("UPDATE PROVEEDOR SET ACTIVO=0 WHERE ID_PROVEEDOR=:id", new { id }); 
            return true; 
        }

    }
}
