using Domain.Entities;

namespace Domain.DTO
{
    public class AlunoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public Escola Escola { get; set; }
        public Motorista Motorista { get; set; }
        public int ResponsavelID { get; set; }
        public int ServicoID { get; set; }
    }
}