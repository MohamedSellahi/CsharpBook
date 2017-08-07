using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFAutoLotDAL.EF;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EFAutoLotDAL.Repos {

   public abstract class BaseRepo<T> : IDisposable where T : class, new() {

      protected AutoLotEntities Context { get; } = new AutoLotEntities();
      protected DbSet<T> Table;


      #region IRepo Implementation

      public int Save(T entity) {
         Context.Entry(entity).State = EntityState.Modified;
         return SaveChanges();
      }

      public Task<int> SaveAsync(T entity) {
         Context.Entry(entity).State = EntityState.Modified;
         return SaveChangesAsync();
      }


      public int Add(T entity) {
         Table.Add(entity);
         return SaveChanges();
      }

      public Task<int> AddAsync(T entity) {
         Table.Add(entity);
         return SaveChangesAsync();
      }

      public int AddRange(IList<T> entities) {
         Table.AddRange(entities);
         return SaveChanges();
      }

      public Task<int> AddRangeAsync(IList<T> entities) {
         Table.AddRange(entities);
         return SaveChangesAsync();
      }

      public int SaveChanges() {
         try {
            return Context.SaveChanges();
         }
         catch (DbUpdateConcurrencyException ex) {
            // Thrown where there is a cuncurrency error 
            // just rethrow for now 
            throw;
         }
         catch (DbUpdateException ex) {
            //Thrown when database update fails
            //Examine the inner exception(s) for additional
            //details and affected objects
            //for now, just rethrow the exception
            throw;
         }
         catch (CommitFailedException ex) {
            // handle transaction failures here
            // Examine the inner exception for additionnal
            // details and affected objects 
            // for now just rethrow 
            throw;
         }
         catch (Exception ex) {
            // Any other exception is caught here
            // for now just rethrow 
            throw;
         }
      }

      public async Task<int> SaveChangesAsync() {
         try {
            return await Context.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException ex) {
            // Thrown where there is a cuncurrency error 
            // just rethrow for now 
            throw;
         }
         catch (DbUpdateException ex) {
            //Thrown when database update fails
            //Examine the inner exception(s) for additional
            //details and affected objects
            //for now, just rethrow the exception
            throw;
         }
         catch (CommitFailedException ex) {
            // handle transaction failures here
            // Examine the inner exception for additionnal
            // details and affected objects 
            // for now just rethrow 
            throw;
         }
         catch (Exception) {

            throw;
         }
      }

      public int Delete(T entity) {
         Context.Entry(entity).State = EntityState.Deleted;
         return SaveChanges();
      }

      public Task<int> DeleteAsync(T entity) {
         Context.Entry(entity).State = EntityState.Deleted;
         return SaveChangesAsync();
      }

      public T GetOne(int? id) => Table.Find(id);

      public Task<T> GetOneAsync(int? id) => Table.FindAsync(id);

      public List<T> GetAll() => Table.ToList();

      public Task<List<T>> GetAllAsync() => Table.ToListAsync();

      public List<T> ExecuteQuery(string sql) => Table.SqlQuery(sql).ToList();

      public Task<List<T>> ExecuteQueryAsync(string sql)
         => Table.SqlQuery(sql).ToListAsync();

      public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects)
         => Table.SqlQuery(sql, sqlParametersObjects).ToList();

      public Task<List<T>> ExecuteQueryAsync(string sql, object[] sqlParametersObjects)
         => Table.SqlQuery(sql, sqlParametersObjects).ToListAsync();


      #endregion

      #region Disposing logic

      bool disposed = false;

      
      public void Dispose() {
         // Call the helper method 
         // Specifying "true" signifies that 
         // the object user triggered the cleanup 
         Dispose(true);
         // Now suppress finalization
         GC.SuppressFinalize(this);
      }

      private void Dispose(bool disposing) {

         // Be sure we have not already  been disposed!
         if (!disposed) {
            // if disposing equal "true", dispose 
            // all managed resources 
            if (disposing) {
               // Dispose managed resources 

            }

            // CLeanup unmanaged resources here.
            disposed = true;
         }
         
      }
      ~BaseRepo() {
         //Call helper method .
         // specify false signifies that 
         // CG triggered the cleanup 
         Dispose(false);
      }
      #endregion


   }
}
