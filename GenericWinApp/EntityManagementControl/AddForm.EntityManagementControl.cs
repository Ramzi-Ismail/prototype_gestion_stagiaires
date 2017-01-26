using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm
{
    public partial class EntityManagementControl
    {
        #region Formulaire
        /// <summary>
        /// Boutton Ajouter un nouveau entité
        /// </summary>
        public void bt_Ajouter_Click(object sender, EventArgs e)
        {

            // Insertion de la page TabAjouter s'il n'existe pas
            if (tabControl_MainManager.TabPages.IndexOfKey("TabAjouter") == -1)
            {
                // 
                // Création de TabPage - Ajouter 
                //
                TabPage tabAjouter = new TabPage();
                tabAjouter.Text = this.Service.getAffichageDansFormGestionAttribute().TitreButtonAjouter;
                tabAjouter.Name = "TabAjouter";
                tabControl_MainManager.TabPages.Add(tabAjouter);
                tabControl_MainManager.CausesValidation = false;

                //
                // Insertion du formulaire 
                //
                BaseEntity Entity = (BaseEntity)this.Service.CreateInstanceObjet();
                BaseEntryForm form = Formulaire.CreateInstance(Service, Entity, this.FilterControl.CritereRechercheFiltre());
                form.Name = "Form";
                form.Dock = DockStyle.Fill;
                form.WriteEntityToField(this.FilterControl.CritereRechercheFiltre());


                this.tabControl_MainManager.TabPages["TabAjouter"].Controls.Add(form);
                tabControl_MainManager.SelectedTab = tabAjouter;
                form.EnregistrerClick += Form_EnregistrerClick;
                form.AnnulerClick += Form_AnnulerAjouterClick;
            }
        }
        /// <summary>
        /// Enregistrer un Stagiaire
        /// </summary>
        private void Form_EnregistrerClick(object sender, EventArgs e)
        {
            TabPage tabAjouter = this.tabControl_MainManager.TabPages["TabAjouter"];
            BaseEntryForm form = (BaseEntryForm)tabAjouter.Controls
                .Find("Form", false).First();
            this.tabControl_MainManager.TabPages.Remove(tabAjouter);
            this.Actualiser();
        }
        /// <summary>
        /// Annuler l'insertion d'un stagiaire
        /// </summary>
        private void Form_AnnulerAjouterClick(object sender, EventArgs e)
        {
            TabPage tabAjouter = this.tabControl_MainManager.TabPages["TabAjouter"];
            tabControl_MainManager.TabPages.Remove(tabAjouter);
        }


        #endregion
    }
}
