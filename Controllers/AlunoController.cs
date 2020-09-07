using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBoletim.Domains;
using APIBoletim.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIBoletim.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase {
        //Call the Student repository
        AlunoRepository repo = new AlunoRepository();

        // GET: api/<AlunoController>
        [HttpGet]
        public List<Aluno> Get() {
            return repo.ReadAll();
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public Aluno Get(int id) {
            return repo.SearchbyId(id);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public Aluno Post([FromBody] Aluno a) {
            return repo.Register(a);
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
