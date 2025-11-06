namespace FiveMotors.InputModels
{
    public class VendaInput
    {
        public Guid ClienteId { get; set; }
        public Guid VeiculoId { get; set; }
        public Guid FormaDePagamentoId { get; set; }
        public DateTime DataHora { get; set; }

        public string Status { get; set; }
        public DateTime DataPrevistaEntrega { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public int Estoque { get; set; }
    }
}
