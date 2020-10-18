using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoSancesWebAPI.Data;
using ProjetoSancesWebAPI.Models;

namespace ProjetoSancesWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IRepository _repository;
        
        public ProdutoController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAction()
        {
            try
            {
                var result = await _repository.GetAllProdutoAsync(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("produtoId={produtoId}")]
        public async Task<IActionResult> Get(int produtoId)
        {
            try
            {
                var result = await _repository.GetProdutoAsyncById(produtoId, false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("descricao={descricao}")]
        public async Task<IActionResult> Get(string descricao)
        {
            try
            {
                var result = await _repository.GetProdutoAsyncByDescricao(descricao);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Produto produto)
        {
            try
            {
                _repository.Add(produto);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(produto);
                }
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("produtoId={produtoId}")]
        public async Task<IActionResult> Put(int produtoId, Produto produto)
        {
            try
            {
                var pedidoCadastrado = await _repository.GetProdutoAsyncById(produtoId, false);
                if (pedidoCadastrado == null)
                {
                    return NotFound();
                }

                _repository.Update(produto);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(produto);
                }
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("produtoId={produtoId}")]
        public async Task<IActionResult> delete(int produtoId)
        {
            try
            {
                var produto = await _repository.GetProdutoAsyncById(produtoId, false);
                if (produto == null)
                {
                    return NotFound();
                }

                _repository.Delete(produto);

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