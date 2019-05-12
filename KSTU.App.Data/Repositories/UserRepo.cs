using KSTU.App.BLL.Entities;
using KSTU.App.BLL.Interfaces;
using KSTU.App.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSTU.App.Data.Repositories
{
    public class Repo<T> : IRepo<T> where T : class
    {
        private readonly ApplicationContext _dbContext;
        public Repo(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddRange(List<T> range)
        {
            try
            {
                _dbContext.Set<T>().AddRange(range);
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public IQueryable<T> ListAllAsync()
        {
            return _dbContext.Set<T>().AsQueryable();
        }
    }
}
