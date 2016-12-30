using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGestionStagiaires
{
    public partial class FormMenuStagiaire : Form
    {
        public FormMenuStagiaire()
        {
            InitializeComponent();
        }

        private void FormMenuStagiaire_Load(object sender, EventArgs e)
        {
            this.Text = Authentification.Authentification.user.ToString();
        }

        private void FormMenuStagiaire_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
