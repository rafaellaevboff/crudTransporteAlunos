namespace Domain.Entities
{
    public class Servico
    {
        public Servico(int id, Responsavel responsavel)
        {
            Id = id;
            this.Responsavel = responsavel;
        }

        public int Id { get; set; }
        public Responsavel Responsavel { get; set; }

    }
}