using SistemaVendas.Models;

namespace SistemaVendas.Dto
{
    public class ObterPedidoDTO
    {
        public DateTime Data { get; set; }
        public int VendedorId { get; set; }
        public int ClienteId { get; set; }

        public ObterPedidoDTO(Pedido pedido)
        {
            Data = pedido.Data;
            VendedorId = pedido.VendedorId;
            ClienteId = pedido.ClienteId;
        }
    }
}