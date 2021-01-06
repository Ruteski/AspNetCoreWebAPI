using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Dtos;
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
        private readonly IMapper _mapper;

        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repo.GetAllProfessores(true);

            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var professor = _repo.GetProfessorById(id);

            if (professor == null)
            {
                return BadRequest("Professor não encontrado");
            }

            var professorDto = _mapper.Map<ProfessorDto>(professor);

            return Ok(professorDto);
        }

        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto model)
        {
            var prof = _mapper.Map<Professor>(model);

            _repo.Add(prof);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(prof));
            }

            return BadRequest("Professor não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDto model)
        {
            var professor = _repo.GetProfessorById(id);

            if (professor == null)
            {
                return BadRequest("O Aluno nao foi encontrado");
            }

            _mapper.Map(model, professor);

            _repo.Update(professor);

            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("Aluno nao atualizado");
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
