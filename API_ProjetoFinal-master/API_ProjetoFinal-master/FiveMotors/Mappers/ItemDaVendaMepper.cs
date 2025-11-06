using FiveMotors.InputModels;
using FiveMotors.Models;
using FiveMotors.ViewModels;

namespace FiveMotors.Mappers
{
    public class ItemDaVendaMepper
    {
        public static ItemDaVenda ToEntity(ItemDaVendaInput input)
        {
            return new ItemDaVenda
            {
                ItemDaVendaId = Guid.NewGuid(),
                VendaId = input.VendaId,
                VeiculoId = input.VeiculoId,
                Quantidade = input.Quantidade,
                PrecoUnitario = input.PrecoUnitario,
                Total = input.Quantidade * input.PrecoUnitario
            };
        }

        public static ItemDaVendaView ToDto(ItemDaVenda entity)
        {
            return new ItemDaVendaView
            {
                ItemDaVendaId = entity.ItemDaVendaId,
                VendaId = entity.VendaId,
                ClienteNome = entity.Venda?.Cliente?.Nome ?? "Cliente não encontrado",
                ModeloVeiculo = entity.Veiculo?.Modelo ?? "Veículo não encontrado",
                Quantidade = entity.Quantidade,
                PrecoUnitario = entity.PrecoUnitario,
                Total = entity.Total
            };
        }

        public static void Update(ItemDaVenda entity, ItemDaVendaInput input)
        {
            entity.VeiculoId = input.VeiculoId;
            entity.Quantidade = input.Quantidade;
            entity.PrecoUnitario = input.PrecoUnitario;
            entity.Total = input.Quantidade * input.PrecoUnitario;
        }
    }
}

