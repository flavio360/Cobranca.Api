namespace Cobranca.Api.Models.Seguranca
{
    public class LoginModelRequest
    {
        public string Email { get; set; }
        public string HashSenha { get; set; }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string HashSenha { get; set; }
    }

    public class LoginModelRetorno
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public int PerfilId { get; set; }

    }
}
