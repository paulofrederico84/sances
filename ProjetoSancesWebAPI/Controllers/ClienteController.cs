using ProjetoSancesWebAPI.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoSancesWebAPI.Data;

namespace ProjetoSancesWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IRepository _repository;
        
        public ClienteController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAction()
        {
            try
            {
                var result = await _repository.GetAllClientesAsync(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("clienteId={clienteId}")]
        public async Task<IActionResult> Get(int clienteId)
        {
            try
            {
                var result = await _repository.GetClienteAsyncById(clienteId, false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("cpf={cpf}")]
        public async Task<IActionResult> Get(string cpf)
        {
            try
            {
                var result = await _repository.GetClienteAsyncByCpf(cpf, false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente cliente)
        {
            try
            {
                _repository.Add(cliente);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(cliente);
                }
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("clienteId={clienteId}")]
        public async Task<IActionResult> Put(int clienteId, Cliente cliente)
        {
            try
            {
                var clienteCadastrado = await _repository.GetClienteAsyncById(clienteId, false);
                if (clienteCadastrado == null)
                {
                    return NotFound();
                }

                _repository.Update(cliente);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(cliente);
                }
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("clienteId={clienteId}")]
        public async Task<IActionResult> delete(int clienteId)
        {
            try
            {
                var cliente = await _repository.GetClienteAsyncById(clienteId, false);
                if (cliente == null)
                {
                    return NotFound();
                }

                _repository.Delete(cliente);

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