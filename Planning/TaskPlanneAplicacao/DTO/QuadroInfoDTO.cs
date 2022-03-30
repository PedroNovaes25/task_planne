using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Dominio;

namespace TaskPlanner.Aplicacao
{
    public class QuadroInfoDTO
    {
        public QuadroInfoDTO(){}

        public QuadroInfoDTO(QuadroDeTarefas quadroDeTarefas)
        {
            this.IdQuadro = quadroDeTarefas.IdQuadro;
            this.Titulo = quadroDeTarefas.Titulo;
        }

        public int IdQuadro { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }

        public QuadroDeTarefas CopiaParaModel()
        {
            return new QuadroDeTarefas
            {
                IdQuadro = IdQuadro,
                Titulo = Titulo
            };
        }
    }
}
