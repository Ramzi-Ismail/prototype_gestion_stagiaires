

using App.WinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.GestionProjets
         
{
    public partial class FormGestionTaches : App.WinForm.FormGestionTabPage
    {
        public FormGestionTaches() : base()
        {
             
            // Gestion des groupes
            TachesService service = new TachesService();
            FormulaireControle objetForm = new FormulaireControle(service);

            List<ColonneDataGridView> ListeColonne = new List<ColonneDataGridView> {
                    new ColonneDataGridView("Nom",ColonneDataGridView.TYPE_STRING,"Nom"),
                    new ColonneDataGridView("Description",ColonneDataGridView.TYPE_STRING,"Description"),
                    new ColonneDataGridView("DateModification",ColonneDataGridView.TYPE_DATATIME,"Date de modification"),
            };
            Dictionary<string, string> Params = new Dictionary<string, string>();
            Params.Add("TitreGestion", "Gestion des tâches");
            Params.Add("TitrePageGrid", "Gestions");
            Params.Add("TitreButtonAjouter", "Ajouter une tâche");
            this.initParams(service, objetForm, ListeColonne, Params);
 

        }
    }
}
