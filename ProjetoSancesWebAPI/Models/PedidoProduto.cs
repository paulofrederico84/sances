namespace ProjetoSancesWebAPI.Models
{
    public class PedidoProduto
    {
        public PedidoProduto(int id, int pedidoId, int produtoId, int quantidade, double desconto)
        {
            this.Id = id;
            this.PedidoId = pedidoId;
            this.ProdutoId = produtoId;
            this.Quantidade = quantidade;
            this.Desconto = desconto;
        }
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public double Desconto { get; set; }
    }
}