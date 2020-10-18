using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoSancesWebAPI.Data;
using ProjetoSancesWebAPI.Models;
using ProjetoSancesWebAPI.Service;

namespace ProjetoSancesWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ICalculoService _calculoService;
        
        public PedidoController(IRepository repository, ICalculoService calculoService)
        {
            _repository = repository;
            _calculoService = calculoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAction()
        {
            try
            {
                var result = await _repository.GetAllPedidosAsync(false, false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("pedidoId={pedidoId}")]
        public async Task<IActionResult> Get(int pedidoId)
        {
            try
            {
                var result = await _repository.GetPedidoAsyncById(pedidoId, false, false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("data={data}")]
        public async Task<IActionResult> Get(DateTime data)
        {
            try
            {
                var result = await _repository.GetPedidoAsyncByData(data, false, false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("situacao={situacao}")]
        public async Task<IActionResult> Get(string situacao)
        {
            try
            {
                var result = await _repository.GetPedidoAsyncBySituacao(situacao, false, false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pedido pedido)
        {
            try
            {
                _repository.Add(pedido);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(pedido);
                }
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("pedidoId={pedidoId}")]
        public async Task<IActionResult> Put(int pedidoId, Pedido pedido)
        {
            try
            {
                var pedidoCadastrado = await _repository.GetPedidoAsyncById(pedidoId, false, false);
                if (pedidoCadastrado == null)
                {
                    return NotFound();
                }

                _repository.Update(pedido);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(pedido);
                }
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("pedidoId={pedidoId}")]
        public async Task<IActionResult> delete(int pedidoId)
        {
            try
            {
                var pedido = await _repository.GetPedidoAsyncById(pedidoId, false, false);
                if (pedido == null)
                {
                    return NotFound();
                }

                _repository.Delete(pedido);

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