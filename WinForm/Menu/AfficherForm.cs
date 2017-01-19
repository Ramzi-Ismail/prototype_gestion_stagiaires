using App.WinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinFrom.Menu
{
    /// <summary>
    /// Helper Pour Afficher un formulaire dans l'application
    /// </summary>
    public class AfficherFormHelper 
    {
        /// <summary>
        /// L'objet Form MDI
        /// </summary>
        Form FormApplicationMdi { set; get; }


        /// <summary>
        /// Création d'une instance de AfficherHelper
        /// </summary>
        /// <param name="Parent">
        /// L'objet Form : conteneur des formulaire de l'application
        /// Générale c'est une objet From MDI
        /// </param>
        public AfficherFormHelper(Form FormApplicationMdi)
        {
            this.FormApplicationMdi = FormApplicationMdi;
        }

        #region Afficher par Type d'entity
        public EntityManagementForm AfficherUneGestion(Type TypeEntity) 
        {
            IBaseRepository baseRepository = new BaseRepository<BaseEntity>()
                .CreateInstance_Of_Service_From_TypeEntity(TypeEntity);

            EntityManagementForm form = new EntityManagementForm(baseRepository, null, null, this.FormApplicationMdi);
            this.Afficher(form);
            return form;
        }

        public EntityManagementForm AfficherUneGestion<T>() where T : BaseEntity
        {
           return AfficherUneGestion(typeof(T));
        }
        #endregion



        public void AfficherUneGestion<T>(IBaseRepository Service) where T : BaseEntity
        {
            EntityManagementForm form = new EntityManagementForm(Service, null, null, this.FormApplicationMdi);
            this.Afficher(form);
        }

        /// <summary>
        /// Afficher une gestion avec une formulaire spécifique
        /// </summary>
        /// <typeparam name="T">L'objet à gérer</typeparam>
        /// <param name="formulaire">Le Formulaire spécifique</param>
        public EntityManagementForm AfficherUneGestion<T>(BaseEntryForm formulaire) where T : BaseEntity
        {
           

            EntityManagementForm form = new EntityManagementForm(formulaire.Service, formulaire, null, this.FormApplicationMdi);
            this.Afficher(form);
            return form;
        }

        public void AfficherUneGestion<T>(IBaseRepository Service,BaseEntryForm formulaire) where T : BaseEntity
        {
            EntityManagementForm form = new EntityManagementForm(Service, formulaire, null, this.FormApplicationMdi);
            this.Afficher(form);
        }

        /// <summary>
        /// Affichage d'une formulaire de Type : Form
        /// </summary>
        /// <param name="f">Le controle Form à afficher </param>
        public void Afficher(Form addForm)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form form = FormApplicationMdi.MdiChildren.Where(f => f.Name == addForm.Name).FirstOrDefault();
            if (form == null)
            {
                addForm.MdiParent = FormApplicationMdi;
                addForm.StartPosition = FormStartPosition.CenterScreen;
                addForm.WindowState = FormWindowState.Maximized;
                addForm.Show();
            }
            else
            {
                form.WindowState = FormWindowState.Normal;

            }

            Cursor.Current = Cursors.Default;
        }
    }
}
