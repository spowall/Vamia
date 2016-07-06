using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vamia.Core.Interface.DataAccess;

namespace Vamia.Data
{
    public class EntityRepository : IDataRepository
    {
        private DbContext _context;

        public EntityRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Query<T>() where T : class => _context.Set<T>();

        public IQueryable<T> Query<T>(params Expression<Func<T, object>>[] includeExpressions) where T : class
        {
            var query = Query<T>();
            foreach (var expression in includeExpressions)
            {
                query = query.Include(expression);
            }
            return query;
        }

        public void Add<T>(T item) where T : class => _context.Set<T>().Add(item);

        public void Delete<T>(T item) where T : class => _context.Set<T>().Remove(item);

        public void Update<T>(T entity) where T : class
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Set<T>().Attach(entity);
            }
            _context.Entry(entity).State = EntityState.Modified;
        }

        public Operation<int> SaveChanges()
        {
            var operation = new Operation<int>();
            try
            {
                _context.SaveChanges();
                operation.Succeeded = true;
                operation.Message = "Changes were Saved Successfully";
            }
            catch (DbEntityValidationException dbe)
            {
                string message = "An Error occured Saving: ";
                foreach (var ex in dbe.EntityValidationErrors)
                {
                    //Aggregate Errors
                    string errors = ex.ValidationErrors.Select(e => e.ErrorMessage).Aggregate((ag, e) => ag + " " + e);
                    message += errors;
                }
                operation.Message = message;
                operation.Succeeded = false;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                var message = "Could not save: " + ex.Message;
                operation.Message = message;
                operation.Succeeded = false;
            }
            return operation;
        }
    }
}
