using App.WinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm
{
    partial class FormGestionTabPage
    {
        private void bt_Ajouter_Click(object sender, EventArgs e)
        {

            // Insertion du formulaire Si la page TabAjouter n'existe pas
            if (tabControl.TabPages.IndexOfKey("TabAjouter") == -1)
            {
                // Création de Tab
                TabPage tabAjouter = new TabPage();
                string NomObjet = Service.GetNomObjet();
                tabAjouter.Text = "Ajouter :" + NomObjet;
                tabAjouter.Name = "TabAjouter";
                tabControl.TabPages.Add(tabAjouter);
                tabControl.SelectedTab = tabAjouter;

                // Insertion du formulaire 
                FormUserControl form = Formulaire.CreateInstance(Service);
                form.Entity = Formulaire.CreateObjetInstance();
                form.Name = "Form";
                this.tabControl.TabPages["TabAjouter"].Controls.Add(form);
                form.EnregistrerClick += Form_EnregistrerClick;
                form.AnnulerClick += Form_AnnulerAjouterClick;
            }
        }
        /// <summary>
        /// Enregistrer un Stagiaire
        /// </summary>
        private void Form_EnregistrerClick(object sender, EventArgs e)
        {
            TabPage tabAjouter = this.tabControl.TabPages["TabAjouter"];
            FormUserControl form = (FormUserControl)tabAjouter.Controls
                .Find("Form", false).First();
            this.tabControl.TabPages.Remove(tabAjouter);
            this.Actualiser();
        }
        /// <summary>
        /// Annuler l'insertion d'un stagiaire
        /// </summary>
        private void Form_AnnulerAjouterClick(object sender, EventArgs e)
        {
            TabPage tabAjouter = this.tabControl.TabPages["TabAjouter"];
            tabControl.TabPages.Remove(tabAjouter);
        }
    }
}
