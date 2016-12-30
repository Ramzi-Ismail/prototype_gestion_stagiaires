using AppGestionStagiaires.GestionProjets;
using AppGestionStagiaires.GestionStagiaires;
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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void binfingNavigatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormBinfingNavigator().Show();
        }

        private void gestionStagiaires_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FormGestionStagiaires f = new FormGestionStagiaires();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
            Cursor.Current = Cursors.Default;

        }

        private void projetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FormGestionProjets f = new FormGestionProjets();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
            Cursor.Current = Cursors.Default;

           
        }
    }
}
