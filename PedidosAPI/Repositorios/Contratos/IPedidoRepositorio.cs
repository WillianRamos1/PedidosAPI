using PedidosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosAPI.Repositorios.Contratos
{
    public interface IPedidoRepositorio
    {
        Task<IEnumerable<Pedido>> BuscarPedidos();

        Task<Pedido> BuscarPedidoId(int id);
        Task<Pedido> CriarPedido(Pedido pedido);
        Task AlterarPedido(Pedido pedido);
        Task DeletarPedido(int id);
    }
}
