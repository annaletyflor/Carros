namespace Carros.models
{
    public class Cliente
    {
        public Guid ClienteId { get; set; }
        public string ClienteName { get; set; }
        public string CPF {  get; set; }
        public int telefone { get; set; }
        public string email { get; set; }
    }
}
