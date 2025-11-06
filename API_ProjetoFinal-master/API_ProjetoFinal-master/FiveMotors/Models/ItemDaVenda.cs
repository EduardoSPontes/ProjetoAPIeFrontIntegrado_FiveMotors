namespace FiveMotors.Models
{
    public class ItemDaVenda
    {
        public Guid ItemDaVendaId { get; set; }
        public Guid VendaId { get; set; }
        public Venda? Venda { get; set; }
        public Guid VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Total { get; set; }
    }
}
