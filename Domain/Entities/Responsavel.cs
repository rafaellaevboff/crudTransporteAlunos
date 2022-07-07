namespace Domain.Entities
{
    public class Responsavel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cpf { get; set; }

        //chaves estrangeiras
        public List<Servico> Servicos { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}