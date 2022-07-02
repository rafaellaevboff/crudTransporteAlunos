namespace Domain.Entities
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }

        // CHAVES ESTRANGEIRAS:
        public Escola Escola{ get; set; }
        public int EscolaID { get; set; }

        public Motorista Motorista{ get; set; }
        public int MotoristaID { get; set; }

        public Responsavel Responsavel{ get; set; }
        public int ResponsavelID { get; set; }

        public Servico Servico{ get; set; }
    }
}