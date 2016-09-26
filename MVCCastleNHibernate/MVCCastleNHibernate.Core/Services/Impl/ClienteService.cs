using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCCastleNHibernate.Core.Data;
using MVCCastleNHibernate.Core.Data.Entities;
using MVCCastleNHibernate.Core.Data.Repositories;

namespace MVCCastleNHibernate.Core.Services.Impl
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [UnitOfWorkAttribute]
        public List<Cliente> GetClienteList()
        {
            return _clienteRepository.GetAll().OrderBy(cliente => cliente.Nome).ToList();
        }

        public Cliente GetCliente(int id)
        {
            return _clienteRepository.Get(id);
        }

        public bool CreateCliente(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome))
                return false;

            _clienteRepository.Insert(cliente);
            return true;
        }

        public bool UpdateCliente(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome))
                return false;

            _clienteRepository.Update(cliente);
            return true;
        }

        public bool DeleteCliente(int clienteId)
        {
            _clienteRepository.Delete(clienteId);
            return true;
        }
    }
}
