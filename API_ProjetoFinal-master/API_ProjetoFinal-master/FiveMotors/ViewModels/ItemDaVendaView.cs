using FiveMotors.Models;

namespace FiveMotors.ViewModels
{
    public class ItemDaVendaView
    {
       
            public Guid ItemDaVendaId { get; set; }
            public Guid VendaId { get; set; }
            public string ClienteNome { get; set; } 
            public string ModeloVeiculo { get; set; } 
            public int Quantidade { get; set; }
            public decimal PrecoUnitario { get; set; }
            public decimal Total { get; set; }
  

    }
}
