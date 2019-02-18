using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Test_Task.Models.Event;

namespace Test_Task.Repositories
{
    public class EventUserRepository : IRepository<EventUser, int>
    {
        private EventContext db;

        public EventUserRepository()
        {
            db = new EventContext();
        }

        #region
        public void Create(EventUser item)
        {
            db.EventUsers.Add(item);
        }

        public void Delete(int id)
        {
            EventUser currentEventUser = db.EventUsers.Find(id);
            if (currentEventUser != null)
            {
                db.EventUsers.Remove(currentEventUser);
            }
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

        public IList<EventUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public EventUser GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(EventUser item)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}