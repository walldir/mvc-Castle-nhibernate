using System.Collections.Generic;
using MVCCastleNHibernate.Core.Data.Entities;

namespace MVCCastleNHibernate.Core.Services
{
    public interface IClienteService
    {
        List<Cliente> GetClienteList();

        Cliente GetCliente(int clienteId);

        bool CreateCliente(Cliente cliente);

        bool UpdateCliente(Cliente cliente);

        bool DeleteCliente(int clienteId);
    }
}
