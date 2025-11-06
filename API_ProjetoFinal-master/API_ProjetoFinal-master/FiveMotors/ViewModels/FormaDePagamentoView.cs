namespace FiveMotors.ViewModels
{
    public class FormaDePagamentoView
    {
        public Guid FormaDePagamentoId { get; set; }
        public string Descricao { get; set; }
        public int ParcelasMax { get; set; }
        public decimal JurosMensal { get; set; }
        public decimal DescontoAVista { get; set; }
    }
}
