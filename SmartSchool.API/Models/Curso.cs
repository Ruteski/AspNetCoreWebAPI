using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Curso
    {
        public Curso() { }

        public Curso(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}
