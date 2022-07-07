using Domain.Entities;

namespace Domain.DTO
{
    public class AlunoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int EscolaID { get; set; }
        public int MotoristaID { get; set; }
        public int ResponsavelID { get; set; }
        public int ServicoID { get; set; }
    }
}