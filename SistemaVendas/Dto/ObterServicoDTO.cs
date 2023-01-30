using SistemaVendas.Models;

namespace SistemaVendas.Dto
{
    public class ObterServicoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ObterServicoDTO(Servico servico)
        {
            Id = servico.Id;
            Nome = servico.Nome;
            Descricao = servico.Descricao;
        }
    }
}