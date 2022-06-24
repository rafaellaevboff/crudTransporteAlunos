namespace Domain.ViewModels
{
    public class MotoristaUpdate
    {

    public MotoristaUpdate(){}
        public MotoristaUpdate(string nome, string telefone, string email)
        {
            this.Nome = nome;
            this.Telefone = telefone;
            this.Email = email;
        }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}