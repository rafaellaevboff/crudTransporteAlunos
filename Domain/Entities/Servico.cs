namespace Domain.Entities
{
    public class Servico
    {
        public Servico(int id, Responsavel responsavel)
        {
            Id = id;
            this.responsavel = responsavel;
        }

        public int Id { get; set; }
        public Responsavel responsavel { get; set; }

    }
}