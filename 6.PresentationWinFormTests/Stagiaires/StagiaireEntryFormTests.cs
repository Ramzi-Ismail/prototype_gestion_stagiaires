﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void bt_Ajouter_Click_Test()
        {
            Form form = new Form();
            form.IsMdiContainer = true;

            // Tester tous les bouttons ajouter 
            using (ModelContext db = new ModelContext())
            {
               ShowEntityManagementForm AfficherFormulaire = new ShowEntityManagementForm(form);
               EntityManagementForm emform = AfficherFormulaire
                    .AfficherUneGestion<Stagiaire>(new StagiaireEntryForm(new BaseRepository<Stagiaire>()));
                emform.EntityManagementControl.bt_Ajouter_Click(new Button(), null);
            }
        }

     
    }
}