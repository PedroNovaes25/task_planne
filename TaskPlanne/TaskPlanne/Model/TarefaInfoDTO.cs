using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskPlanner.Model
{
    public class TarefaInfoDTO
    {
   
        public int IdTarefas { get; set; }
        public string Titulo { get; set; }

    }

    public static class TarefaConverteTo 
    {
        public static TarefaInfoDTO ConverterParaDto(this Tarefa tarefa)
        {
            return new TarefaInfoDTO
            {
                IdTarefas = tarefa.IdTarefa,
                Titulo = tarefa.Titulo
            };
        }

        public static List<TarefaInfoDTO> ConverteParaDto(this List<Tarefa> tarefas)
        {
            List<TarefaInfoDTO> tarefasDto = new List<TarefaInfoDTO>();

            foreach (var tarefa in tarefas)
            {
                tarefasDto.Add(tarefa.ConverterParaDto());
            }

            return tarefasDto;
        }
    }
}
