using System;

namespace Domain.Entities
{
    public class Motorista
    {
        public Motorista(){}
        public Motorista(int id, string nome, string cpf, string telefone, string email)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Telefone = telefone;
            this.Email = email;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Veiculo veiculo{ get; set; }
    }
}