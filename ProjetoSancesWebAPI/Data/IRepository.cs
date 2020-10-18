using System;
using System.Threading.Tasks;
using ProjetoSancesWebAPI.Models;

namespace ProjetoSancesWebAPI.Data
{
    public interface IRepository
    {
        //Geral
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Produto
        Task<Produto[]> GetAllProdutoAsync(bool includePedido);
        Task<Produto> GetProdutoAsyncById(int produtoId , bool includePedido);
        Task<Produto> GetProdutoAsyncByDescricao(string descricao);

        //Pedido
        Task<Pedido[]> GetAllPedidosAsync(bool includeProduto, bool includeCliente);
        Task<Pedido> GetPedidoAsyncById(int pedidoId , bool includeProduto, bool includeCliente);
        Task<Pedido> GetPedidoAsyncByData(DateTime data , bool includeProduto, bool includeCliente);
        Task<Pedido> GetPedidoAsyncBySituacao(string situacao , bool includeProduto, bool includeCliente);

        //Cliente
        Task<Cliente[]> GetAllClientesAsync(bool includePedido);
        Task<Cliente> GetClienteAsyncById(int clienteId , bool includePedido);
        Task<Cliente> GetClienteAsyncByCpf(string cpf , bool includePedido);

        //PedidoProduto
        Task<PedidoProduto[]> GetAllPedidoProdutosAsync();
        Task<PedidoProduto> GetPedidoProdutoAsyncById(int pedidoProdutoId);
    }
}