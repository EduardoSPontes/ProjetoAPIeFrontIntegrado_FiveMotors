using FiveMotors.InputModels;
using FiveMotors.Models;
using FiveMotors.ViewModels;

namespace FiveMotors.Mappers
{
    public static class ClienteMapper
    {
        public static Cliente ToEntity(ClienteInput input)
        {
            return new Cliente
            {
                ClienteId = Guid.NewGuid(),
                Nome = input.Nome,
                CpfCnpj = input.CpfCnpj,
                DataNascimento = input.DataNascimento,
                Email = input.Email,
                TipoPessoa = input.TipoPessoa,
                Telefone = input.Telefone,
                Endereco = input.Endereco,
                UserId = input.UserId
            };
        }

        public static ClienteView ToDto(Cliente entity)
        {
            return new ClienteView
            {
                ClienteId = entity.ClienteId,
                Nome = entity.Nome,
                Email = entity.Email,
                Telefone = entity.Telefone,
                Endereco = entity.Endereco,
                TipoPessoa = entity.TipoPessoa,
                CpfCnpj = entity.CpfCnpj,
                UserId = entity.UserId
                
            };
        }

        public static void Update(Cliente entity, ClienteInput input)
        {
            entity.Nome = input.Nome;
            entity.Email = input.Email;
            entity.Telefone = input.Telefone;
            entity.CpfCnpj = input.CpfCnpj;
            entity.TipoPessoa = input.TipoPessoa;
            entity.Endereco = input.Endereco;
            entity.DataNascimento = input.DataNascimento;
            entity.UserId = input.UserId;
        }

    }
}
