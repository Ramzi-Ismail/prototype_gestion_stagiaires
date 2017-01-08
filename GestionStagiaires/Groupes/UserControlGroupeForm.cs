using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using App.WinForm;

namespace App.GestionStagiaires.Groupes
{
    public partial class UserControlGroupeForm : FormUserControl
    {
        public UserControlGroupeForm(IBaseRepository service):base(service)
        {
            InitializeComponent();
            this.Service = service;
        }
        /// <summary>
        /// Ce constructeur est utiliser par le ModeDesign de Visual Studio
        /// </summary>
        public UserControlGroupeForm() : base()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Création d'une nouvelle instance de cette formulaire
        /// #recherche : généralisation de la création des instances
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public override FormUserControl CreateInstance(IBaseRepository service)
        {
            return new UserControlGroupeForm(service);
        }
        public override BaseEntity CreateObjetInstance()
        {
            return new Groupe();
        }

        private void UserControlGroupeForm_Load(object sender, EventArgs e)
        {
            comboBoxFiliere.DataSource = new FilieresService(Service.Context()).ToBindingList();
        }


        public override void Afficher()
        {
            Groupe groupe = (Groupe) this.Entity;
            nomTextBox.Text = groupe.Nom;
            comboBoxFiliere.SelectedItem = groupe.Filiere;
        }
        protected override void Lire()
        {
            Groupe groupe = (Groupe)this.Entity;
            groupe.Nom = nomTextBox.Text;
            groupe.Filiere = new FilieresService(Service.Context()).
                GetByID(((Filiere)comboBoxFiliere.SelectedItem).Id) ;


        }


    }
}
