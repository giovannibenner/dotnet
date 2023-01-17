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
    }
}