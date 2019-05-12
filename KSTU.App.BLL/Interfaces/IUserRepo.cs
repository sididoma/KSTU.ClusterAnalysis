using KSTU.App.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSTU.App.BLL.Interfaces
{
    public interface IRepo<T> where T : class
    {
        bool AddRange(List<T> range);
        IQueryable<T> ListAllAsync();
    }
}
