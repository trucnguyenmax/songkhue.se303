using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data;

namespace Songkhue.SE303.Core
{
    public class Repository<T> where T : class
    {
        private ObjectContext _context;
        private readonly IObjectSet<T> _objectSet;

        public Repository(ObjectContext context)
        {
            _context = context;
            _objectSet = _context.CreateObjectSet<T>();

        }

        public Repository(ObjectContext context, bool lazyLoading)
        {
            _context = context;
            _objectSet = _context.CreateObjectSet<T>();
            _context.ContextOptions.LazyLoadingEnabled = lazyLoading;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void SaveChanges(SaveOptions options)
        {
            _context.SaveChanges(options);
        }

        public IQueryable<T> Fetch()
        {
            return _objectSet;
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _objectSet.AddObject(entity);

        }

        public void Edit(T entity)
        {
            //_context.ObjectStateManager.ChangeObjectState(entity, EntityState.Unchanged);
            _objectSet.Attach(entity);
            _context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _objectSet.DeleteObject(entity);


        }
    }
}
