using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }

        // api/aluno/1
        /*[HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null)
            {
                return BadRequest("O Aluno nao foi encontrado");
            }

            return Ok(aluno);
        }*/

        // api/aluno/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id);

            if (aluno == null)
            {
                return BadRequest("O Aluno nao foi encontrado");
            }

            return Ok(aluno);
        }

        // api/aluno/byid/1
        /*[HttpGet("byid/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null)
            {
                return BadRequest("O Aluno nao foi encontrado");
            }

            return Ok(aluno);
        }*/

        // GET: api/<AlunosController>
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/<AlunosController>/5
        /*        [HttpGet("{id}")]
                public string Get(int id)
                {
                    return "value";
                }*/

        // POST api/<AlunosController>
        /*[HttpPost]
        public void Post([FromBody] string value)
        {
        }*/

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);

            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno nao cadastrado");
        }

        // PUT api/<AlunosController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var al = _repo.GetAlunoById(id);

            if (al == null)
            {
                return BadRequest("O Aluno nao foi encontrado");
            }

            _repo.Update(aluno);

            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno nao atualizado");
        }

        // DELETE api/<AlunosController>/5
        /*[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);

            if (aluno == null)
            {
                return BadRequest("O Aluno nao foi encontrado");
            }

            _repo.Delete(aluno);

            if (_repo.SaveChanges())
            {
                return Ok("Aluno deletado com sucesso");
            }

            return BadRequest("Aluno nao deletado");
        }

    }
}
