using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlanne.Persistencia.BdContext;
using TaskPlanne.Persistencia.Interface;

namespace TaskPlanne.Persistencia.Armazem
{
    public class GeralPersistencia : IGeralPersistencia
    {
        private readonly PlanilhaContext _context;
        public GeralPersistencia(PlanilhaContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.AddAsync(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
