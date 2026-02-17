using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BeautyGlam.AccesoADatos.Usuario
{
    public class UsuarioRegistroAD
    {
        private readonly string _conexion;

        public UsuarioRegistroAD()
        {
            _conexion = ConfigurationManager.ConnectionStrings["Contexto"].ConnectionString;
        }

        public bool ExisteCorreo(string correo)
        {
            using (SqlConnection cn = new SqlConnection(_conexion))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM Usuario WHERE correo = @correo", cn))
                {
                    cmd.Parameters.Add("@correo", SqlDbType.VarChar, 200).Value = correo;
                    cn.Open();
                    int cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                    return cantidad > 0;
                }
            }
        }

        public bool ExisteUsername(string username)
        {
            using (SqlConnection cn = new SqlConnection(_conexion))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM Usuario WHERE username = @username", cn))
                {
                    cmd.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = username;
                    cn.Open();
                    int cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                    return cantidad > 0;
                }
            }
        }

        public void Insertar(RegisterDTO model, byte[] salt, byte[] hash)
        {
            using (SqlConnection cn = new SqlConnection(_conexion))
            {
                using (SqlCommand cmd = new SqlCommand(@"
INSERT INTO Usuario
(
    nombre, apellido, username, correo,
    telefono, direccion,
    fecha_Registro,
    passwordHash, passwordSalt,
    rol, estado
)
VALUES
(
    @nombre, @apellido, @username, @correo,
    NULL, NULL,
    GETDATE(),
    @hash, @salt,
    'Usuario', 1
);", cn))
                {
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = model.nombre;
                    cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = model.apellido;
                    cmd.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = model.username;
                    cmd.Parameters.Add("@correo", SqlDbType.VarChar, 200).Value = model.correo;

                    cmd.Parameters.Add("@hash", SqlDbType.VarBinary, 64).Value = hash;
                    cmd.Parameters.Add("@salt", SqlDbType.VarBinary, 16).Value = salt;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
