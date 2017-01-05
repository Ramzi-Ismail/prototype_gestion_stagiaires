using App.Entites;
using EFlib.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Gestion
{
    public partial class FormGestion : Form
    {
        /// <summary>
        /// Le nom de l'obet en pluriel
        /// </summary>
        private string NomObjetPluriel;

        /// <summary>
        /// L'instance du Contôle d'affichage des objets
        /// </summary>
        private BaseGridUC GrideUC { set; get; }
        public FormGestion()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructeur  
        /// </summary>
        /// <param name="NomObjetPluriel">Le nom l'objet en pluriel</param>
        /// <param name="grideUC"></param>
        public FormGestion(string nomObjetPluriel = "Informations", BaseGridUC grideUC = null)
        {
           
            InitializeComponent();
            this.NomObjetPluriel = nomObjetPluriel;
            this.Text = "Gestion des " + nomObjetPluriel;
            this.GrideUC = grideUC;
            
        }

  
        
        private void FormGestion_Load(object sender, EventArgs e)
        {
            // Insertion de DataGridPersonnelle
            if (GrideUC != null) {
                TabPage tabGrid = new TabPage();
                tabGrid.Name = "TabGrid";
                tabGrid.Text = NomObjetPluriel;
                tabGrid.Controls.Add((UserControl)GrideUC);
                GrideUC.EditerEvent += GrideUC_EditerEvent;
                tabControl.Controls.Add(tabGrid);
                GrideUC.Actualiser();
            }

        }
        #region Editer Un objet
        private void GrideUC_EditerEvent(object sender, EventArgs e)
        {
            BaseEntity entity = GrideUC.Current();
            string tabEditerName = "TabEditer-" + entity.Id;

            if (tabControl.TabPages.IndexOfKey(tabEditerName) == -1)
            {
                // Création de Tab
                TabPage tabEditer = new TabPage();
                tabEditer.Text = entity.ToString();
                tabEditer.Name = tabEditerName;
                tabControl.TabPages.Add(tabEditer);
                tabControl.SelectedTab = tabEditer;

                // Insertion du formulaire 

                T form = Activator.CreateInstance<T>();
                form.Name = "EntityForm";
                form.Entity = entity;
                form.Afficher();
                this.tabControl.TabPages[tabEditerName].Controls.Add(form);
                form.EnregistrerClick += Form_EditerClick;
                form.AnnulerClick += Form_AnnulerEditerClick;
            }

        }
        private void Form_EditerClick(object sender, EventArgs e)
        {
            T form = (T) sender;
            BaseEntity entity = form.Entity;
            string tabEditerName = "TabEditer-" + entity.Id;
            TabPage tabEditer = this.tabControl.TabPages[tabEditerName];
            // Suppression de la page Editer
            this.tabControl.TabPages.Remove(tabEditer);
            this.GrideUC.Actualiser();
        }

        private void Form_AnnulerEditerClick(object sender, EventArgs e)
        {
            T form = (T)sender;
            BaseEntity entity = form.Entity;
            string tabEditerName = "TabEditer-" + entity.Id;
            TabPage tabEditer = this.tabControl.TabPages[tabEditerName];
            tabControl.TabPages.Remove(tabEditer);
        }
        #endregion

        #region Ajouter Objet
        private void bt_Ajouter_Click(object sender, EventArgs e)
        {
            // Insertion du formulaire Si la page TabAjouter n'existe pas
            if (tabControl.TabPages.IndexOfKey("TabAjouter") == -1)
            {
                // Création de Tab
                TabPage tabAjouter = new TabPage();
                tabAjouter.Text = "Ajouter un stagiaire";
                tabAjouter.Name = "TabAjouter";
                tabControl.TabPages.Add(tabAjouter);
                tabControl.SelectedTab = tabAjouter;

                // Insertion du formulaire 
                T form = Activator.CreateInstance<T>();
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
            T form = (T)tabAjouter.Controls
                .Find("Form", false).First();
            this.tabControl.TabPages.Remove(tabAjouter);
            this.GrideUC.Actualiser();
        }
        /// <summary>
        /// Annuler l'insertion d'un stagiaire
        /// </summary>
        private void Form_AnnulerAjouterClick(object sender, EventArgs e)
        {
            TabPage tabAjouter = this.tabControl.TabPages["TabAjouter"];
            tabControl.TabPages.Remove(tabAjouter);
        }
        #endregion

        private void FormGestion_Resize(object sender, EventArgs e)
        {
            this.tabControl.Location = new Point(10, 50);
        }

        private void dataGridViewStagiaires_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
