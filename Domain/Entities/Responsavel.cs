namespace Domain.Entities
{
    public class Responsavel
    {
        public Responsavel(int id, string nome, string endereco, int cPF)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            CPF = cPF;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int CPF { get; set; }
    }
}