using Microsoft.AspNetCore.Mvc;
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
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno()
            {
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Almeida",
                Telefone = "419998899"
            },
            new Aluno()
            {
                Id = 2,
                Nome = "Marta",
                Sobrenome = "Kent",
                Telefone = "41996546549"
            },
            new Aluno()
            {
                Id = 3,
                Nome = "Lincoln",
                Sobrenome = "Ruteski",
                Telefone = "418998795"
            },
        };

        public AlunoController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
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
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);

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
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome));

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
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a .Sobrenome.Contains(sobrenome));

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
            return Ok();
        }

    }
}
