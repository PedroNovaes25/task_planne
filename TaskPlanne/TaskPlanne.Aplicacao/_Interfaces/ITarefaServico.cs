using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlanne.Aplicacao._Interfaces
{
    public interface ITarefaServico
    {
        Task<TarefaDTO> PegarTarefaPorId(int idTarefa);
        Task<TarefaDTO> CriarTarefa(TarefaDTO tarefaDTO);
        Task<bool> DeletarTarefa(int idTarefa);
        Task<TarefaDTO> AtualizarTarefa(int idTarefa, TarefaDTO tarefaDTO);
    }
}
