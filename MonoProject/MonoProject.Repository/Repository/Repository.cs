using MonoProject.DAL.Context;
using MonoProject.DAL.Entities;
using MonoProject.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Repository
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        private readonly Context _context;
        readonly IUnitOfWorkFactory uowFactory;
        public Repository(IUnitOfWorkFactory wowFactory, Context context)
        {
            this._context = context;
            this.uowFactory = wowFactory;
        }
        public IDbSet<T> GetAll()
        {
            return _context.Set<T>();
        }
        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);

        }
        public async Task Insert(T entity)
        {
            var unitOfWork = uowFactory.CreateUnitOfWork();
            await unitOfWork.AddAsync<T>(entity);
            await unitOfWork.CommitAsync();
        }
        public async Task Update(T entity)
        {
            var unitOfWork = uowFactory.CreateUnitOfWork();
            await unitOfWork.UpdateAsync<T>(entity);
            await unitOfWork.CommitAsync();
        }
        public async Task Delete(T entity)
        {
            var unitOfWork = uowFactory.CreateUnitOfWork();
            await unitOfWork.DeleteAsync<T>(entity);
            await unitOfWork.CommitAsync();
        }
    }
}

