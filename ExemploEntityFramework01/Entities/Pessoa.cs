namespace ExemploEntityFramework01.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}