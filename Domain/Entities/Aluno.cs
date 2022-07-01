namespace Domain.Entities
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public Escola Escola{ get; set; }
        public int EscolaID { get; set; }
        public Motorista Motorista{ get; set; } //implementado pelo Luiz
        public int MotoristaID { get; set; }
        //public Responsavel Responsavel{ get; set; } //irá ser implementado pelo Bryan
    }
}