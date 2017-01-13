using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace App
{
    public partial class AnneeFormationFormulaire : App.WinForm.BaseFormulaire
    {
        public AnneeFormationFormulaire():base()
        {
            InitializeComponent();
        }
        public AnneeFormationFormulaire(IBaseRepository service) : base(service)
        {
            InitializeComponent();
        }



        private void dateDebutDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            SetTitreAnneeFormation();
        }

        private void dateFinDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            SetTitreAnneeFormation();
        }
        private void SetTitreAnneeFormation()
        {
            titreTextBox.Text = dateDebutDateTimePicker.Value.Year + "-" + dateFinDateTimePicker.Value.Year;
        }
    }
}
