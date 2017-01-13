using App.WinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinFrom.Menu
{
    public class AfficherForm
    {
        Form Parent { set; get; }
        public AfficherForm(Form Parent)
        {
            this.Parent = Parent;
        }

        public void AfficherUneGestion<T>() where T : BaseEntity
        {
            InterfaceGestion form = new InterfaceGestion(new BaseRepository<T>());
            this.Afficher(form);
        }

        public void AfficherUneGestion<T>(IBaseRepository Service) where T : BaseEntity
        {
            InterfaceGestion form = new InterfaceGestion(Service);
            this.Afficher(form);
        }

        /// <summary>
        /// Afficher une gestion avec une formulaire spécifique
        /// </summary>
        /// <typeparam name="T">L'objet à gérer</typeparam>
        /// <param name="formulaire">Le Formulaire spécifique</param>
        public void AfficherUneGestion<T>(BaseFormulaire formulaire) where T : BaseEntity
        {
            InterfaceGestion form = new InterfaceGestion(new BaseRepository<T>(), formulaire);
            this.Afficher(form);
        }

        /// <summary>
        /// Affichage d'une formulaire de Type : Form
        /// </summary>
        /// <param name="f">Le controle Form à afficher </param>
        public void Afficher(Form addForm)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form form = Parent.MdiChildren.Where(f => f.Name == addForm.Name).FirstOrDefault();
            if (form == null)
            {
                addForm.MdiParent = Parent;
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
