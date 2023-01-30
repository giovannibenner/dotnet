using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Dto;
using SistemaVendas.Models;
using SistemaVendas.Repository;

namespace SistemaVendas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemPedidoController : ControllerBase
    {
        private readonly ItemPedidoRepository _repository;

        public ItemPedidoController(ItemPedidoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarItemPedidoDTO dto)
        {
            var itemPedido = new ItemPedido(dto);
            _repository.Cadastrar(itemPedido);
            return Ok(itemPedido);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var itemPedido = _repository.ObterPorId(id);

            if(itemPedido is not null)
                return Ok(itemPedido);
            else
                return NotFound(new { Mensagem = "ItemPedido não encontrado"});
        }

        [HttpGet("listar")]
        public IActionResult ListarTodos()
        {
            var itensPedido = _repository.ListarTodos();
            return Ok(itensPedido);
        }

        [HttpGet("obterpedidoid/{id}")]
        public IActionResult ObterPorVendedorId(int id)
        {
            var itensPedido = _repository.ObterPorPedidoId(id);
            if(itensPedido is not null)
                return Ok(itensPedido);
            else
                return NotFound(new { Mensagem = "ItensPedido não encontrado"});
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarItemPedidoDTO dto)
        {
            var itemPedido = _repository.ObterPorId(id);

            if(itemPedido is not null)
            {
                itemPedido.MapearAtualizarItemPedidoDTO(dto);
                _repository.AtualizarItemPedido(itemPedido);

                return Ok(itemPedido);
            }
            else
                return NotFound(new { Mensagem = "ItemPedido não encontrado"});
        }

        [HttpPatch("atualizarpedido/{id}")]
        public IActionResult AtualizarPedidoId(int id, AtualizarItemPedidoPedidoIdDTO dto)
        {
            var itemPedido = _repository.ObterPorId(id);

            if(itemPedido is not null)
            {
                _repository.AtualizarPedidoId(itemPedido, dto);
                return Ok(itemPedido);
            }
            else
                return NotFound(new { Mensagem = "ItemPedido não encontrado"});
        }

        [HttpPatch("atualizarservico/{id}")]
        public IActionResult AtualizarServicoId(int id, AtualizarItemPedidoServicoIdDTO dto)
        {
            var itemPedido = _repository.ObterPorId(id);

            if(itemPedido is not null)
            {
                _repository.AtualizarServicoId(itemPedido, dto);
                return Ok(itemPedido);
            }
            else
                return NotFound(new { Mensagem = "ItemPedido não encontrado"});
        }

        [HttpPatch("atualizarquantidade/{id}")]
        public IActionResult AtualizarQuantidade(int id, AtualizarItemPedidoQuantidadeDTO dto)
        {
            var itemPedido = _repository.ObterPorId(id);

            if(itemPedido is not null)
            {
                _repository.AtualizarQuantidade(itemPedido, dto);
                return Ok(itemPedido);
            }
            else
                return NotFound(new { Mensagem = "ItemPedido não encontrado"});
        }

        [HttpPatch("atualizarvalor/{id}")]
        public IActionResult AtualizarValor(int id, AtualizarItemPedidoValorDTO dto)
        {
            var itemPedido = _repository.ObterPorId(id);

            if(itemPedido is not null)
            {
                _repository.AtualizarValor(itemPedido, dto);
                return Ok(itemPedido);
            }
            else
                return NotFound(new { Mensagem = "ItemPedido não encontrado"});
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var itemPedido = _repository.ObterPorId(id);

            if(itemPedido is not null)
            {
                _repository.DeletarItemPedido(itemPedido);
                return NoContent();
            }
            else
                return NotFound(new { Mensagem = "ItemPedido não encontrado"});
        }
    }
}