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
    public class QuadroDeTarefasPersistencia : IQuadroDeTarefasPersistencia
    {
        private readonly PlanilhaContext _context;

        public QuadroDeTarefasPersistencia(PlanilhaContext context)
        {
            this._context = context;
        }

        public async Task<List<QuadroDeTarefas>> PegarQuadros()
        {
            IQueryable<QuadroDeTarefas> query = _context.QuadroDeTarefas.Include( t => t.Tarefas);
            query = query.AsNoTracking().Select(x => x);

            return await query.ToListAsync();
        }

        public async Task<QuadroDeTarefas> PegarQuadroPorId(int idQuadro)
        {
            IQueryable<QuadroDeTarefas> query = _context.QuadroDeTarefas.Include(t => t.Tarefas);

            query = query.AsNoTracking().Where(x => x.IdQuadro == idQuadro);

            return await query.FirstOrDefaultAsync();
        }
    }
}
