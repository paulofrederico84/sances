using System;
using System.Collections.Generic;

namespace ProjetoSancesWebAPI.Models
{
    public class Pedido
    {
        public Pedido() { }
        public Pedido(int id, DateTime data, int clienteId, double valorTotal, string situacao)
        {
            this.Id = id;
            this.Data = data;
            this.ClienteId = clienteId;
            this.ValorTotal = valorTotal;
            this.Situacao = situacao;

        }
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public double ValorTotal { get; set; }
        public string Situacao { get; set; }

        public IEnumerable<PedidoProduto> PedidoProduto { get; set; }
    }
}