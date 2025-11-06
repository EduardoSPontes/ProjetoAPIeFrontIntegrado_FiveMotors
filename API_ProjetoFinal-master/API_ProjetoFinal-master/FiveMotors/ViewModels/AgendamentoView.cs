namespace FiveMotors.ViewModels
{
    public class AgendamentoView
    {
        public Guid AgendamentoId { get; set; }

        public Guid ClienteId { get; set; }
        public string NomeCliente { get; set; }

        public Guid VeiculoId { get; set; }
        public string NomeVeiculo { get; set; }  

        public DateTime DataHora { get; set; }
        public string Observação { get; set; }

    }
}
