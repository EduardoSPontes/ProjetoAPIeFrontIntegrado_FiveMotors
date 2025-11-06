using FiveMotors.InputModels;
using FiveMotors.Models;
using FiveMotors.ViewModels;

namespace FiveMotors.Mappers
{
    public class VeiculoMapper
    {
        public static Veiculo ToEntity(VeiculoInput input)
        {
            return new Veiculo
            {
                VeiculoId = Guid.NewGuid(),
                Marca = input.Marca,
                Modelo = input.Modelo,
                Ano = input.Ano,
                Descricao = input.Descricao,
                Preco = input.preco,
                ImagemsVeiculo = input.ImagemsVeiculo,
                Estoque = input.Estoque,
                
            };
        }

        public static VeiculoView ToDto(Veiculo entity)
        {
            return new VeiculoView
            {
                VeiculosId = entity.VeiculoId,
                Marca = entity.Marca,
                Modelo = entity.Modelo,
                Ano = entity.Ano,
                Descricao = entity.Descricao,
                Preco = entity.Preco,
                ImagemsVeiculo = entity.ImagemsVeiculo,
                Estoque = entity.Estoque,
            };
        }

        public static void Update(Veiculo entity, VeiculoInput input)
        {
            entity.Marca = input.Marca;
            entity.Modelo = input.Modelo;
            entity.Ano = input.Ano;
            entity.Descricao = input.Descricao;
            entity.ImagemsVeiculo = input.ImagemsVeiculo;
            entity.Preco = input.preco;
            entity.Estoque = input.Estoque;
 
        }
    }
}
