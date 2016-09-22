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

        // GET api/values
        public IEnumerable<Cliente> Get()
        {
            var clientes = _clienteService.GetClienteList();
            return clientes;
        }

        // GET api/values/5
        /// <summary>
        /// Retonar valor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
