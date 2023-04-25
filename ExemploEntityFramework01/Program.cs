using ExemploEntityFramework01.DB;
using ExemploEntityFramework01.Entities;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        using (var contexto = new ContextoDB())
        {

            // criação do banco de dados (se ainda não existir)
            contexto.Database.EnsureCreated();

            // criação de uma pessoa e seu endereço
            var pessoa = new Pessoa
            {
                Nome = "João",
                Endereco = new Endereco
                {
                    Logradouro = "Rua 1",
                    Bairro = "Centro",
                    Cidade = "São Paulo"
                }
            };

            contexto.Pessoas.Add(pessoa);
            contexto.SaveChanges();

            // exibição dos dados
            var pessoas = contexto.Pessoas
                .Include(p => p.Endereco)
                .ToList();

            foreach (var p in pessoas)
            {
                Console.WriteLine($"Id: {p.Id}, Nome: {p.Nome}");
                Console.WriteLine($"Endereço: {p.Endereco.Logradouro}, {p.Endereco.Bairro}, {p.Endereco.Cidade}");
            }
        }
    }
}
