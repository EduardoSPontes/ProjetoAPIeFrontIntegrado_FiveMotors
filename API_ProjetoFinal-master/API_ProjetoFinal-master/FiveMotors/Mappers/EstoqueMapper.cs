using FiveMotors.Models;
using FiveMotors.ViewModels;

namespace FiveMotors.Mappers
{
    public class EstoqueMapper
    {
        public static EstoquePedido ToEntity(Veiculo veiculo, int quantidadeVendida, EstoquePedido estoque)
        {
            return new EstoquePedido
            {
                EstoquePedidoId = estoque.EstoquePedidoId,
                VeiculoId = veiculo.VeiculoId, // Mantendo relacionamento
                Modelo = veiculo.Modelo,
                Ano = veiculo.Ano,
                QuantidadeDisponivel = veiculo.Estoque - quantidadeVendida,
                StatusPedido = (veiculo.Estoque - quantidadeVendida) > 0 ? "Em estoque" : "Esgotado"
            };
        }

    }
}
