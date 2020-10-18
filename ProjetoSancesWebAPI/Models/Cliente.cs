using System.Collections.Generic;

namespace ProjetoSancesWebAPI.Models
{
    public class Cliente
    {
        public Cliente(int id, string nome, string cpf, int telefone)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Telefone = telefone;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Telefone { get; set; }
        public IEnumerable<Pedido> Pedido { get; set; }
    }
}