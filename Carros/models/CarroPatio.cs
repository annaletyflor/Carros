namespace Carros.models
{
    public class CarroPatio
    {
        public Guid CPId { get; set; }

        public Guid? PatioId { get; set; }
        public Guid? CarroId { get; set; }
        public Guid? ClienteId { get; set; }
    }
}
