using App.WinForm.Annotation;
using App.WinForm.EntityManagement;
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

        private void EntityManagementForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                this.Actualiser();
        }


        #region Initialisation
        /// <summary>
        /// Initialisation et Création des controles
        /// </summary>
        /// <param name="service"></param>
        /// <param name="formulaire"></param>
        protected void initControls()
        {
            //
            // TabControlManager, il contient tous les autres manager
            //
            this.tabControl_MainManager.Dock = DockStyle.Fill;
            this.tabControlManagers.Visible = false;
            this.panelDataGrid.Controls.Add(this.tabControl_MainManager);
            //
            // Formulaire
            //
            if (this.Formulaire == null)
                this.Formulaire = new EntryForm(this.Service);
            //
            // Filtre
            //
            if (this.FilterControl == null)
            {
                this.FilterControl = new EntityFilterControl(this.Service, this.ValeursFiltre);
            }
            this.FilterControl.Dock = DockStyle.Fill;
            this.panel_Filtre.Controls.Add(this.FilterControl);
            this.FilterControl.RefreshEvent += BaseFilterControl_RefreshEvent;
          
            //
            // DataGrid
            //
            if (this.DataGridControl == null)
                this.DataGridControl = new EntityDataGridControl(this.Service, this.ValeursFiltre);
            this.DataGridControl.Dock = DockStyle.Fill;
            this.tabControl_MainManager.TabPages["TabGrid"].Controls.Add(this.DataGridControl);
            this.DataGridControl.EditClick += EntityDataGridControl_EditClick;
            this.DataGridControl.EditManyToOneCollection += DataGridControl_EditManyToOneCollection;
            this.DataGridControl.EditManyToManyCollection += DataGridControl_EditManyToManyCollection;
            //
            // Modification des Titre 
            //
            AffichageDansFormGestionAttribute AffichageDansFormGestion = this.Service.getAffichageDansFormGestionAttribute();
            this.Name = "Interface_Gestion_" + this.Service.TypeEntity.ToString();
            this.Text = AffichageDansFormGestion.Titre;
            this.bt_Ajouter.Text = AffichageDansFormGestion.TitreButtonAjouter;
            lbl_titre_gestion.Text = AffichageDansFormGestion.Titre;
            this.tabControl_MainManager.TabPages["TabGrid"].Text = AffichageDansFormGestion.TitrePageGridView;
        }
        protected void RenomerTitrePage(Dictionary<string, object> critereRechercheFiltre)
        {
            // Renommer le Titre de la page
            lbl_titre_gestion.Text = this.Text;
            if (critereRechercheFiltre != null && critereRechercheFiltre.Count() > 0)
            {
                lbl_titre_gestion.Text += " par ( ";
                lbl_titre_gestion.Text += string.Join(",", critereRechercheFiltre.Select(d => d.Key));
                lbl_titre_gestion.Text += " )";
            }

        }
        #endregion
    }
}
