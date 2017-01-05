using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Gestion;
using App.Entites;
using App.GestionFormateurs;

namespace App.GestionStagiaires.Formateurs
{
    public partial class FormateurFormUC : BaseFormUC
    {
        public FormateurFormUC()
        {
            InitializeComponent();
        }

        private void FormateurFormUC_Load(object sender, EventArgs e)
        {
            // ces deux linge ont provoquer une erreur lors de l'insertion 
            // de user controler depuis la boite d'outils 
            // si il sont dans la méthode Load
            // Impossible de cérer le composant 
            //la chîne de connexion est introuvable dans le fichier de configuration de l'application
            filiereBindingSource.DataSource = new FilieresService().GetAll();

        }

        private void br_enregistrer_Click(object sender, EventArgs e)
        {
            Formateur Stagiaire = (Formateur)this.Entity;
            bool validation = true;

            // Création d'un stagiaire en cas d'un nouvelle enregistrement
            if (Stagiaire == null) Stagiaire = new Formateur();

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

            //Affectation
            

            if (Combo_Filiere.SelectedItem != null)
                Stagiaire.Filiere = (Filiere)Combo_Filiere.SelectedItem;

            //Identification
            Stagiaire.Login = txt_login.Text;
            Stagiaire.Password = txt_password.Text;
            if (txt_password.Text != txt_password2.Text) validation = false;

            // Lancement de l'événement Clic si la validation est correct
            if (validation)
            {
                if (new FormateursService().Save(Stagiaire) > 0)
                {
                    MessageBox.Show("Le Stagiaire :" + Stagiaire.ToString() + " a été bien enregistrer");
                }
                else
                {
                    MessageBox.Show("Le Stagiaire :" + Stagiaire.ToString() + " n'est pas enregistrer car il n'y a pas des modifications");
                }
                onEnregistrerClick(this, e);
            }
            else
                MessageBox.Show("Le mote de passe n'est pas correct");
        }

        private void bt_annuler_Click(object sender, EventArgs e)
        {
            onAnnulerClick(this, e);
        }
        /// <summary>
        /// Afficher l'objet formateur dans l'interface
        /// </summary>
        public override void Afficher()
        {
            Formateur formateur = (Formateur)this.Entity;
            // Etat civil
            nomTextBox.Text = formateur.Nom;
            prenomTextBox.Text = formateur.Prenom;
            cinTextBox.Text = formateur.Cin;
            if (formateur.Sexe)
            {
                radioButtonHomme.Checked = true;
            }
            else
            {
                radioButtonFamme.Checked = true;
            }
            dateNaissanceDateTimePicker.Value = formateur.DateNaissance;

            // Coordonnées
            telephoneTextBox.Text = formateur.Telephone;
            adressTextBox.Text = formateur.Adress;
            emailTextBox.Text = formateur.Email;

            // Affectation
            Combo_Filiere.SelectedItem = formateur.Filiere;
        }
    }
}
