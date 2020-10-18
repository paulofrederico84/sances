using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoSancesWebAPI.Models;

namespace ProjetoSancesWebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            this._context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Produto[]> GetAllProdutoAsync(bool includePedido)
        {
            IQueryable<Produto> query = _context.Produto;

            if (includePedido)
            {
                query = query.Include(pr => pr.PedidoProduto)
                             .ThenInclude(pp => pp.Pedido);
            }

            query = query.AsNoTracking().OrderBy(pr => pr.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Produto> GetProdutoAsyncById(int produtoId , bool includePedido)
        {
            IQueryable<Produto> query = _context.Produto;

            if (includePedido)
            {
                query = query.Include(pr => pr.PedidoProduto)
                             .ThenInclude(pp => pp.Pedido);
            }

            query = query.AsNoTracking().OrderBy(pr => pr.Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Produto> GetProdutoAsyncByDescricao(string descricao)
        {
            IQueryable<Produto> query = _context.Produto;

            query = query.AsNoTracking().OrderBy(pr => pr.Descricao);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pedido[]> GetAllPedidosAsync(bool includeProduto, bool includeCliente)
        {
            IQueryable<Pedido> query = _context.Pedido;

            if (includeProduto)
            {
                query = query.Include(p => p.PedidoProduto)
                             .ThenInclude(pp => pp.Produto);
            }

            if (includeCliente)
            {
                query = query.Include(p => p.Cliente);                                
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Pedido> GetPedidoAsyncById(int pedidoId , bool includeProduto, bool includeCliente)
        {
            IQueryable<Pedido> query = _context.Pedido;

            if (includeProduto)
            {
                query = query.Include(p => p.PedidoProduto)
                             .ThenInclude(pp => pp.Produto);
            }

            if (includeCliente)
            {
                query = query.Include(p => p.Cliente);                                
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pedido> GetPedidoAsyncByData(DateTime data , bool includeProduto, bool includeCliente)
        {
            IQueryable<Pedido> query = _context.Pedido;

            if (includeProduto)
            {
                query = query.Include(p => p.PedidoProduto)
                             .ThenInclude(pp => pp.Produto);
            }

            if (includeCliente)
            {
                query = query.Include(p => p.Cliente);                                
            }

            query = query.AsNoTracking().OrderBy(p => p.Data);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pedido> GetPedidoAsyncBySituacao(string situacao , bool includeProduto, bool includeCliente)
        {
            IQueryable<Pedido> query = _context.Pedido;

            if (includeProduto)
            {
                query = query.Include(p => p.PedidoProduto)
                             .ThenInclude(pp => pp.Produto);
            }

            if (includeCliente)
            {
                query = query.Include(p => p.Cliente);                                
            }

            query = query.AsNoTracking().OrderBy(p => p.Situacao);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Cliente[]> GetAllClientesAsync(bool includePedido)
        {
            IQueryable<Cliente> query = _context.Cliente;

            if (includePedido)
            {
                query = query.Include(c => c.Pedido);
            }

            query = query.AsNoTracking().OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Cliente> GetClienteAsyncById(int clienteId , bool includePedido)
        {
            IQueryable<Cliente> query = _context.Cliente;

            if (includePedido)
            {
                query = query.Include(c => c.Pedido);
            }

            query = query.AsNoTracking().OrderBy(c => c.Id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Cliente> GetClienteAsyncByCpf(string cpf , bool includePedido)
        {
            IQueryable<Cliente> query = _context.Cliente;

            if (includePedido)
            {
                query = query.Include(c => c.Pedido);
            }

            query = query.AsNoTracking().OrderBy(c => c.Cpf);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<PedidoProduto[]> GetAllPedidoProdutosAsync()
        {
            IQueryable<PedidoProduto> query = _context.PedidoProduto;

            query = query.AsNoTracking().OrderBy(pp => pp.Id);

            return await query.ToArrayAsync();
        }

        public async Task<PedidoProduto> GetPedidoProdutoAsyncById(int pedidoProdutoId)
        {
            IQueryable<PedidoProduto> query = _context.PedidoProduto;

            query = query.AsNoTracking().OrderBy(pp => pp.Id);
            return await query.FirstOrDefaultAsync();
        }
    }
}