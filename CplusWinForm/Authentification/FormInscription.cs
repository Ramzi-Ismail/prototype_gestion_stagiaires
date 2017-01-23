using App.Authentification;
using System;
using System.Windows.Forms;

namespace App.GestionStagiaires
{
    public partial class FormInscription : Form
    {
        StagiaireEntryForm StagiaireForm;
        StagiairesService Service;
        public FormInscription()
        {

            InitializeComponent();
            Service = new StagiairesService();
            StagiaireForm = new StagiaireEntryForm(Service);
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
            Session.user = s;
            this.Hide();
            new FormAuthentification().ShowMenu(Session.user,this);
        }

        private void FormInscription_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
