using ProjetoSancesWebAPI.Data;
using ProjetoSancesWebAPI.Models;
using ProjetoSancesWebAPI.Service.Interface;
using System;

namespace ProjetoSancesWebAPI.Service
{
    public class PedidoService : IPedidoService
    {
        private readonly IRepository _repository;
        private readonly ICalculoService _calculoService;

        public PedidoService(IRepository repository, ICalculoService calculoService) 
        {
            _repository = repository;
            _calculoService = calculoService;
        }

        public async void AtualizarValorTotal(PedidoProduto pedidoProduto)
        {
            var pedido = await _repository.GetPedidoAsyncById(pedidoProduto.PedidoId, false, false);

            pedido.ValorTotal = this._calculoService.CalcularValorTotal(pedidoProduto);

            pedido.Data = DateTime.Now;

            _repository.Update(pedido);
        }
    }
}