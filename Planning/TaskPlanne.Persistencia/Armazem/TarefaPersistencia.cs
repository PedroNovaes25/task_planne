using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlanner.Dominio;
using TaskPlanner.Persistencia.Contexto;
using TaskPlanner.Persistencia.Interface;

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
