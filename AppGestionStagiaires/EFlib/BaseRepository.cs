using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using EFlib.Entites;
using App;
using App.GestionGroupes;

namespace EFlib
{
    public class BaseRepository<T> : IBaseRepository where T : BaseEntity   
    {
        public ModelContext Context { get; set; }
        protected IDbSet<T> DbSet { get; set; }
  
        //public UnitOfWork UnitOfWork { get; set; }

        //public BaseRepository(UnitOfWork unitOfWork)
        //{
        //    if (unitOfWork == null)
        //    {
        //        throw new ArgumentException("An instance of the unitOfWork is null", "unitOfWork");
        //    }

        //    this.Context = unitOfWork.Context;
        //    this.DbSet = this.Context.Set<T>();

        //    this.UnitOfWork = unitOfWork;
        //}

        public BaseRepository(ModelContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }
        public BaseRepository()
        {
            this.Context = new ModelContext();
            this.DbSet = this.Context.Set<T>();
        }

        public virtual int Count(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.Count();
        }

        public virtual List<T> GetAll(int startPage = 0, int itemsPerPage = 0, Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> order = null, string includeProperties = "")
        {
            IQueryable<T> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (order != null && (startPage != 0 && itemsPerPage != 0))
            {
                query = order(query).Skip((startPage - 1) * itemsPerPage).Take(itemsPerPage);
            }

            if (order == null && (startPage != 0 && itemsPerPage != 0))
            {
                query = query.OrderByDescending(x => x.Id).Skip((startPage - 1) * itemsPerPage).Take(itemsPerPage);
            }

            return query.ToList();
        }
        public List<object> GetAll()
        {
            return this.GetAll(0,0).ToList<Object>();
        }

        public virtual T GetByID(int id)
        {
            return DbSet.Find(id);
        }

        public virtual int Delete(T item)
        {
            var original = DbSet.Find(item.Id);
            DbSet.Remove(original);
            return Context.SaveChanges()  ;

        }

        protected virtual int Insert(T item)
        {
            this.DbSet.Add(item);
            return this.Context.SaveChanges();
        }

        protected virtual int Update(T item)
        {
            this.Context.Entry(item).State = EntityState.Modified;
            return this.Context.SaveChanges();
        }
        //private int Update(T item)
        //{
        //    var original = DbSet.Find(item.Id);

        //    if (original != null)
        //    {
        //        Context.Entry(original).CurrentValues.SetValues(item);
        //        Context.Entry(original).State = EntityState.Modified;
        //        return Context.SaveChanges();
        //    }
        //    return 0;
        //}


        public virtual int Save(T item)
        {
            if (item.Id <= 0)
            {
                return Insert(item);
            }
            else
            {
                return Update(item);
            }
        }
       

        public virtual void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }
        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public object ToBindingList()
        {
            DbSet.Load();
            return DbSet.Local.ToBindingList();

        }
        /// <summary>
        /// Ajouter un nouvelle objet avec l'état Added qui sera ajouté 
        /// à la base de données aprés l'appelle de SaveChange
        /// </summary>
        public void AddElement()
        {
            this.DbSet.Add(Activator.CreateInstance<T>());
        }

        //public static implicit operator BaseRepository<T>(GroupesService v)
        //{

        //}

        public virtual string GetNomObjet()
        {
            BaseEntity obj = Activator.CreateInstance<T>();
            return obj.GetNomObjet();
        }
        public virtual string GetNomObjets()
        {
            BaseEntity obj = Activator.CreateInstance<T>();
            return obj.GetNomObjets();
        }

        /// <summary>
        /// Supprimer par un objet de Type BaseEntity
        /// </summary>
        /// <param name="obj"></param>
        public void Supprimer(BaseEntity obj)
        {
            T entity =(T) obj;
            this.Delete(entity);
        }

        
        public int Save(BaseEntity item)
        {
            string state = this.Context.Entry(item).State.ToString();
            return this.Save((T)item);
        }
    }
}
