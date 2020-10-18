using ProjetoSancesWebAPI.Models;
using ProjetoSancesWebAPI.Data;

namespace ProjetoSancesWebAPI.Service.Interface
{
    public interface IPedidoService
    {
        void AtualizarValorTotal(PedidoProduto pedidoProduto);
    }
}
