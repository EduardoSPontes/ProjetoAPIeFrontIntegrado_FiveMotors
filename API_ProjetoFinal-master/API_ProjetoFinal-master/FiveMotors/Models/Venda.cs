using System;
using System.Collections.Generic;

namespace FiveMotors.Models
{
    public class Venda
    {
      public Guid VendaId { get; set; }

        
      public Guid ClienteId { get; set; }
      public Cliente? Cliente { get; set; }

        
        public Guid VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }

      
        public Guid FormaDePagamentoId { get; set; }
        public FormaDePagamento? FormaDePagamamento { get; set; }

        public string Status { get; set; } 
        public DateTime DataPrevistaEntrega { get; set; } 

        public decimal Preco { get; set; }
        public string Descricao { get; set; }

        public DateTime DataHora { get; set; }
        public IEnumerable<ItemDaVenda> ItemDaVenda { get; set; }
    }
}
