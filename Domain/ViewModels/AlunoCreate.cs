using Domain.Entities;

namespace Domain.ViewModels
{
    public class AlunoCreate
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int EscolaID { get; set; }
        public int MotoristaID { get; set; }
        public int ResponsavelID { get; set; }
    }
}