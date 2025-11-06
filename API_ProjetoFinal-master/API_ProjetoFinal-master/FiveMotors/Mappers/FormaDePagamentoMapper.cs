using FiveMotors.InputModels;
using FiveMotors.Models;
using FiveMotors.ViewModels;

namespace FiveMotors.Mappers
{
    public class FormaDePagamentoMapper
    {
        public static FormaDePagamento ToEntity(FormaDePagamentoInput input)
        {
            return new FormaDePagamento
            {
                FormaDePagamentoId = Guid.NewGuid(),
                Descricao = input.Descricao,
                ParcelasMax = input.ParcelasMax,
                JurosMensal = input.JurosMensal,
                DescontoAVista = input.DescontoAVista
            };
        }

        public static FormaDePagamentoView ToDto(FormaDePagamento entity)
        {
            return new FormaDePagamentoView
            {
                FormaDePagamentoId = entity.FormaDePagamentoId,
                Descricao = entity.Descricao,
                ParcelasMax = entity.ParcelasMax,
                JurosMensal = entity.JurosMensal,
                DescontoAVista = entity.DescontoAVista
            };
        }

        public static void Update(FormaDePagamento entity, FormaDePagamentoInput input)
        {
            entity.Descricao = input.Descricao;
            entity.ParcelasMax = input.ParcelasMax;
            entity.JurosMensal = input.JurosMensal;
            entity.DescontoAVista = input.DescontoAVista;
        }
    }
}
