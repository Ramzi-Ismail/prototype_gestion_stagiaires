using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.GestionStagiaires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.WinFrom.Menu;
using App.WinForm;
using App;

namespace App.GestionStagiaires.Tests
{
    [TestClass()]
    public class StagiaireEntryFormTests
    {
        [TestMethod()]
        public void StagiaireEntryFormTest()
        {
            Form form = new Form();
            form.IsMdiContainer = true;

            // Tester tous les bouttons ajouter 
            using (ModelContext db = new ModelContext())
            {
               AfficherFormHelper AfficherFormulaire = new AfficherFormHelper(form);
               ObsoleteEntityManagementForm emform = AfficherFormulaire
                    .AfficherUneGestion<Stagiaire>(new StagiaireEntryForm(new BaseRepository<Stagiaire>()));
               emform.bt_Ajouter_Click(new Button(), null);
            }
        }

     
    }
}