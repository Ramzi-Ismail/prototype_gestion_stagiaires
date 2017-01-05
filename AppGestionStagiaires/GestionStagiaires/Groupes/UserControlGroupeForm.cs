using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using App.Gestion;
using App.WinFromLib.FormUC;
using App.Entites;
using EFlib.Entites;
using EFlib;

namespace App.GestionStagiaires.Groupes
{
    public partial class UserControlGroupeForm : BaseFormUserControl
    {
        public UserControlGroupeForm(IBaseRepository service):base()
        {
            InitializeComponent();
            this.Service = service;


        }

        public override BaseFormUserControl CreateInstance(IBaseRepository service)
        {
            return new UserControlGroupeForm(service);
        }
        public override BaseEntity CreateObjetInstance()
        {
            return new Groupe();
        }

        private void UserControlGroupeForm_Load(object sender, EventArgs e)
        {
            comboBoxFiliere.DataSource = new FilieresService().GetAll();
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
            groupe.Filiere =(Filiere) comboBoxFiliere.SelectedItem;
        }


    }
}
