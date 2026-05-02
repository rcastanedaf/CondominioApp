using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using Org.BouncyCastle.Crypto.Generators;
using System.Data;

namespace Condominio.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _conn;
        public UsuarioRepository(IConfiguration cfg) => _conn = cfg.GetConnectionString("DefaultConnection")!;

        public async Task<List<UsuarioModel>> GetAllAsync()
        {
            using IDbConnection db = new OracleConnection(_conn);
            return (await db.QueryAsync<UsuarioModel>(@"SELECT ID_USUARIO Id_Usuario,ID_PERSONA Id_Persona,USERNAME,
            ID_ROL Id_Rol,ACTIVO,PRIMER_INGRESO Primer_Ingreso,
            TO_CHAR(ULTIMO_ACCESO,'YYYY-MM-DD HH24:MI') Ultimo_Acceso,
            INTENTOS_FALLIDOS Intentos_Fallidos,BLOQUEADO,
            TO_CHAR(FECHA_VENCIMIENTO,'YYYY-MM-DD') Fecha_Vencimiento
            FROM USUARIO_SISTEMA ORDER BY USERNAME")).ToList();
        }

        public async Task<UsuarioModel> GetByUsername(string username)
        {
            using IDbConnection db = new OracleConnection(_conn);
            return await db.QueryFirstOrDefaultAsync <UsuarioModel>("SELECT * FROM USUARIO_SISTEMA WHERE USERNAME=:username AND ACTIVO=1", new { username });
        }

        public async Task<UsuarioCreateRequest> Create(UsuarioCreateRequest r, string passwordHash, string salt)
        {
            using IDbConnection db = new OracleConnection(_conn);
            await db.ExecuteAsync(@"INSERT INTO USUARIO_SISTEMA(ID_PERSONA,USERNAME,PASSWORD_HASH,PASSWORD_SALT,ID_ROL,ACTIVO,FECHA_VENCIMIENTO)
            VALUES(:Id_Persona,:Username,:hash,:salt,:Id_Rol,:Activo,TO_DATE(:Fecha_Vencimiento,'YYYY-MM-DD'))",
            new { r.Id_Persona, r.Username, hash = passwordHash, salt, r.Id_Rol, r.Activo, r.Fecha_Vencimiento });
            return r;
        }

        public async Task<bool> Update(UsuarioUpdateRequest r)
        {
            using IDbConnection db = new OracleConnection(_conn);
            await db.ExecuteAsync("UPDATE USUARIO_SISTEMA SET ID_ROL=:Id_Rol,ACTIVO=:Activo,FECHA_VENCIMIENTO=TO_DATE(:Fecha_Vencimiento,'YYYY-MM-DD') WHERE ID_USUARIO=:Id_Usuario", r);
            return true;
        }

        public async Task<bool> CambiarPassword(int id, string newHash, string salt)
        {
            using IDbConnection db = new OracleConnection(_conn);
            await db.ExecuteAsync("UPDATE USUARIO_SISTEMA SET PASSWORD_HASH=:hash,PASSWORD_SALT=:salt,PRIMER_INGRESO=0 WHERE ID_USUARIO=:id", new { hash = newHash, salt, id });
            return true;
        }

        public async Task<bool> Desbloquear(int id)
        {
            using IDbConnection db = new OracleConnection(_conn);
            await db.ExecuteAsync("UPDATE USUARIO_SISTEMA SET BLOQUEADO=0,INTENTOS_FALLIDOS=0 WHERE ID_USUARIO=:id", new { id });
            return true;
        }

        public async Task<(string hash, string salt)> GetCredenciales(string username)
        {
            using IDbConnection db = new OracleConnection(_conn);
            var row = await db.QueryFirstOrDefaultAsync("SELECT PASSWORD_HASH,PASSWORD_SALT FROM USUARIO_SISTEMA WHERE USERNAME=:username", new { username });
            return row == null ? (null, null) : ((string)row.PASSWORD_HASH, (string)row.PASSWORD_SALT);
        }

        private string ComputeHash(string password, string salt)
        {
            using var sha = System.Security.Cryptography.SHA256.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(password + salt);
            return Convert.ToHexString(sha.ComputeHash(bytes)).ToLower();
        }

        public async Task<object> Login(string username, string password)
        {
            using var conn = new OracleConnection(_conn);
            var sql = @"SELECT u.ID_USUARIO id, u.USERNAME username, u.ID_ROL id_rol,
                       p.NOMBRES nombres, p.APELLIDOS apellidos
                    FROM USUARIO_SISTEMA u
                    JOIN PERSONA p ON p.ID_PERSONA = u.ID_PERSONA
                    WHERE u.USERNAME = :usr AND u.ACTIVO = 1";
            var row = await conn.QueryFirstOrDefaultAsync(sql, new { usr = username });
            if (row == null) throw new Exception("Usuario no encontrado o inactivo");
            var creds = await GetCredenciales(username);
            if (creds.hash == null) throw new Exception("Usuario no encontrado");

            var hashIngresado = ComputeHash(password, creds.salt);
            // LOG TEMPORAL — quítalo después
            Console.WriteLine($"[DEBUG] hash BD:       {creds.hash}");
            Console.WriteLine($"[DEBUG] hash calculado:{hashIngresado}");
            Console.WriteLine($"[DEBUG] salt usado:    {creds.salt}");
            if (hashIngresado != creds.hash) throw new Exception("Contraseña incorrecta");
            // Verificar bloqueo
            var usuario = await GetByUsername(username);
            if (usuario.Bloqueado == 1) throw new Exception("Usuario bloqueado. Contacta al administrador.");

            // Registrar último acceso
            using var connUpdate = new OracleConnection(_conn);
            await connUpdate.ExecuteAsync(
                "UPDATE USUARIO_SISTEMA SET ULTIMO_ACCESO=SYSDATE WHERE USERNAME=:usr",
                new { usr = username });
            // Si usas SHA256: var hash = ComputeHash(password + row.salt);
            // if (hash != row.password_hash) throw new Exception("Contraseña incorrecta");
            return row;
        }

    }
}
