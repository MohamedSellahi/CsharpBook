using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFAutoLotDAL.EF;
using System.Data.Entity;

namespace EFAutoLotDAL.Repos {

   public abstract class BaseRepo<T>: IRepo<T>, IDisposable where T:class,new() {

      protected AutoLotEntities Context { get; } = new AutoLotEntities();
      protected DbSet<T> Table;




      public int Add(T entity) {
         throw new NotImplementedException();
      }

      public Task<int> AddAsync(T entity) {
         throw new NotImplementedException();
      }

      public int AddRange(IList<T> entities) {
         throw new NotImplementedException();
      }

      public Task<int> AddRangeAsync(IList<T> entities) {
         throw new NotImplementedException();
      }

      public int Save(T entity) {
         throw new NotImplementedException();
      }

      public Task<int> SaveAsync(T entity) {
         throw new NotImplementedException();
      }

      public int Delete(int id) {
         throw new NotImplementedException();
      }

      public Task<int> DeleteAsync(int id) {
         throw new NotImplementedException();
      }

      public T GetOne(int? id) {
         throw new NotImplementedException();
      }

      public Task<T> GetOneAsync(int? id) {
         throw new NotImplementedException();
      }

      public List<T> GetAll() {
         throw new NotImplementedException();
      }

      public Task<List<T>> GetAllAsync() {
         throw new NotImplementedException();
      }

      public List<T> ExecuteQuery(string sql) {
         throw new NotImplementedException();
      }

      public Task<List<T>> ExecuteQueryAsync(string sql) {
         throw new NotImplementedException();
      }

      public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects) {
         throw new NotImplementedException();
      }

      public Task<List<T>> ExecuteQueryAsync(string sql, object[] sqlParametersObjects) {
         throw new NotImplementedException();
      }

      public void Dispose() {
         throw new NotImplementedException();
      }
   }
}
