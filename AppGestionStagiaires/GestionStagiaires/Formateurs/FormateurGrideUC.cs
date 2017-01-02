using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cplus.Gestion;
using Cplus.Entites;
using Cplus.GestionFormateurs;

namespace Cplus.GestionStagiaires.Formateurs
{
    public partial class FormateurGrideUC : BaseGridUC
    {
        public FormateurGrideUC()
        {
            InitializeComponent();
            this.OBjetBindingSource = formateurBindingSource;
        }

        public override void Actualiser()
        {
            this.OBjetBindingSource.Clear();
            this.OBjetBindingSource.DataSource = new FormateursService().GetAll();
            
        }

       

        private void formateurDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
