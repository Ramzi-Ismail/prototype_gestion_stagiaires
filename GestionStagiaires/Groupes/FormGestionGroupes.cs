using App.WinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace App.GestionStagiaires.Groupes
{
    public partial class FormGestionGroupes : App.WinForm.InterfaceGestion
    {
        public FormGestionGroupes():base()
        {
            InitializeComponent();


            // Gestion des groupes
            GroupesService service = new GroupesService();
            UserControlGroupeForm objetForm = new UserControlGroupeForm(service);

          
     
            this.initParams(service, objetForm);
        }
    }
}
