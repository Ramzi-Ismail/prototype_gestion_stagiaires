using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.WinForm;
using App.GestionFormations;
using App.Formations;

namespace App.GestionStagiaires.Formateurs
{
    public partial class FormateurFormUC : BaseEntryForm
    {
        public FormateurFormUC(IBaseRepository service) :base(service)
        {
            InitializeComponent();
            this.Service = service;
        }
     
        private void FormateurFormUC_Load(object sender, EventArgs e)
        {
            // ces deux linge ont provoquer une erreur lors de l'insertion 
            // de user controler depuis la boite d'outils 
            // si il sont dans la méthode Load
            // Impossible de cérer le composant 
            //la chîne de connexion est introuvable dans le fichier de configuration de l'application
            filiereBindingSource.DataSource = new FilieresService(this.context).GetAll();

        }


        public override void Afficher()
        {
            Formateur Stagiaire = (Formateur)this.Entity;
            bool validation = true;

            // Création d'un stagiaire en cas d'un nouvelle enregistrement
            if (Stagiaire == null) Stagiaire = new Formateur();

            // Etat civil
            nomTextBox.Text = Stagiaire.Nom;
            prenomTextBox.Text = Stagiaire.Prenom;
            cinTextBox.Text = Stagiaire.Cin;
            if (Stagiaire.Sexe)
            {
                radioButtonHomme.Checked = true;
            }
            else
            {
                radioButtonFamme.Checked = true;
            }
            dateNaissanceDateTimePicker.Value = Stagiaire.DateNaissance;

            // Coordonnées
            telephoneTextBox.Text = Stagiaire.Telephone;
            adressTextBox.Text = Stagiaire.Adress;
            emailTextBox.Text = Stagiaire.Email;

            // Affectation
            Combo_Filiere.SelectedItem = Stagiaire.Filiere;
           

 

        }
        protected override void Lire()
        {
            Formateur Stagiaire = (Formateur)this.Entity;
            bool validation = true;
            // etat Civil
            Stagiaire.Nom = nomTextBox.Text;
            Stagiaire.Prenom = prenomTextBox.Text;
            Stagiaire.Cin = cinTextBox.Text;
            Stagiaire.Sexe = radioButtonHomme.Checked;
            Stagiaire.DateNaissance = dateNaissanceDateTimePicker.Value;



            //Coordonnées
            Stagiaire.Telephone = telephoneTextBox.Text;
            Stagiaire.Adress = adressTextBox.Text;
            Stagiaire.Email = emailTextBox.Text;

            

            if (Combo_Filiere.SelectedItem != null)
                Stagiaire.Filiere = (Filiere)Combo_Filiere.SelectedItem;

            //Identification
            Stagiaire.Login = txt_login.Text;
            Stagiaire.Password = txt_password.Text;
            if (txt_password.Text != txt_password2.Text) validation = false;


            
        }

        public override BaseEntryForm CreateInstance(IBaseRepository service)
        {
            return new FormateurFormUC(service);
        }
        public override BaseEntity CreateObjetInstance()
        {
            return new Formateur();
        }
    }
}
