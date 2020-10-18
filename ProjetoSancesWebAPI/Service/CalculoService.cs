using ProjetoSancesWebAPI.Models;

namespace ProjetoSancesWebAPI.Service
{
    public class CalculoService : ICalculoService
    {
        public double CalcularValorTotal(PedidoProduto pedidoProduto)
        {
            var valorUnitario = pedidoProduto.Produto.ValorUni;
            var quantidade = pedidoProduto.Quantidade;

            return (valorUnitario * quantidade) - pedidoProduto.Desconto;
        }
    }
}