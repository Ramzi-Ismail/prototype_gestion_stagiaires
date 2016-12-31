using AppGestionStagiaires.Authentification;
using Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGestionStagiaires.GestionStagiaires
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
            Stagiaire s = StagiaireForm.Stagiaire;
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
