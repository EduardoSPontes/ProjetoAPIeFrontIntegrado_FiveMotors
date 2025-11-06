namespace FiveMotors.ViewModels
{
    public class VeiculoView
    {
        public Guid VeiculosId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }

        public List<string> ImagemsVeiculo { get; set; }
        public int Estoque { get; set; }
    }
}
