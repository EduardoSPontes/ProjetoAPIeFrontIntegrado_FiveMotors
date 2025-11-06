using FiveMotors.InputModels;
using FiveMotors.Models;
using FiveMotors.ViewModels;

namespace FiveMotors.Mappers
{
    public class AgendamentoMapper
    {
        public static Agendamento ToEntity(AgendamentoInput input)
        {
            return new Agendamento
            {
                AgendamentoId = Guid.NewGuid(),
                ClienteId = input.ClienteId,
                VeiculoId = input.VeiculoId,
                DataHora = input.DataHora,
                Observação = input.Observação,
            };
        }

        public static AgendamentoView ToDto(Agendamento entity)
        {
            return new AgendamentoView
            {
                AgendamentoId = entity.AgendamentoId,
                ClienteId = entity.ClienteId,
                VeiculoId = entity.VeiculoId,
                DataHora = entity.DataHora,
                Observação = entity.Observação,
                NomeCliente = entity.Cliente.Nome,
                NomeVeiculo = entity.Veiculo.Modelo
            };
        }

        public static void Update(Agendamento entity, AgendamentoInput input)
        {
            entity.DataHora = input.DataHora;
            entity.Observação = input.Observação;
        }
    }
}
