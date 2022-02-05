using System;

namespace SmartSchool.API.V2.Dtos
{
    /// <summary>
    /// Este é o DTO de Aluno para Registrar.
    /// </summary>
    public class AlunoRegistrarDto
    {
        /// <summary>
        /// Identificador e chave do Banco.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Chave do Aluno, para outros negócios na Instituição.
        /// </summary>
        public int Matricula { get; set; }
        /// <summary>
        /// Nome é o Primeiro nome o o Sobrenome do Aluno.
        /// </summary>
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataIni { get; set; } = DateTime.UtcNow;
        public DateTime? Datafim { get; set; } = null;
        public bool Ativo { get; set; } = true;
    }
}
