namespace FiveMotors.Models
{
    public class Agendamento
    {
        public Guid AgendamentoId { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public Guid VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }
        public DateTime DataHora { get; set; }
        public string Observação { get; set; }
    }
}
