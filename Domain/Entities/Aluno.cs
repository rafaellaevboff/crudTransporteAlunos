namespace Domain.Entities
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public Escola escola{ get; set; }
        // public Responsavel Responsavel{ get; set; } //irá ser implementado pelo Bryan
        // public Veiculo veiculo{ get; set; } //implementado pelo Luiz
    }
}