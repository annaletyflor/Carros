namespace Carros.models
{
    public class Carro
    {
       public Guid CarroId { get; set; }
        public string Modelo { get; set; }
        public int Placa { get; set; }
        public Guid? PatioId { get; set; }

    }
}
