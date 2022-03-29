using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Dominio;

namespace TaskPlanne.Aplicacao
{
    public class QuadroInfoDTO
    {
        public QuadroInfoDTO(){}

        public QuadroInfoDTO(QuadroDeTarefas quadroDeTarefas)
        {
            this.IdQuadro = IdQuadro;
            this.Titulo = Titulo;
        }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int IdQuadro { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }

        public QuadroDeTarefas CopiaParaModel()
        {
            return new QuadroDeTarefas
            {
                Titulo = Titulo
            };
        }
    }
}
