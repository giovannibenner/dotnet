namespace SistemaVendas.Dto
{
    public class CadastrarItemPedidoDTO
    {
        public int PedidoId { get; set; }
        public int ServicoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}