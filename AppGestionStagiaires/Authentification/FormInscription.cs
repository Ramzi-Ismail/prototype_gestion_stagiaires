using Cplus.Authentification;
using Cplus.Entites;
using System;
using System.Windows.Forms;

namespace Cplus.GestionStagiaires
{
    public partial class FormInscription : Form
    {
        FormStagiaireUC StagiaireForm = new FormStagiaireUC();
        public FormInscription()
        {
            InitializeComponent();
        }

        private void FormInscription_Load(object sender, EventArgs e)
        {
            
            this.Controls.Add(StagiaireForm);

            StagiaireForm.EnregistrerClick += StagiaireForm_EnregistrerClick;
        }

        private void StagiaireForm_EnregistrerClick(object sender, EventArgs e)
        {
            // Inscription d'un Stagiaire
            Stagiaire s =(Stagiaire) StagiaireForm.Entity;
            new StagiairesService().Save(s);
            Authentification.Authentification.user = s;
            this.Hide();
            new FormAuthentification().ShowMenu(Authentification.Authentification.user,this);
        }

        private void FormInscription_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
