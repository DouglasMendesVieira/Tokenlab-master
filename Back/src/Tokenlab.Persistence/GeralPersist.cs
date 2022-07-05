using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tokenlab.Domain;
using Tokenlab.Persistence.Contexto;
using Tokenlab.Persistence.Contratos;

namespace Tokenlab.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly TokenlabContext _context;
        public GeralPersist(TokenlabContext _context)
        {
            this._context = _context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}