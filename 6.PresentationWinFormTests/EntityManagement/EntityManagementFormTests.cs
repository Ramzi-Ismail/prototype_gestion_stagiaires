using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.WinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.WinFrom.Menu;
using App.GestionProjets;
using System.Windows.Forms;
using App.Modules;

namespace App.WinForm.Tests
{
    [TestClass()]
    public class EntityManagementFormTests
    {


        //[ClassInitialize()]
        //public void m1() { }

        //[ClassCleanup()]
        //public void m2() { }

        /// <summary>
        /// Test : Affichage des formilaires par son type
        /// Test : bt_Ajouter_Clic de chaque formulaire
        /// </summary>
        [TestMethod()]
        public void bt_Ajouter_ClickTest()
        {
            Form form = new Form();
            form.IsMdiContainer = true;

            // Tester tous les bouttons ajouter 
            using (ModelContext db = new ModelContext())
            {
                foreach (var item in db.GetTypesSets())
                {
                    ShowEntityManagementForm AfficherFormulaire = new ShowEntityManagementForm(form);
                    EntityManagementForm emform = AfficherFormulaire.AfficherUneGestion(item);
                    emform.EntityManagementControl.bt_Ajouter_Click(new Button(), null);
                }
            }
        }

        [TestMethod()]
        public void Editer_Click()
        {

            Form form = new Form();
            form.IsMdiContainer = true;

            // Tester tous les bouttons ajouter 
            using (ModelContext db = new ModelContext())
            {
                foreach (var item in db.GetTypesSets())
                {
                    ShowEntityManagementForm AfficherFormulaire = new ShowEntityManagementForm(form);
                    EntityManagementForm emform = AfficherFormulaire.AfficherUneGestion(item);
                    emform.EntityManagementControl.bt_Ajouter_Click(new Button(), null);
                }
            }
        }

    }
}