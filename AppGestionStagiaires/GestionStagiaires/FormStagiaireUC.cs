using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entites;
using AppGestionStagiaires.GestionFilieres;
using AppGestionStagiaires.GestionGroupes;

namespace AppGestionStagiaires.GestionStagiaires
{
    public partial class FormStagiaireUC : UserControl
    {
        public FormStagiaireUC()
        {
            InitializeComponent();
        }


        public event EventHandler EnregistrerClick;
        public event EventHandler AnnulerClick;

        
        /// <summary>
        /// Lire ou obtient le stagiaire 
        /// </summary>
        public Stagiaire Stagiaire { set; get; }
          

        private void FormStagiaireUC_Load(object sender, EventArgs e)
        {
            filiereBindingSource.DataSource = new FilieresService().Liste();
            groupeBindingSource.DataSource = new GroupesService().Liste();
        }

        /// <summary>
        /// Afficher l'objet stagiaire dans l'interface
        /// </summary>
        public void AfficherStagiaire()
        {
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
            Combo_groupe.SelectedItem = Stagiaire.Groupe;
        }

        // Enregistrer ou Modifier un Stagiaire
        private void br_enregistrer_Click(object sender, EventArgs e)
        {
            // Création d'un stagiaire en cas d'un nouvelle enregistrement
            if (this.Stagiaire == null) Stagiaire = new Stagiaire();

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
            EnregistrerClick(this, e);
        }

        private void bt_annuler_Click(object sender, EventArgs e)
        {
            AnnulerClick(this, e);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
