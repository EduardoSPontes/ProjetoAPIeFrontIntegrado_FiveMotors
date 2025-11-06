namespace FiveMotors.InputModels
{
    public class ClienteInput
    {
       public string Nome {  get; set; }  
       public string CpfCnpj {  get; set; }   
       public  string TipoPessoa { get; set; }
       public string Telefone { get; set; }   
       public string Email { get; set; }
       public string Endereco { get; set; }
        public string? UserId { get; set; }
        public DateOnly DataNascimento { get; set; }

    }
}
