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
        private readonly DataContext _context;

        public AlunoController(DataContext context)
        {
            _context = context;
        }
        

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
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

        // api/aluno/byid?id=1
        [HttpGet("byid")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

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

        // string ja é default entao nao preciso indicar
        [HttpGet("{nome}")]
        public IActionResult GetByName(string nome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome));

            if (aluno == null)
            {
                return BadRequest("O Aluno nao foi encontrado");
            }

            return Ok(aluno);
        }

        // api/aluno/ByName?nome=marta&sobrenome=kent
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a .Sobrenome.Contains(sobrenome));

            if (aluno == null)
            {
                return BadRequest("O Aluno nao foi encontrado");
            }

            return Ok(aluno);
        }

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
            _context.Add(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }

        // PUT api/<AlunosController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var al = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);

            if (al == null)
            {
                return BadRequest("O Aluno nao foi encontrado");
            }

            _context.Update(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }

        // DELETE api/<AlunosController>/5
        /*[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null)
            {
                return BadRequest("O Aluno nao foi encontrado");
            }

            _context.Remove(aluno);
            _context.SaveChanges();

            return Ok("Aluno " + aluno.Nome + " deletado com sucesso" );
        }

    }
}
