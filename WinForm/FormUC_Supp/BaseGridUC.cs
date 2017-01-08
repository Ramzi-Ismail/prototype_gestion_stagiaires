using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Gestion
{
    public  class BaseGridUC : UserControl
    {
        /// <summary>
        /// Le binding source d'affichage des objet
        /// </summary>
        protected BindingSource OBjetBindingSource;

        /// <summary>
        /// L'objet de gestion qui conteint la méthode getAll();
        /// </summary>
        //protected BaseRepository<BaseEntity> Service;


        //public BaseGridUC(var Service)
        //{
        //    this.Service = Service;
        //}

        /// <summary>
        /// Obtien l'objet séléctioné dans DataGrid
        /// </summary>
        /// <returns></returns>
        public virtual BaseEntity Current()
        {
            return (BaseEntity)OBjetBindingSource.Current;
        }

        // Evénements
        public event EventHandler EditerEvent;

        protected void onEditerEvent(Object sender, EventArgs e)
        {
            if (EditerEvent != null)
                EditerEvent(sender, e);
        }




        public virtual void Actualiser()
        {
            //OBjetBindingSource.Clear();
            //OBjetBindingSource.DataSource = Service.GetAll();

        }

    }
}
