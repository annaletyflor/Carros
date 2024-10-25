namespace Carros.models
{
    public class locacoes
    {
        public Guid id { get; set; }
        public DateTime dataLocacao { get; set; }
        public Guid? ClienteId { get; set; }
        public Guid? CarroId { get; set; }
    }
}
