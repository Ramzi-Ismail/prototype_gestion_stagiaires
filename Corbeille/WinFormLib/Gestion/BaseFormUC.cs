using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entites;
using EFlib.Entites;
using System.Windows.Forms;
using System.ComponentModel;

namespace App.Gestion
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


        #region validation
        protected void ValiderTextBox(object sender, CancelEventArgs e, ErrorProvider errorProvider, String message=""  )
        {

            TextBox controle = (TextBox)sender;
            if (message == "") message = "La saisie de ce champs est oblégatoir";
            if (controle.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(controle, message);
                e.Cancel = true;
            }
            else
                errorProvider.SetError(controle, "");
        }
        #endregion
    }
}
