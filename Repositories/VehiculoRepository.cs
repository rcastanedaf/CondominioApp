using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly string _conn;
        public VehiculoRepository(IConfiguration cfg) => _conn = cfg.GetConnectionString("DefaultConnection")!;

        public async Task<List<VehiculoModel>> GetAllAsync()
        {
            using IDbConnection db = new OracleConnection(_conn);
            var sql = @"SELECT ID_VEHICULO Id_Vehiculo, ID_RESIDENTE Id_Residente,
                    ID_PROPIEDAD Id_Propiedad, PLACA, MARCA, MODELO, ANIO,
                    COLOR, TIPO, PARQUEO_ASIGNADO Parqueo_Asignado,
                    ACTIVO, OBSERVACIONES, TO_CHAR(FECHA_REGISTRO,'YYYY-MM-DD HH24:MI:SS') Fecha_Registro
                    FROM VEHICULO ORDER BY FECHA_REGISTRO DESC";
            return (await db.QueryAsync<VehiculoModel>(sql)).ToList();
        }

        public async Task<List<VehiculoModel>> GetByResidente(int idResidente)
        {
            using IDbConnection db = new OracleConnection(_conn);
            var sql = "SELECT * FROM VEHICULO WHERE ID_RESIDENTE = :id";
            return (await db.QueryAsync<VehiculoModel>(sql, new { id = idResidente })).ToList();
        }

        public async Task<VehiculoModel> GetById(int id)
        {
            using IDbConnection db = new OracleConnection(_conn);
            return await db.QueryFirstOrDefaultAsync<VehiculoModel>("SELECT * FROM VEHICULO WHERE ID_VEHICULO = :id", new { id });
        }

        public async Task<VehiculoCreateRequest> Create(VehiculoCreateRequest r)
        {
            using IDbConnection db = new OracleConnection(_conn);
            var sql = @"INSERT INTO VEHICULO(ID_RESIDENTE,ID_PROPIEDAD,PLACA,MARCA,MODELO,ANIO,COLOR,TIPO,PARQUEO_ASIGNADO,ACTIVO,OBSERVACIONES)
                    VALUES(:Id_Residente,:Id_Propiedad,:Placa,:Marca,:Modelo,:Anio,:Color,:Tipo,:Parqueo_Asignado,:Activo,:Observaciones)";
            await db.ExecuteAsync(sql, r);
            return r;
        }

        public async Task<VehiculoUpdateRequest> Update(VehiculoUpdateRequest r)
        {
            using IDbConnection db = new OracleConnection(_conn);
            var sql = @"UPDATE VEHICULO SET ID_RESIDENTE=:Id_Residente, ID_PROPIEDAD=:Id_Propiedad,
                    PLACA=:Placa, MARCA=:Marca, MODELO=:Modelo, ANIO=:Anio, COLOR=:Color,
                    TIPO=:Tipo, PARQUEO_ASIGNADO=:Parqueo_Asignado, ACTIVO=:Activo, OBSERVACIONES=:Observaciones
                    WHERE ID_VEHICULO = :Id_Vehiculo";
            await db.ExecuteAsync(sql, r);
            return r;
        }

        public async Task<bool> Delete(int id)
        {
            using IDbConnection db = new OracleConnection(_conn);
            await db.ExecuteAsync("UPDATE VEHICULO SET ACTIVO=0 WHERE ID_VEHICULO=:id", new { id });
            return true;
        }

    }
}
