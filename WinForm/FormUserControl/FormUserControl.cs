﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm
{
    public partial class FormUserControl : UserControl, IFormUserControl
    {
        #region Variables
        /// <summary>
        /// à supprimer , utilisez Service
        /// </summary>
        protected ModelContext context;
        /// <summary>
        /// Obtient ou définire l'entité qui représente 
        /// </summary>
        public BaseEntity Entity { get; set; }

        /// <summary>
        /// l'instance de service de la gestion en cours
        /// 
        /// </summary> 
        public IBaseRepository Service { get; set; }

        #endregion

        #region Constructeurs
        /// <summary>
        /// à supprimer , il faut utiliser le service au lieux de context
        /// </summary>
        /// <param name="context"></param>
        public FormUserControl(ModelContext context)
        {
            InitializeComponent();
            this.context = context;
        }
        /// <summary>
        /// Créer du formuliare avec l'instance de service en cours d'utilisation
        /// </summary>
        /// <param name="service"></param>
        public FormUserControl(IBaseRepository service)
        {
            InitializeComponent();
            this.Service = service;
        }

        ///// <summary>
        ///// à supprimer
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <param name="context"></param>
        //public FormUserControl(BaseEntity entity, ModelContext context)
        //{
        //    InitializeComponent();
        //    this.Entity = entity;
        //    this.context = context;
        //}
        public FormUserControl()
        {
            InitializeComponent();
        }
        #endregion

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

        #region CreateInsce

        /// <summary>
        /// Création d'une instance comme cette formulaire
        /// </summary>
        /// <returns></returns>
        public virtual FormUserControl CreateInstance(IBaseRepository Service) {
            return (FormUserControl) Activator.CreateInstance (this.GetType(), Service);
           
        }


        /// <summary>
        /// Créer une instance de l'objet du formulaire
        /// </summary>
        /// <returns></returns>
        public virtual BaseEntity CreateObjetInstance()
        {
            return new BaseEntity();
        }
        #endregion

        #region Enregistrer et Annuler
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

        void IFormUserControl.Lire()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}