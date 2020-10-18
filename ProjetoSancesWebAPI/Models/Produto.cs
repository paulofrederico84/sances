using System.Collections.Generic;

namespace ProjetoSancesWebAPI.Models
{
    public class Produto
    {
        public Produto() {}
        public Produto(int id, string descricao, double valorUni)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.ValorUni = valorUni;
            

        }
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double ValorUni { get; set; }

        public IEnumerable<PedidoProduto> PedidoProduto { get; set; }
    }
}