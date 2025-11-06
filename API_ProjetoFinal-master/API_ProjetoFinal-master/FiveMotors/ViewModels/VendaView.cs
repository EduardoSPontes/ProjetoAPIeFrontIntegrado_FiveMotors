namespace FiveMotors.ViewModels
{
    public class VendaView
    {
        public Guid VendaId { get; set; }
        public Guid ClienteId { get; set; }
        public string NomeCliente { get; set; }

        public Guid VeiculoId { get; set; }
        public string ModeloVeiculo { get; set; }

        public Guid FormaDePagamentoId { get; set; }
        public string NomeFormaDePagamento { get; set; }

        public string Status { get; set; }
        public DateTime DataPrevistaEntrega { get; set; }

        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }

 
        public decimal Preco { get; set; }
    }
}
