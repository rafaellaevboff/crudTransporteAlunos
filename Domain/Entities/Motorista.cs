using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Motorista
    {
        public  Motorista(){}
        public Motorista(int id, string nome, string cpf, string telefone, string email, Veiculo veiculo, int VeiculoID)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
            this.Veiculo = veiculo;
            this.VeiculoID = VeiculoID;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Veiculo Veiculo{ get; set; }
        public int VeiculoID { get; set; }
        public List<Aluno> Alunos { get; set; }
        
    }
}