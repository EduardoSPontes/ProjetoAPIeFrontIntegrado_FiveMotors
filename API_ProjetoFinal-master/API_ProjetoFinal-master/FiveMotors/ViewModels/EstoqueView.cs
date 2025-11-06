namespace FiveMotors.ViewModels
{
    public class Estoque
    {
        public Guid EstoquePedidoId { get; set; }
        public Guid VeiculoId { get; set; }
        public string Modelo { get; set; }

        public int Ano { get; set; }

        public string StatusPedido { get; set; }
        public int QuantidadeDisponivel { get; set; }
    }
}
