using System;
using System.Security.Cryptography;

namespace BeautyGlam.LogicaDeNegocio.Seguridad
{
    public class PasswordHasher
    {
        private const int SALT_SIZE = 16;
        private const int HASH_SIZE = 64;
        private const int ITERACIONES = 100000;

        // ============================
        // Generar SALT
        // ============================
        public byte[] GenerarSalt()
        {
            byte[] salt = new byte[SALT_SIZE];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        // ============================
        // Generar HASH
        // ============================
        public byte[] GenerarHash(string password, byte[] salt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("La contraseña no puede ser vacía.");
            }

            if (salt == null || salt.Length != SALT_SIZE)
            {
                throw new ArgumentException("Salt inválido.");
            }

            byte[] hash;

            using (Rfc2898DeriveBytes pbkdf2 =
                   new Rfc2898DeriveBytes(password, salt, ITERACIONES))
            {
                hash = pbkdf2.GetBytes(HASH_SIZE);
            }

            return hash;
        }

        // ============================
        // Crear HASH + SALT (REGISTRO)
        // ============================
        public void CrearHash(string password, out byte[] salt, out byte[] hash)
        {
            salt = GenerarSalt();
            hash = GenerarHash(password, salt);
        }

        // ============================
        // Verificar contraseña (LOGIN)
        // ============================
        public bool Verificar(string password, byte[] salt, byte[] hashEsperado)
        {
            if (string.IsNullOrWhiteSpace(password)) return false;
            if (salt == null || salt.Length != SALT_SIZE) return false;
            if (hashEsperado == null || hashEsperado.Length != HASH_SIZE) return false;

            byte[] hashActual = GenerarHash(password, salt);

            int diferencia = 0;
            int i = 0;

            while (i < hashActual.Length)
            {
                diferencia |= hashActual[i] ^ hashEsperado[i];
                i++;
            }

            return diferencia == 0;
        }
    }
}
