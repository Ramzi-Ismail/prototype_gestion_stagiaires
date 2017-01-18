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

namespace App.GestionStagiaires
{
    public partial class StagiaireEntryForm : BaseEntryForm
    {
        public StagiaireEntryForm(IBaseRepository service) :base(service)
        {
            InitializeComponent();
            this.ConteneurFormulaire = splitContainer1.Panel1;
        }
        public StagiaireEntryForm(IBaseRepository service, BaseEntity entity, Dictionary<string, object> critereRechercheFiltre) : base(service, entity, critereRechercheFiltre)
        {
            InitializeComponent();
        }



        public override BaseEntity CreateObjetInstance()
        {
            return new Stagiaire();
        }



        private void StagiaireEntryForm_Load(object sender, EventArgs e)
        {
            filiereBindingSource.DataSource = new FilieresService(Service.Context()).GetAll();
            groupeBindingSource.DataSource = new GroupesService(Service.Context()).GetAll();
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
            filiereComboBox.SelectedItem = Stagiaire.Filiere;
            groupeComboBox.SelectedItem = Stagiaire.Groupe;
        }

       
        protected override void Lire()
        {
         
                Stagiaire Stagiaire = (Stagiaire)this.Entity;
                bool validation = true;

            // Création d'un stagiaire avec proxy en cas d'un nouvelle enregistrement
            if (Stagiaire == null) Stagiaire = this.context.Stagiaires.Create();

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
                if (groupeComboBox.SelectedItem != null) {
                Groupe g    = new GroupesService(this.Service.Context()).GetByID(Convert.ToInt32(groupeComboBox.SelectedValue));
                Stagiaire.Groupe = g;
                 }

            if (filiereComboBox.SelectedItem != null)
                    Stagiaire.Filiere = new FilieresService(this.Service.Context()).GetByID(Convert.ToInt32(filiereComboBox.SelectedValue));

                //Identification
                Stagiaire.Login = txt_login.Text;
                Stagiaire.Password = txt_password.Text;
                if (txt_password.Text != txt_password2.Text) validation = false;
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

        private void br_enregistrer_Click(object sender, EventArgs e)
        {

        }
    }
}
