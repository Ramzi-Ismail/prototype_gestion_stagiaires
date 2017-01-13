using App.WinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm
{
    partial class InterfaceGestion
    {
        /// <summary>
        /// Boutton Ajouter
        /// </summary>
        private void bt_Ajouter_Click(object sender, EventArgs e)
        {

            // Insertion du formulaire Si la page TabAjouter n'existe pas
            if (tabControl.TabPages.IndexOfKey("TabAjouter") == -1)
            {
                // 
                // Création de TabPage - Ajouter 
                //
                TabPage tabAjouter = new TabPage();
                tabAjouter.Text = this.Service.getAffichageDansFormGestionAttribute().TitreButtonAjouter;
                tabAjouter.Name = "TabAjouter";
                tabControl.TabPages.Add(tabAjouter);
                tabControl.CausesValidation = false;

                //
                // Insertion du formulaire 
                //
                BaseFormulaire form = Formulaire.CreateInstance(Service);
                form.Entity = (BaseEntity) this.Service.CreateInstanceObjet();
                form.Name = "Form";
                form.Dock = DockStyle.Fill;
                form.Afficher(this.CritereRechercheFiltre()); // Affichage des valeur initial
                form.InitValeurFromFiltre(this.CritereRechercheFiltre());
                 
                this.tabControl.TabPages["TabAjouter"].Controls.Add(form);
                tabControl.SelectedTab = tabAjouter;
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
            BaseFormulaire form = (BaseFormulaire)tabAjouter.Controls
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
