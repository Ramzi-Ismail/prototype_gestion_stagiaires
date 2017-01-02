using App.GestionStagiaires;
using App.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Authentification
{
    public partial class FormAuthentification : Form
    {
        public FormAuthentification()
        {
            InitializeComponent();
        }

        private void FormAuthentification_Load(object sender, EventArgs e)
        {

        }

        private void Connexion_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Utilisateur user = new Authentification().Connexion(txt_login.Text, txt_password.Text);

            if (user != null)
            {
                Session.user = user;
                this.ShowMenu(user,this);

            }
            else
            {
                MessageBox.Show("Votre login ou mot de passe est incorrect");
            }

        }
        /// <summary>
        /// Ouvire le menu de l'utilisateur selon son rôle
        /// </summary>
        /// <param name="user">l'utilisateur connecter</param>
        /// <param name="form">Le formulaire encours d'exécution</param>
        public void ShowMenu(Utilisateur user,Form form)
        {
            if (user.role == Utilisateur.ROLE_ADMIN)
            {
                new FormMenu().Show();
                form.Hide();
            }
            else
            {
                new FormMenuStagiaire().Show();
                form.Hide();
            }
        }

        private void linkLabel_Inscription_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FormInscription().Show();
            this.Hide();
        }


    }
}
