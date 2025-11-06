using FiveMotors.InputModels;
using FiveMotors.Models;
using FiveMotors.ViewModels;

namespace FiveMotors.Mappers
{
    public class FaleComVendedorMapper
    {
        public static FaleComVendedor ToEntity(FaleComVendedorInput input)
        {
            return new FaleComVendedor
            {
                FaleComVendedorId = Guid.NewGuid(),
                Nome = input.Nome,
                Email = input.Email,
                Telefone = input.Telefone,
                Assunto = input.Assunto
            };
        }

        public static FaleComVendedorView ToDto(FaleComVendedor entity)
        {
            return new FaleComVendedorView
            {
                FaleComVendedorId = entity.FaleComVendedorId,
                Nome = entity.Nome,
                Email = entity.Email,
                Telefone = entity.Telefone,
                Assunto = entity.Assunto
            };
        }

        public static void Update(FaleComVendedor entity, FaleComVendedorInput input)
        {
            entity.Nome = input.Nome;
            entity.Email = input.Email;
            entity.Telefone = input.Telefone;
            entity.Assunto = input.Assunto;
        }
    }
}

