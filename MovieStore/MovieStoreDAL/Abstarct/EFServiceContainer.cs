using System;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace MovieStoreDAL.Abstarct
{
    public abstract class EFServiceContainer<TContext> : IDisposable where TContext:DbContext
    {
        protected TContext Context;

        public virtual void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException exception)
            {
                string validationErrorMesage = exception.Message;
                Console.WriteLine(validationErrorMesage);
            }
        }
#region Disposable

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
#endregion
    }
}
