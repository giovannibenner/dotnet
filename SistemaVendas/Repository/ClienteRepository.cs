using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Context;
using SistemaVendas.Dto;
using SistemaVendas.Models;

namespace SistemaVendas.Repository
{
    public class ClienteRepository
    {
        private readonly VendasContext _context;

        public ClienteRepository(VendasContext context)
        {
            _context = context;
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public Cliente ObterPorId(int id)
        {
            var cliente = _context.Clientes.Find(id);
            return cliente;
        }

        public List<ObterClienteDTO> ObterPorNome(string nome)
        {
            var clientes = _context.Clientes.Where(x => x.Nome.Contains(nome))
                                                .Select(x => new ObterClienteDTO(x))
                                                .ToList();

            return clientes;
        }

        public List<ObterClienteDTO> ObterPorLogin(string nome)
        {
            var clientes = _context.Clientes.Where(x => x.Login.Contains(nome))
                                                .Select(x => new ObterClienteDTO(x))
                                                .ToList();

            return clientes;
        }

        public List<ObterClienteDTO> ListarTodos()
        {
            var clientes = _context.Clientes.Select(x => new ObterClienteDTO(x))
                                            .ToList();

            return clientes;
        }

        public Cliente AtualizarCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();

            return cliente;
        }

        public void AtualizarSenha(Cliente cliente, AtualizarSenhaClienteDTO dto)
        {
            cliente.Senha = dto.Senha;
            AtualizarCliente(cliente);
        }

        public void AtualizarNome(Cliente cliente, AtualizarNomeClienteDTO dto)
        {
            cliente.Nome = dto.Nome;
            AtualizarCliente(cliente);
        }

        public void DeletarCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }
    }
}