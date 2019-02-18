using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Test_Task.Models.Event;

namespace Test_Task.Repositories
{
    public class FieldRepository : IRepository<Field, int>
    {
        private EventContext db;

        public FieldRepository()
        {
            db = new EventContext();
        }

        #region Implementation of IRepository
        public void Create(Field item)
        {
            db.Fields.Add(item);
        }

        public void Delete(int id)
        {
            Field currentField = db.Fields.Find(id);
            if (currentField != null)
            {
                db.Fields.Remove(currentField);
            }
        }

        public IList<Field> GetAll()
        {
            return db.Fields.ToList();
        }

        public Field GetItem(int id)
        {
            return db.Fields.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Field item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        public IEnumerable<Field> GetEventFields(int eventId)
        {
            return db.Fields.Where(field => field.EventId == eventId);
        }
    }
}