using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreDAL.Abstarct
{
    public abstract class ServiceGroup<TContext> : IDisposable where TContext:DbContext
    {
        protected TContext context;

        public virtual void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException exception)
            {
                string validationErrorMesage = exception.Message;
                Console.WriteLine(validationErrorMesage);
            }
        }
#region Disposable

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
#endregion
    }
}
