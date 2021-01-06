using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Dtos;
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
            var alunos = _repo.GetAllAlunos(true);
            var alunosRetorno = new List<AlunoDto>();

            foreach (var aluno in alunos)
            {
                alunosRetorno.Add(new AlunoDto()
                {
                    Id = aluno.Id,
                    Matricula = aluno.Matricula,
                    Nome = $"{aluno.Nome} {aluno.Sobrenome}",
                    Telefone = aluno.Telefone,
                    DataNasc = aluno.DataNasc,
                    DataIni = aluno.DataIni,
                    Ativo = aluno.Ativo
                });
            }

            return Ok(alunosRetorno);
        }

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

        // api/aluno/1
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

        // api/aluno/1
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
