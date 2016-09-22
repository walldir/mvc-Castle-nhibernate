using System.Collections.Generic;
using MVCCastleNHibernate.Core.Data.Entities;

namespace MVCCastleNHibernate.Core.Services
{
    public interface IClienteService
    {
        List<Cliente> GetClienteList();

        void CreateCliente(Cliente cliente);

        void UpdateCliente(Cliente cliente);

        void DeleteCliente(int clienteId);
    }
}
