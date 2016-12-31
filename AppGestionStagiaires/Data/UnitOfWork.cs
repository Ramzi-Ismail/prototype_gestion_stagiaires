using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace AppGestionStagiaires
{
    public class UnitOfWork : IDisposable
    {
        private DbContextTransaction trans = null;

        public ModelContext Context { get; private set; }

        public UnitOfWork(ModelStagiaires context)
        {
            this.trans = context.Database.BeginTransaction();
            this.Context = context;
        }

        public void Commit()
        {
            if (this.trans != null)
            {
                this.trans.Commit();
                this.trans = null;
            }
        }

        public void RollBack()
        {
            if (this.trans != null)
            {
                this.trans.Rollback();
                this.trans = null;
            }
        }

        public void Dispose()
        {
            Commit();
            this.Context.Dispose();
        }
    }
}