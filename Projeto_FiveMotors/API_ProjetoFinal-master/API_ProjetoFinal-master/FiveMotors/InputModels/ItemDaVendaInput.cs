namespace FiveMotors.InputModels
{
    public class ItemDaVendaInput
    {
        public Guid VendaId { get; set; }
        public Guid VeiculoId { get; set; }

        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

    }
}
