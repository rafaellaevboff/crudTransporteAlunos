using Domain.Entities;

namespace Domain.ViewModels
{
    public class AlunoCreate
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public Escola escola{ get; set; }
    }
}