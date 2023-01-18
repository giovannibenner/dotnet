using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Context;
using SistemaVendas.Dto;
using SistemaVendas.Models;

namespace SistemaVendas.Repository
{
    public class ServicoRepository
    {
        private readonly VendasContext _context;

        public ServicoRepository(VendasContext context)
        {
            _context = context;
        }

        public void Cadastrar(Servico servico)
        {
            _context.Servicos.Add(servico);
            _context.SaveChanges();
        }

        public Servico ObterPorId(int id)
        {
            var servico = _context.Servicos.Find(id);
            return servico;
        }

        public List<ObterServicoDTO> ObterPorDescricao(string text)
        {
            var clientes = _context.Servicos.Where(x => x.Descricao.Contains(text))
                                                .Select(x => new ObterServicoDTO(x))
                                                .ToList();

            return clientes;
        }

        public List<ObterServicoDTO> ListarTodos()
        {
            var servicos = _context.Servicos.Select(x => new ObterServicoDTO(x))
                                                .ToList();

            return servicos;
        }

        public Servico AtualizarServico(Servico servico)
        {
            _context.Servicos.Update(servico);
            _context.SaveChanges();

            return servico;
        }

        public void AtualizarNome(Servico servico, AtualizarNomeServicoDTO dto)
        {
            servico.Nome = dto.Nome;
            AtualizarServico(servico);
        }

        public void AtualizarDescricao(Servico servico, AtualizarDescricaoServicoDTO dto)
        {
            servico.Descricao = dto.Descricao;
            AtualizarServico(servico);
        }

        public void DeletarServico(Servico servico)
        {
            _context.Servicos.Remove(servico);
            _context.SaveChanges();
        }
    }
}