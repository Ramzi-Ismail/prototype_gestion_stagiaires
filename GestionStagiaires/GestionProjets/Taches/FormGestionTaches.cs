

using App.WinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.GestionProjets
         
{
    public partial class FormGestionTaches : App.WinForm.InterfaceGestion
    {
        public FormGestionTaches() : base()
        {
             
            TachesService service = new TachesService();
            FormulaireControle objetForm = new FormulaireControle(service);
            this.initParams(service, objetForm);
 

        }
    }
}
