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

namespace App.GestionStagiaires
{
    public partial class FormStagiaireUC : BaseFormUC
    {
        public FormStagiaireUC()
        {
            InitializeComponent();
            // ces deux linge ont provoquer une erreur lors de l'insertion 
            // de user controler depuis la boite d'outils 
            // si il sont dans la méthode Load
            // Impossible de cérer le composant 
            //la chîne de connexion est introuvable dans le fichier de configuration de l'application
           
        }
        private void Validation()
        {

        }




        private void FormStagiaireUC_Load(object sender, EventArgs e)
        {
            filiereBindingSource.DataSource = new FilieresService().GetAll();
            groupeBindingSource.DataSource = new GroupesService().GetAll();
        }

        /// <summary>
        /// Afficher l'objet stagiaire dans l'interface
        /// </summary>
        public override void Afficher()
        {
            Stagiaire Stagiaire = (Stagiaire)this.Entity;
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

            //Sécurité
            txt_login.Text = Stagiaire.Login;
            txt_password.Text = Stagiaire.Password;
            txt_password2.Text = Stagiaire.Password;

            // Affectation
            Combo_Filiere.SelectedItem = Stagiaire.Filiere;
            Combo_groupe.SelectedItem = Stagiaire.Groupe;
        }

        // Enregistrer ou Modifier un Stagiaire
        private void br_enregistrer_Click(object sender, EventArgs e)
        {
            if (ValidationManager.hasValidationErrors(this.Controls))
                return;


        

                Stagiaire Stagiaire = (Stagiaire)this.Entity;
                bool validation = true;

                // Création d'un stagiaire en cas d'un nouvelle enregistrement
                if (Stagiaire == null) Stagiaire = new Stagiaire();

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
                if (Combo_groupe.SelectedItem != null)
                    Stagiaire.Groupe = (Groupe)Combo_groupe.SelectedItem;

                if (Combo_Filiere.SelectedItem != null)
                    Stagiaire.Filiere = (Filiere)Combo_Filiere.SelectedItem;

                //Identification
                Stagiaire.Login = txt_login.Text;
                Stagiaire.Password = txt_password.Text;
                if (txt_password.Text != txt_password2.Text) validation = false;

                // Lancement de l'événement Clic si la validation est correct
                if (validation)

                {
                     

                    if (new StagiairesService().Save(Stagiaire) > 0)
                    {
                        MessageBox.Show("Le Stagiaire :" + Stagiaire.ToString() + " a été bien enregistrer");
                    this.Entity = Stagiaire;
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void nomTextBox_TextChanged(object sender, EventArgs e)
        {
            //// Determine if the TextBox has a digit character.
            //string text = nomTextBox.Text;
            //bool hasDigit = false;
            //foreach (char letter in text)
            //{
            //    if (char.IsDigit(letter))
            //    {
            //        hasDigit = true;
            //        break;
            //    }
            //}
            //// Call SetError or Clear on the ErrorProvider.
            //if (!hasDigit)
            //{
            //    errorProvider1.SetError(nomTextBox, "Needs to contain a digit");
            //}
            //else
            //{
            //    errorProvider1.Clear();
            //}
        }

      

        private void nomTextBox_Validating(object sender, CancelEventArgs e)
        {
            this.ValiderTextBox(sender, e, errorProvider1);
        }

        private void prenomTextBox_Validating(object sender, CancelEventArgs e)
        {
            this.ValiderTextBox(sender, e, errorProvider1);
        }

        private void cinTextBox_Validating(object sender, CancelEventArgs e)
        {
            this.ValiderTextBox(sender, e, errorProvider1);
        }

        private void txt_login_Validating(object sender, CancelEventArgs e)
        {
            //Le login doit être unique 

            this.ValiderTextBox(sender, e, errorProvider1);
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void telephoneTextBox_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void telephoneTextBox_Validating(object sender, CancelEventArgs e)
        {
            this.ValiderTextBox(sender, e, errorProvider1);
        }

        private void txt_password2_Validating(object sender, CancelEventArgs e)
        {
            this.ValiderTextBox(sender, e, errorProvider1);
        }

        private void txt_password_Validating(object sender, CancelEventArgs e)
        {
            this.ValiderTextBox(sender, e, errorProvider1);
        }

        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {
            this.ValiderTextBox(sender, e, errorProvider1);
        }

        private void txt_login_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
