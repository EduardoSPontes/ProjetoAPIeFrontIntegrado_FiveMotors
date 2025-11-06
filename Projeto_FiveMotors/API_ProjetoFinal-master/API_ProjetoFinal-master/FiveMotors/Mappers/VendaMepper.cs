using FiveMotors.InputModels;
using FiveMotors.Models;
using FiveMotors.ViewModels;

namespace FiveMotors.Mappers
{
    public class VendaMepper
    {
        public static Venda ToEntity(VendaInput input)
        {
            return new Venda
            {
                VendaId = Guid.NewGuid(),
                ClienteId = input.ClienteId,
                VeiculoId = input.VeiculoId,
                FormaDePagamentoId = input.FormaDePagamentoId,
                Status = input.Status,
                DataPrevistaEntrega = input.DataPrevistaEntrega,
                Preco = input.Preco,
                Descricao = input.Descricao,
                DataHora = input.DataHora
            };
        }

        public static VendaView ToDto(Venda entity)
        {
            return new VendaView
            {
                VendaId = entity.VendaId,
                ClienteId = entity.ClienteId,
                VeiculoId = entity.VeiculoId,
                FormaDePagamentoId = entity.FormaDePagamentoId,
                DataHora = entity.DataHora,
                Descricao = entity.Descricao,
                Preco = entity.Preco,
                Status = entity.Status,
                DataPrevistaEntrega = entity.DataPrevistaEntrega,
                NomeCliente = entity.Cliente?.Nome ?? "Cliente não encontrado",
                NomeFormaDePagamento = entity.FormaDePagamamento?.Descricao ?? "Forma de pagamento não encontrada",
                ModeloVeiculo = entity.Veiculo?.Modelo ?? "Veículo não encontrado"
            };
        }

        public static void Update(Venda entity, VendaInput input)
        {
            entity.ClienteId = input.ClienteId;
            entity.VeiculoId = input.VeiculoId;
            entity.FormaDePagamentoId = input.FormaDePagamentoId;
            entity.DataHora = input.DataHora;
            entity.Descricao = input.Descricao;
            entity.Preco = input.Preco;
            entity.Status = input.Status;
            entity.DataPrevistaEntrega = input.DataPrevistaEntrega;
        }
    }
}

