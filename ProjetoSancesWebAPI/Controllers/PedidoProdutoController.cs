using System.Globalization;
using System.Runtime.CompilerServices;
using System.Reflection.PortableExecutable;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoSancesWebAPI.Data;
using ProjetoSancesWebAPI.Models;
using ProjetoSancesWebAPI.Service.Interface;
using ProjetoSancesWebAPI.Service;

namespace ProjetoSancesWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoProdutoController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IPedidoService _pedidoService;
        
        public PedidoProdutoController(IRepository repository, ICalculoService calculoService, IPedidoService pedidoService)
        {
            _repository = repository;
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAction()
        {
            try
            {
                var result = await _repository.GetAllPedidoProdutosAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("pedidoProdutoId={pedidoProdutoId}")]
        public async Task<IActionResult> Get(int pedidoProdutoId)
        {
            try
            {
                var result = await _repository.GetPedidoProdutoAsyncById(pedidoProdutoId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PedidoProduto pedidoProduto)
        {
            try
            {
                _repository.Add(pedidoProduto);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(pedidoProduto);
                }
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("pedidoProdutoId={pedidoProdutoId}")]
        public async Task<IActionResult> Put(int pedidoProdutoId, PedidoProduto pedidoProduto)
        {
            try
            {
                var pedidoProdutoCadastrado = await _repository.GetPedidoProdutoAsyncById(pedidoProdutoId);
                if (pedidoProdutoCadastrado == null)
                {
                    return NotFound();
                }

                this._pedidoService.AtualizarValorTotal(pedidoProduto);

                _repository.Update(pedidoProduto);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(pedidoProduto);
                }
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("pedidoProdutoId={pedidoProdutoId}")]
        public async Task<IActionResult> delete(int pedidoProdutoId)
        {
            try
            {
                var pedidoProduto = await _repository.GetPedidoProdutoAsyncById(pedidoProdutoId);
                if (pedidoProduto == null)
                {
                    return NotFound();
                }

                _repository.Delete(pedidoProduto);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok("Deletado");
                }
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();    
        }
    }
}