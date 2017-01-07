using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.WinFromLib.FromsUC;

namespace App.WinFromLib.FormUC
{
    public partial class BaseFormUserControl : UserControl, IBaseFormUC
    {
        protected ModelContext context;
        /// <summary>
        /// Obtient ou définire l'entité qui représente 
        /// </summary>
        public BaseEntity Entity { get; set; }
        public IBaseRepository Service { get; set; }
        public BaseFormUserControl(ModelContext context)
        {
            InitializeComponent();
            this.context = context;
        }
        public BaseFormUserControl(BaseEntity entity, ModelContext context)
        {
            InitializeComponent();
            this.Entity = entity;
            this.context = context;
        }



        #region Evénement
        public event EventHandler EnregistrerClick;
        public event EventHandler AnnulerClick;
        protected void onEnregistrerClick(Object sender, EventArgs e)
        {
            if (EnregistrerClick != null) EnregistrerClick(sender, e);
        }
        protected void onAnnulerClick(Object sender, EventArgs e)
        {
            if (AnnulerClick != null) AnnulerClick(sender, e);
        }
        #endregion

       
        #region validation
        protected void ValiderTextBox(object sender, CancelEventArgs e, ErrorProvider errorProvider, String message = "")
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

        /// <summary>
        /// Creation d'une instance de l'objet en cours
        /// </summary>
        /// <returns></returns>

        #endregion

        public virtual BaseFormUserControl CreateInstance(IBaseRepository Service) {
            throw new Exception("Exécution d'une méthode Abstract");
        } 
         

        /// <summary>
        /// Créer une instance de l'objet du formulaire
        /// </summary>
        /// <returns></returns>
        public virtual BaseEntity CreateObjetInstance()
        {
            return new BaseEntity();
        }

        /// <summary>
        /// Affiher l'objet dans le formulaire
        /// </summary>
        public virtual void Afficher() { }
        /// <summary>
        /// Lire les information du formulaire vers l'objet
        /// </summary>
        protected virtual void Lire() { }

        private void btEnregistrer_Click(object sender, EventArgs e)
        {
            bool validation = true;
            if (ValidationManager.hasValidationErrors(this.Controls))
                return;
            this.Lire();

            if (validation)
            {
                if (Service.Save(this.Entity) > 0)
                {
                    MessageBox.Show(this.Entity.ToString() + " a été bien enregistrer");
                }
                else
                {
                    MessageBox.Show(this.Entity.ToString() + " n'est pas enregistrer car il n'y a pas des modifications");
                }
                onEnregistrerClick(this, e);
            }
        }

        private void btAnnuler_Click(object sender, EventArgs e)
        {
            onAnnulerClick(this, e);
        }
    }
}
