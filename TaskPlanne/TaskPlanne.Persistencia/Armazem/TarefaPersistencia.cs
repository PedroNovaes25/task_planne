using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlanne.Persistencia.BdContext;
using TaskPlanne.Persistencia.Interface;
using TaskPlanner.Dominio;

namespace TaskPlanne.Persistencia.Armazem
{
    public class TarefaPersistencia : ITarefaPersistencia
    {
        private readonly PlanilhaContext _context;
        public TarefaPersistencia(PlanilhaContext context)
        {
            _context = context;
        }

        public async Task<Tarefa> PegarTarefaPorId(int idTarefa)
        {
            IQueryable<Tarefa> query = _context.Tarefas;
            query = query.AsNoTracking().Where(taf => taf.IdTarefa == idTarefa);

            return await query.FirstOrDefaultAsync();
        }
    }
}
