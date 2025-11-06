namespace FiveMotors.InputModels
{
    public class VeiculoInput
    {
      public string Marca {  get; set; }
      public string Modelo { get; set; }
      public int Ano {  get; set; }
      public decimal preco { get; set; }
      public string Descricao { get; set; }

       public List<string> ImagemsVeiculo { get; set; }
        public int Estoque { get; set; }
    }
}
