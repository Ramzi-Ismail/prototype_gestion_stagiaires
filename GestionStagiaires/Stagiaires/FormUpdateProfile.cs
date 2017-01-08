using App;
using App.GestionStagiaires;
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
    public partial class FormUpdateProfile : Form
    {
        FormStagiaireUC formStagiaire;
        IBaseRepository Service;

        public FormUpdateProfile()
        {
            InitializeComponent();
           
        }

        private void FormUpdateProfile_Load(object sender, EventArgs e)
        {
            this.Service = new StagiairesService();
            formStagiaire = new FormStagiaireUC(Service);
            this.Controls.Add(formStagiaire);
            formStagiaire.Entity =(Stagiaire)App.Session.user;
            formStagiaire.Afficher();
            formStagiaire.EnregistrerClick += FormStagiaire_EnregistrerClick;
            formStagiaire.AnnulerClick += FormStagiaire_AnnulerClick;

        }

        private void FormStagiaire_AnnulerClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormStagiaire_EnregistrerClick(object sender, EventArgs e)
        {
            Service.Save((Stagiaire) formStagiaire.Entity);
            this.Close();
        }
    }
}
