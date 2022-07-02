using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Motorista
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Veiculo Veiculo{ get; set; }
        public int VeiculoID { get; set; }
        public List<Aluno> Alunos { get; set; }
        public List<Servico> Servicos { get; set; }
    }
}