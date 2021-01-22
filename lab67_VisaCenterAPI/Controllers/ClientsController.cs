using lab67_VisaCenterDAL.Entities;
using lab67_VisaCenterDAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab67_VisaCenterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        IUnitOfWork unitOfWork;

        public ClientsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<ClientsController>
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return unitOfWork.Clients.GetAll();
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public Client Get(int id)
        {
            return unitOfWork.Clients.Get(id);
        }

        // POST api/<ClientsController>
        [HttpPost]
        public void Post(Client client)
        {
            unitOfWork.Clients.Create(client);
        }

        // PUT api/<ClientsController>/5
        [HttpPut("{id}")]
        public void Put(Client client)
        {
            client.Id = Int32.Parse(RouteData.Values["id"].ToString());
            unitOfWork.Clients.Update(client);
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            unitOfWork.Clients.Delete(id);
        }
    }
}
