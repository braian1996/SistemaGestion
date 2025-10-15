using System.Security.Cryptography;
using System.Text;

namespace WinFormsWenSoftAdmin.Negocio
{
    public static class Seguridad
    {
        public static string ObtenerHashSha256(string textoPlano)
        {
            if (string.IsNullOrWhiteSpace(textoPlano))
                return string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(textoPlano.Trim());
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                    sb.Append(b.ToString("x2")); // 2 caracteres hex por byte

                return sb.ToString();
            }
        }
    }
}
