namespace Domain.ViewModels
{
    public class VeiculoUpdate
    { 
    public VeiculoUpdate(){}
        public VeiculoUpdate(string cor)
        {
            this.Cor = cor;
        }
        public string Cor { get; set; }

    }
}