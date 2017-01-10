using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using App.WinForm.Annotation;

namespace App
{
    public class BaseRepository<T> : IBaseRepository where T : BaseEntity   
    {
        #region Variables
        public ModelContext Context { get; set; }
        private Type typeEntity;
        
        protected IDbSet<T> DbSet { get; set; }

        public Type  TypeEntity
        {
            get
            {
                return typeEntity;
            }

            set
            {
                typeEntity = value;
            }
        }
        #endregion


        #region construcreur
        public BaseRepository(ModelContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<T>();
            this.TypeEntity = typeof(T);
        }
        public BaseRepository()
        {
            this.Context = new ModelContext();
            this.DbSet = this.Context.Set<T>();
            this.TypeEntity = typeof(T);
        }
        #endregion


        #region Recherche
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

            return query.ToList<T>();
        }
        public List<object> GetAll()
        {
            List<T> ls = this.GetAll(0, 0).ToList<T>();
            return ls.ToList<Object>();
        }
        public List<Object> GetAllDetached()
        {
             
            List<Object> ls = this.DbSet.ToList<Object>();
            foreach (var item in ls)
            {
                this.Context.Entry(item).State = EntityState.Detached;
            }
            return ls;
          
        }

        public virtual T GetByID(Int64 id)
        {
            return DbSet.Find(id);
        }
        public virtual BaseEntity GetBaseEntityByID(Int64 id)
        {
            return DbSet.Find(id);
        }
        public object ToBindingList()
        {
            DbSet.Load();
            return DbSet.Local.ToBindingList();

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
        #endregion

        #region CRUD
        public virtual int Delete(T item)
        {
            var original = DbSet.Find(item.Id);
            DbSet.Remove(original);
            return Context.SaveChanges()  ;

        }
        /// <summary>
        /// Supprimer par un objet de Type BaseEntity
        /// Car delete n'est pas accissible depuis une interface non générique
        /// </summary>
        /// <param name="obj"></param>
        public void Supprimer(BaseEntity obj)
        {
            T entity = (T)obj;
            this.Delete(entity);
        }

        protected virtual int Insert(T item)
        {
         
            this.DbSet.Add(item);
            return this.Context.SaveChanges();
        }

        protected virtual int Update(T item)
        {
            this.Context.Entry(item).State = EntityState.Modified;
            item.DateModification = DateTime.Now;
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
       


        public int Save(BaseEntity item)
        {
            string state = this.Context.Entry(item).State.ToString();
            return this.Save((T)item);
        }
        #endregion

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

       

        ModelContext IBaseRepository.Context()
        {
            return this.Context;
        }

        public object CreateInstanceObjet()
        {
           return  this.Context.Set<T>().Create();
        }
        /// <summary>
        /// Obtien l'annotion 'AffichageDansFormGestion' de la classe Entity
        /// pour le paramétrage des titre de l'interface de gestion
        /// </summary>
        /// <returns></returns>
        public AffichageDansFormGestionAttribute getAffichageDansFormGestionAttribute()
        {
            Object[] ls_attribut = this.TypeEntity.GetCustomAttributes(typeof(AffichageDansFormGestionAttribute), false);
            if (ls_attribut == null || ls_attribut.Count() == 0) return new AffichageDansFormGestionAttribute();
            AffichageDansFormGestionAttribute AffichageDansFormGestion = (AffichageDansFormGestionAttribute)ls_attribut[0];
            return AffichageDansFormGestion;
        }
    }
}
