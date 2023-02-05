namespace moduloRh.Domain.Model
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        // TODO: encripitar senha
        public string Password { get; set; }
        //TODO: multiplas roles

        //TODO: Adicionar Status
    }
}
