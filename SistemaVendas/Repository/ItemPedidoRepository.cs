using Microsoft.EntityFrameworkCore;
using SistemaVendas.Context;
using SistemaVendas.Dto;
using SistemaVendas.Models;

namespace SistemaVendas.Repository
{
    public class ItemPedidoRepository
    {
        private readonly VendasContext _context;

        public ItemPedidoRepository(VendasContext context)
        {
            _context = context;
        }

        public ItemPedido Cadastrar(ItemPedido itemPedido)
        {
            _context.ItensPedido.Add(itemPedido);
            _context.SaveChanges();

            return itemPedido;
        }

        public ItemPedido ObterPorId(int id)
        {
            var itemPedido = _context.ItensPedido.Include(x => x.Pedido)
                                         .Include(x => x.Servico)
                                         .FirstOrDefault(x => x.Id == id);
            return itemPedido;
        }

        public ItemPedido AtualizarPedido(ItemPedido itemPedido)
        {
            _context.ItensPedido.Update(itemPedido);
            _context.SaveChanges();

            return itemPedido;
        }
    }
}