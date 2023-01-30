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

        public List<ObterItemPedidoDTO> ListarTodos()
        {
            var servicos = _context.ItensPedido.Select(x => new ObterItemPedidoDTO(x))
                                                .ToList();

            return servicos;
        }

        public List<ObterItemPedidoDTO> ObterPorPedidoId(int id)
        {
            var itensPedido = _context.ItensPedido.Where(x => x.PedidoId == id)
                                            .Select(x => new ObterItemPedidoDTO(x))
                                            .ToList();

            return itensPedido;
        }

        public ItemPedido AtualizarItemPedido(ItemPedido itemPedido)
        {
            _context.ItensPedido.Update(itemPedido);
            _context.SaveChanges();

            return itemPedido;
        }

        public void AtualizarPedidoId(ItemPedido itemPedido, AtualizarItemPedidoPedidoIdDTO dto)
        {
            itemPedido.PedidoId = dto.PedidoId;
            AtualizarItemPedido(itemPedido);
        }

        public void AtualizarServicoId(ItemPedido itemPedido, AtualizarItemPedidoServicoIdDTO dto)
        {
            itemPedido.ServicoId = dto.ServicoId;
            AtualizarItemPedido(itemPedido);
        }

        public void AtualizarQuantidade(ItemPedido itemPedido, AtualizarItemPedidoQuantidadeDTO dto)
        {
            itemPedido.Quantidade = dto.Quantidade;
            AtualizarItemPedido(itemPedido);
        }

        public void AtualizarValor(ItemPedido itemPedido, AtualizarItemPedidoValorDTO dto)
        {
            itemPedido.Valor = dto.Valor;
            AtualizarItemPedido(itemPedido);
        }

        public void DeletarItemPedido(ItemPedido itemPedido){
            _context.ItensPedido.Remove(itemPedido);
            _context.SaveChanges();
        }
    }
}