namespace FiveMotors.InputModels
{
    public class AgendamentoInput
    {
        public Guid ClienteId { get; set; }
        public Guid VeiculoId { get; set; }
        public DateTime DataHora { get; set; }
        public string Observação { get; set; }
    }
   
}

