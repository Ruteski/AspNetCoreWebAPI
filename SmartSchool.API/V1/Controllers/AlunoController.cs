using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.V1.Dtos;
using SmartSchool.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartSchool.API.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.V1.Controllers
{
   /// <summary>
   /// Versão 1 da controller de alunos
   /// </summary>
   [ApiController]
   [ApiVersion("1.0")]
   [Route("api/v{version:apiVersion}/[controller]")]
   public class AlunoController : ControllerBase
   {
      private readonly IRepository _repo;
      private readonly IMapper _mapper;

      /// <summary>
      /// 
      /// </summary>
      /// <param name="repo"></param>
      /// <param name="mapper"></param>
      public AlunoController(IRepository repo, IMapper mapper)
      {
         _repo = repo;
         _mapper = mapper;
      }

      /// <summary>
      /// Método resposável por retornar todos os alunos
      /// </summary>
      /// <returns></returns>
      [HttpGet]
      public async Task<IActionResult> Get([FromQuery] PageParams pageParams)
      {
         var alunos = await _repo.GetAllAlunosAsync(pageParams, true);
         var alunosResult = _mapper.Map<IEnumerable<AlunoDto>>(alunos);

         Response.AddPagination(alunos.CurrentPage, alunos.PageSize, alunos.TotalCount, alunos.TotalPages);

         return Ok(alunosResult);
      }

      /// <summary>
      /// Método responsável por retornar apenas 1 aluno, buscando pelo id do aluno
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      // api/aluno/1
      [HttpGet("{id}")]
      public IActionResult GetById(int id)
      {
         var aluno = _repo.GetAlunoById(id);

         if (aluno == null)
         {
            return BadRequest("O Aluno nao foi encontrado");
         }

         var alunoDto = _mapper.Map<AlunoDto>(aluno);

         return Ok(alunoDto);
      }

      /// <summary>
      /// Método resposável por criar um novo aluno
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      [HttpPost]
      public IActionResult Post(AlunoRegistrarDto model)
      {
         var aluno = _mapper.Map<Aluno>(model);

         _repo.Add(aluno);

         if (_repo.SaveChanges())
         {
            return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
         }

         return BadRequest("Aluno nao cadastrado");
      }

      /// <summary>
      /// Método resposável por atualizar um Aluno
      /// </summary>
      /// <param name="id"></param>
      /// <param name="model"></param>
      /// <returns></returns>
      // api/aluno/1
      [HttpPut("{id}")]
      public IActionResult Put(int id, AlunoRegistrarDto model)
      {
         var aluno = _repo.GetAlunoById(id);

         if (aluno == null)
         {
            return BadRequest("O Aluno nao foi encontrado");
         }

         _mapper.Map(model, aluno);

         _repo.Update(aluno);

         if (_repo.SaveChanges())
         {
            return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
         }

         return BadRequest("Aluno nao atualizado");
      }

      /// <summary>
      /// Método responsável por deletar um aluno
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
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
