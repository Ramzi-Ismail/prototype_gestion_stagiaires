using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cplus.Entites;

namespace Cplus.Gestion
{
    public  class BaseFormUC : System.Windows.Forms.UserControl
    {
        public BaseFormUC()
        {

        }
        #region Evenements
        public event EventHandler EnregistrerClick;
        public event EventHandler AnnulerClick;

        protected void onEnregistrerClick(Object sender,EventArgs e)
        {
            if (EnregistrerClick != null) EnregistrerClick(sender, e);
        }
        protected void onAnnulerClick(Object sender, EventArgs e)
        {
            if (AnnulerClick != null) AnnulerClick(sender, e);
        }
        #endregion

        /// <summary>
        /// Obtient ou définire l'entité qui représente 
        /// </summary>
        public BaseEntity Entity { get; set; }

        public virtual void Afficher() { } 
    }
}
