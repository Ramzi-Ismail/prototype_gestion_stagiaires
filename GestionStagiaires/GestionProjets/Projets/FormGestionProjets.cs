﻿

using App.WinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.GestionProjets
         
{
    public partial class FormGestionProjet : App.WinForm.EntityManagementForm
    {
        public FormGestionProjet() : base()
        {
             
            // Gestion des projets
            ProjetsService service = new ProjetsService();
            EntryForm objetForm = new EntryForm(service);
            this.initParams(service, objetForm);
 

        }
    }
}
