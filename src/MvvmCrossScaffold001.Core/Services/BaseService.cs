using System;
using System.Linq;
using System.Collections.Generic;
using MvvmCrossScaffold001.Core.Models;
using SQLite;

namespace MvvmCrossScaffold001.Core.Services
{
    public interface IService : IDisposable
    {

    }

    public interface IBaseService<T> : IService 
        where T : BaseModel, new()
    {
        T GetById(int Id);

        TableQuery<T> GetTable();
        IEnumerable<T> GetAll();

        int Save(T entity);
        void Delete(T entity);

    }
    //------------------------------------------------------
    //------------------------------------------------------

    public abstract class BaseService<T> : IBaseService<T> where T : BaseModel, new()
    {

        protected SQLiteConnection _dbConn;
        private static readonly object locker = new object();
        protected readonly IRepositoryService _repoSvc;

        public BaseService(IRepositoryService repoSvc)
        {
            _repoSvc = repoSvc;
            _dbConn = _repoSvc.GetConnetion();

        }

        public T GetById(int Id)
        {
            //throw new NotImplementedException();
            return _dbConn.Table<T>().FirstOrDefault(x => x.Id == Id);
        }

        public TableQuery<T> GetTable()
        {
            //throw new NotImplementedException();
            return _dbConn.Table<T>();
        }

        public IEnumerable<T> GetAll()
        {
            //throw new NotImplementedException();
            return _dbConn.Table<T>().ToList();
        }

        public int Save(T entity)
        {
            //throw new NotImplementedException();
            lock(locker)
            { 
                if(entity.Id != 0)
                {
                    return _dbConn.Update(entity);
                }
                else
                {
                    return _dbConn.Insert(entity);
                }
            }
        }

        public void Delete(T entity)
        {
            //throw new NotImplementedException();
            if (null == entity)
                throw new ArgumentNullException("entity");
            _dbConn.Delete(entity);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
