using System.Collections.Generic;

namespace Domain.Entities
{
    public class Escola
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}