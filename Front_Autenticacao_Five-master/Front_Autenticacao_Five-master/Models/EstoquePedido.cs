namespace FiveMotors.Models
{
    public class EstoquePedido
    {
        public Guid EstoquePedidoId { get; set; }
        public Guid VeiculosId { get; set; }
        public string Modelo { get; set; }

        public int Ano {  get; set; }

     
        public string StatusPedido { get; set; }
        public int QuantidadeDisponivel { get; set; }
    }
}
