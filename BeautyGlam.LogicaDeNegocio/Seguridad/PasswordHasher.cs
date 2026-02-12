using System.Security.Cryptography;

namespace BeautyGlam.LogicaDeNegocio.Seguridad
{
    public class PasswordHasher
    {
        public byte[] GenerarSalt()
        {
            byte[] salt = new byte[16];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public byte[] GenerarHash(string password, byte[] salt)
        {
            byte[] hash;
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000))
            {
                hash = pbkdf2.GetBytes(64);
            }
            return hash;
        }

        public bool Verificar(string password, byte[] salt, byte[] hashEsperado)
        {
            byte[] hashActual = GenerarHash(password, salt);

            if (hashActual.Length != hashEsperado.Length) return false;

            int iguales = 0;
            int i = 0;
            while (i < hashActual.Length)
            {
                iguales = iguales | (hashActual[i] ^ hashEsperado[i]);
                i++;
            }

            return iguales == 0;
        }
    }
}
