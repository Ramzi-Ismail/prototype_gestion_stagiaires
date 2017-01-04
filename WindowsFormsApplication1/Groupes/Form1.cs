

using App.Entites;
using EFlib.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Groupes
{
    public partial class Form1 : App.WinFrom.GestionBinfingNavigator.FormGestionBindingNavigator<Groupe>
    {
        public Form1()
        {
            BaseEntity s = new BaseEntity();

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
