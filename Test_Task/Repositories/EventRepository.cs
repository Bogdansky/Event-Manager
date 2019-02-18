using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Test_Task.Models.Event;
using System.Threading.Tasks;

namespace Test_Task.Repositories
{
    public class EventRepository : IRepository<Models.Event.Event, int>
    {
        private EventContext db;

        public EventRepository()
        {
            db = new EventContext();
        }

        #region Implementation of IRepository
        public void Create(Event item)
        {
            db.Events.Add(item);
        }

        public void Delete(int id)
        {
            Event currentEvent = db.Events.Find(id);
            if (currentEvent != null)
            {
                db.Events.Remove(currentEvent);
            }
        }

        public IList<Event> GetAll()
        {
            return db.Events.ToList();
        }

        public Event GetItem(int id)
        {
            return db.Events.Find(id);
        }

        async public Task<Event> GetItemAsync(int id)
        {
            return await db.Events.FindAsync(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        async public void SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Update(Event item)
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

        public List<Event> GetActualEvents()
        {
            var result = new List<Event>();
            var eventUsers = db.EventUsers.ToList();
            var events = db.Events.ToList();
            foreach(var e in events)
            {
                if (e.Date >= DateTime.Now)
                {
                    result.Add(e);
                }
            }
            return result;
        }
    }
}