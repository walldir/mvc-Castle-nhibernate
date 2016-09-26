using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCCastleNHibernate.Core.Data.Entities;
using MVCCastleNHibernate.Core.Data.Repositories;
using MVCCastleNHibernate.Core.Services;

namespace MVCCastleNHibernate.WebAPI.Controllers
{
    public class ClienteController : ApiController
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Retorna todos os Clientes, ordenando por Nome.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            var clientes = _clienteService.GetClienteList();
            return clientes;
        }

        /// <summary>
        /// Retona Cliente por Id
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns></returns>
        [HttpGet]
        public Cliente Get(int id)
        {
            var cliente = _clienteService.GetCliente(id);
            return cliente;
        }

        /// <summary>
        /// Adiciona/Edita Cliente
        /// </summary>
        /// <param name="cliente">Cliente</param>
        [HttpPost]
        public HttpResponseMessage AddEdit(Cliente cliente)
        {
            bool result = false;
            HttpResponseMessage response = null;

            if (cliente.Id == 0)
                result = _clienteService.CreateCliente(cliente);
            else
                result = _clienteService.UpdateCliente(cliente);

            if (result)
                response = Request.CreateResponse(HttpStatusCode.OK, cliente);
            else
                response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Ocorreu um erro inesperado.");

            return response;
        }

        /// <summary>
        /// Exclui cliente
        /// </summary>
        /// <param name="id">Id do cliente</param>
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            if (_clienteService.DeleteCliente(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Cliente excluído.");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Ocorreu um erro inesperado.");
            }
        }
    }
}
