using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo) 
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var professor = _repo.GetProfessorById(id);

            if (professor == null)
            {
                return BadRequest("Professor não encontrado");
            }

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);

            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor nao cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id);

            if (prof == null)
            {
                return BadRequest("O Professor nao foi encontrado");
            }

            _repo.Update(prof);

            if (_repo.SaveChanges())
            {
                return Ok(prof);
            }

            return BadRequest("Professor nao atualizado");
        }

        [HttpPut]
        public IActionResult Put(Professor professor)
        {
            var prof = _repo.GetProfessorById(professor.Id);

            if (prof == null)
            {
                return BadRequest("O Professor nao foi encontrado");
            }

            _repo.Update(prof);

            if (_repo.SaveChanges())
            {
                return Ok(prof);
            }

            return BadRequest("Professor nao atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id);

            if (professor == null)
            {
                return BadRequest("O Professor nao foi encontrado");
            }

            _repo.Delete(professor);

            if (_repo.SaveChanges())
            {
                return Ok("Professor deletado com sucesso");
            }

            return BadRequest("Professor nao deletado");
        }
    }
}
