using ProjetoSancesWebAPI.Models;

namespace ProjetoSancesWebAPI.Service
{
    public interface ICalculoService
    {
         double CalcularValorTotal(PedidoProduto pedidoProduto);
    }
}