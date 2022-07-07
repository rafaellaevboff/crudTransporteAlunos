namespace Domain.Entities
{
    public class Servico
    {

        public int Id { get; set; }
        public string Cnpj { get; set; }

        // chaves estrangeiras
        public Aluno Aluno{ get; set; }
        public int AlunoID { get; set; }

        public Motorista Motorista { get; set; }
        public int MotoristaID { get; set; }

        public Responsavel Responsavel{ get; set; }
        public int ResponsavelID { get; set; }
     }
}