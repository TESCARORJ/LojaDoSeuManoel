using System.Text;

namespace LojaDoSeuManoel.API.Security
{
    public static class BasicAuthenticationSecurity
    {
        // Defina suas credenciais fixas aqui
        private const string Username = "LDSM_Tescaro";
        private const string Password = "thiagotescaro2024";

        public static bool AuthenticateRequest(HttpRequest request)
        {
            if (!request.Headers.ContainsKey("Authorization"))
            {
                return false;
            }

            var authHeader = request.Headers["Authorization"].ToString();
            if (authHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
            {
                var encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));

                var username = decodedUsernamePassword.Split(':')[0];
                var password = decodedUsernamePassword.Split(':')[1];

                return username == Username && password == Password;
            }

            return false;
        }
    }
}
