using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Dto;
using SistemaVendas.Models;
using SistemaVendas.Repository;

namespace SistemaVendas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicoController : ControllerBase
    {
        private readonly ServicoRepository _repository;

        public ServicoController(ServicoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarServicoDTO dto)
        {
            var servico = new Servico(dto);
            _repository.Cadastrar(servico);
            return Ok(servico);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var servico = _repository.ObterPorId(id);
            
            if(servico is not null)
            {
                var servicoDTO = new ObterServicoDTO(servico);
                return Ok(servicoDTO);
            }
            else
                return NotFound(new { Mensagem = "Servico não encontrado"});
        }

        [HttpGet("obterpordescricao/{text}")]
        public IActionResult ObterPorDescricao(string text)
        {
            var servicos = _repository.ObterPorDescricao(text);
            return Ok(servicos);
        }

        [HttpGet("listar")]
        public IActionResult ListarTodos()
        {
            var pedidos = _repository.ListarTodos();
            return Ok(pedidos);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarServicoDTO dto)
        {
            var servico = _repository.ObterPorId(id);

            if(servico is not null)
            {
                servico.MapearAtualizarServicoDTO(dto);
                _repository.AtualizarServico(servico);

                return Ok(servico);
            }
            else
                return NotFound(new { Mensagem = "Servico não encontrado"});
        }

        [HttpPatch("atualizarnome/{id}")]
        public IActionResult AtualizarNome(int id, AtualizarNomeServicoDTO dto)
        {
            var servico = _repository.ObterPorId(id);

            if(servico is not null)
            {
                _repository.AtualizarNome(servico, dto);
                return Ok(servico);
            }
            else
                return NotFound(new { Mensagem = "Servico não encontrado"});
        }

        [HttpPatch("atualizardescricao/{id}")]
        public IActionResult AtualizarDescricao(int id, AtualizarDescricaoServicoDTO dto)
        {
            var servico = _repository.ObterPorId(id);

            if(servico is not null)
            {
                _repository.AtualizarDescricao(servico, dto);
                return Ok(servico);
            }
            else
                return NotFound(new { Mensagem = "Servico não encontrado"});
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var servico = _repository.ObterPorId(id);

            if(servico is not null)
            {
                _repository.DeletarServico(servico);
                return NoContent();
            }
            else
                return NotFound(new { Mensagem = "Servico não encontrado"});
        }
    }
}