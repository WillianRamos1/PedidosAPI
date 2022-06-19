using Microsoft.EntityFrameworkCore;
using PedidosAPI.Data;
using PedidosAPI.Models;
using PedidosAPI.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosAPI.Repositorios
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        public readonly DataContext _context;
        public PedidoRepositorio(DataContext context)
        {
            _context = context;
        }

        public async Task AlterarPedido(Pedido pedido)
        {
            _context.Entry(pedido).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Pedido> BuscarPedidoId(int id)
        {
            IQueryable<Pedido> query = _context.Pedidos.Include(e => e.PedidoItem);
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == id && e.Id == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Pedido>> BuscarPedidos()
        {
            IQueryable<Pedido> query = _context.Pedidos.Include(e => e.PedidoItem);
            return await query.ToListAsync();
        }

        public async Task<Pedido> CriarPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task DeletarPedido(int id)
        {
            var pedidoDeletar = await _context.Pedidos.FindAsync(id);
            _context.Pedidos.Remove(pedidoDeletar);
            await _context.SaveChangesAsync();
        }
    }
}
