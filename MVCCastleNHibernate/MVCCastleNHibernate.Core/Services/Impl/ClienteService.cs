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

        public void CreateCliente(Cliente cliente)
        {
            _clienteRepository.Insert(cliente);
        }

        public void UpdateCliente(Cliente cliente)
        {
            _clienteRepository.Update(cliente);
        }

        public void DeleteCliente(int clienteId)
        {
            _clienteRepository.Delete(clienteId);
        }
    }
}
