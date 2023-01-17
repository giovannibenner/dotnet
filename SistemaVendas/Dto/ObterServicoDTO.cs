using SistemaVendas.Models;

namespace SistemaVendas.Dto
{
    public class ObterServicoDTO
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ObterServicoDTO(Servico servico)
        {
            Nome = servico.Nome;
            Descricao = servico.Descricao;
        }
    }
}