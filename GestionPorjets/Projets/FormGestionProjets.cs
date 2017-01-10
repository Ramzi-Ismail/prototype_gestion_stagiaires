

using App.WinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.GestionProjets
         
{
    public partial class FormGestionProjet : App.WinForm.FormGestionTabPage
    {
        public FormGestionProjet() : base()
        {
             
            // Gestion des projets
            ProjetsService service = new ProjetsService();
            FormulaireControle objetForm = new FormulaireControle(service);
            this.initParams(service, objetForm);
 

        }
    }
}
