using Domain.Entities.Base;

namespace Domain
{
    public class Client : EntityBase
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public bool Especial { get; set; }
        public decimal LimiteCredito { get; set; }
    }
}
