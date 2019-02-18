using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task.Repositories
{
    interface IRepository<T, S> : IDisposable
        where  T : class where S : struct
    {
        IList<T> GetAll();
        T GetItem(S id);
        void Create(T item);
        void Update(T item);
        void Delete(S id);
        void Save();
    }
}
