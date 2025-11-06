namespace FiveMotors.InputModels
{
    public class FormaDePagamentoInput
    {
        public string Descricao {  get; set; }
        public int ParcelasMax { get; set; }
        public decimal JurosMensal { get; set; }
        public decimal DescontoAVista { get; set; }
    }
}
