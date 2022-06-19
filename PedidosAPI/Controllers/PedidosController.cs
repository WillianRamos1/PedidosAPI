using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidosAPI.Models;
using PedidosAPI.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PedidosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public PedidosController(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        [HttpGet]
        public async Task<IEnumerable<Pedido>> GetPedidos()
        {
            try
            {
                return await _pedidoRepositorio.BuscarPedidos();
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao tentar recuperar Pedidos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedidosById(int id)
        {
            try
            {
                var pedidos = await _pedidoRepositorio.BuscarPedidoId(id);
                if (pedidos == null) return NotFound();
                return Ok(pedidos);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Pedidos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pedido pedido)
        {
            try
            {

                var novoPedido = await _pedidoRepositorio.CriarPedido(pedido);
                if (novoPedido == null) return NoContent();

                return Ok(novoPedido);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar incluir Pedido. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pedidoDeletar = await _pedidoRepositorio.BuscarPedidoId(id);
                if (pedidoDeletar == null) return NotFound();

                await _pedidoRepositorio.DeletarPedido(pedidoDeletar.Id);
                return Ok(new { message = "Pedido Deletado" });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar Pedido. Erro: {ex.Message}");
            }         
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Pedido pedido)
        {
            try
            {
                await _pedidoRepositorio.AlterarPedido(pedido);
                if (id != pedido.Id) return NotFound();
                
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar Pedidos. Erro: {ex.Message}");
            }
        }
    }
}
