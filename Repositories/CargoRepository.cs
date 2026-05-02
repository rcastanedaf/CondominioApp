using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class CargoRepository : ICargoRepository
    {
        private readonly string _conn;
        public CargoRepository(IConfiguration cfg) => _conn = cfg.GetConnectionString("DefaultConnection")!;
        public async Task<List<CargoModel>> GetAllAsync() {
            using IDbConnection db = new OracleConnection(_conn); 
            return (await db.QueryAsync<CargoModel>("SELECT ID_CARGO Id_Cargo,NOMBRE,DESCRIPCION,SALARIO_BASE,ACTIVO FROM CARGO ORDER BY NOMBRE")).ToList(); 
        }
        public async Task<CargoCreateRequest> Create(CargoCreateRequest r) {
            using IDbConnection db = new OracleConnection(_conn);
            await db.ExecuteAsync("INSERT INTO CARGO(NOMBRE,DESCRIPCION,SALARIO_BASE,ACTIVO) VALUES(:Nombre,:Descripcion,:Salario_Base,:Activo)", r);
            return r;
        }
        public async Task<CargoUpdateRequest> Update(CargoUpdateRequest r) {
            using IDbConnection db = new OracleConnection(_conn); 
            await db.ExecuteAsync("UPDATE CARGO SET NOMBRE=:Nombre,DESCRIPCION=:Descripcion,SALARIO_BASE=:Salario_Base,ACTIVO=:Activo WHERE ID_CARGO=:Id_Cargo", r);
            return r; 
        }
        public async Task<bool> Delete(int id) { 
            using IDbConnection db = new OracleConnection(_conn); 
            await db.ExecuteAsync("UPDATE CARGO SET ACTIVO=0 WHERE ID_CARGO=:id", new { id }); 
            return true; 
        }

    }
}
