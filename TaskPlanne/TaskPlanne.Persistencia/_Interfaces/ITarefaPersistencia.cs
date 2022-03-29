using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlanner.Dominio;

namespace TaskPlanne.Persistencia.Interface
{
    public interface ITarefaPersistencia
    {
        Task<Tarefa> PegarTarefaPorId(int idTarefa);
    }
}
