using MonoProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MonoProject.Repository.Common
{
   public class UnitofWork : IUnitOfWork
    {
        protected Context DbContext { get; private set; }
        /// <summary>
        /// USING DB CONTEXT VAR
        /// </summary>
        /// <param name="dbContext"></param>
        public UnitofWork(Context dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("DbContext");
            }
            DbContext = dbContext;
        }
        /// <summary>
        /// ADD ITEM
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<int> AddAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbContext.Set<T>().Add(entity);
            }
            return Task.FromResult(1);
        }
        /// <summary>
        /// EDIT/UPDATE
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<int> UpdateAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbContext.Set<T>().Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;

            return Task.FromResult(1);
        }
        /// <summary>
        /// DELETE
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<int> DeleteAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbContext.Set<T>().Attach(entity);
                DbContext.Set<T>().Remove(entity);
            }
            return Task.FromResult(1);
        }
        /// <summary>
        /// DELETE
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Task<int> DeleteAsync<T>(string ID) where T : class
        {
            var entity = DbContext.Set<T>().Find(ID);
            if (entity == null)
            {
                return Task.FromResult(0);
            }
            return DeleteAsync<T>(entity);
        }
        /// <summary>
        /// COMMIT ASYNC
        /// </summary>
        /// <returns></returns>
        public async Task<int> CommitAsync()
        {
            int result = 0;
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                result = await DbContext.SaveChangesAsync();
                scope.Complete();
            }
            return result;
        }
        /// <summary>
        /// DISPOSE
        /// </summary>
        public void Dispose()
        {
            DbContext.Dispose();
        }
    }

}
