using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Context;
using SistemaVendas.Dto;
using SistemaVendas.Models;

namespace SistemaVendas.Repository
{
    public class VendedorRepository
    {
        private readonly VendasContext _context;

        public VendedorRepository(VendasContext context)
        {
            _context = context;
        }

        public void Cadastrar(Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();
        }
        
        public Vendedor ObterPorId(int id)
        {
            var vendedor = _context.Vendedores.Find(id);
            return vendedor;
        }

        public List<ObterVendedorDTO> ObterPorNome(string nome)
        {
            var vendedores = _context.Vendedores.Where(x => x.Nome.Contains(nome))
                                                .Select(x => new ObterVendedorDTO(x))
                                                .ToList();

            return vendedores;
        }

        public List<ObterVendedorDTO> ObterPorLogin(string nome)
        {
            var vendedores = _context.Vendedores.Where(x => x.Login.Contains(nome))
                                                .Select(x => new ObterVendedorDTO(x))
                                                .ToList();

            return vendedores;
        }

        public List<ObterVendedorDTO> ListarTodos()
        {
            var vendedores = _context.Vendedores.Select(x => new ObterVendedorDTO(x))
                                                .ToList();

            return vendedores;
        }

        public Vendedor AtualizarVendedor(Vendedor vendedor)
        {
            _context.Vendedores.Update(vendedor);
            _context.SaveChanges();

            return vendedor;
        }

        public void AtualizarSenha(Vendedor vendedor, AtualizarSenhaVendedorDTO dto)
        {
            vendedor.Senha = dto.Senha;
            AtualizarVendedor(vendedor);
        }

        public void AtualizarNome(Vendedor vendedor, AtualizarNomeVendedorDTO dto)
        {
            vendedor.Nome = dto.Nome;
            AtualizarVendedor(vendedor);
        }
        
        public void DeletarVendedor(Vendedor vendedor)
        {
            _context.Vendedores.Remove(vendedor);
            _context.SaveChanges();
        }

    }
}