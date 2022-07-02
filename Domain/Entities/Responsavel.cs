namespace Domain.Entities
{
    public class Responsavel
    {
        public  Responsavel(){}
        public Responsavel(int id, string nome, string endereco, int cpf)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            Cpf = cpf;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Cpf { get; set; }
        public List<Servico> Servicos { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}