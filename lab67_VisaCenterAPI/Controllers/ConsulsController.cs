using AutoMapper;
using lab67_VisaCenterAPI.Mappers;
using lab67_VisaCenterAPI.ViewModels;
using lab67_VisaCenterDAL.Entities;
using lab67_VisaCenterDAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab67_VisaCenterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsulsController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;

        public ConsulsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        // GET: api/<ConsulsController>
        [HttpGet]
        public IEnumerable<ConsulViewModel> Get()
        {
            return mapper.Map<IEnumerable<ConsulViewModel>>(unitOfWork.Consuls.GetAll());
        }

        // GET api/<ConsulsController>/5
        [HttpGet("{id}")]
        public Consul Get(int id)
        {
            return unitOfWork.Consuls.Get(id);
        }

        // POST api/<ConsulsController>
        [HttpPost]
        public void Post(Consul consul)
        {
            unitOfWork.Consuls.Create(consul);
        }

        // PUT api/<ConsulsController>/5
        [HttpPut("{id}")]
        public void Put(Consul consul)
        {
            unitOfWork.Consuls.Update(consul);
        }

        // DELETE api/<ConsulsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            unitOfWork.Consuls.Delete(id);
        }
    }
}
