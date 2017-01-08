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
    public partial class FormGestionGroupes : App.WinForm.FormGestionTabPage
    {
        public FormGestionGroupes():base()
        {
            InitializeComponent();


            // Gestion des groupes
            GroupesService service = new GroupesService();
            UserControlGroupeForm objetForm = new UserControlGroupeForm(service);

            List<ColonneDataGridView> ListeColonne = new List<ColonneDataGridView> {
                    new ColonneDataGridView("Nom",ColonneDataGridView.TYPE_STRING,"Nom"),
                    new ColonneDataGridView("Filiere",ColonneDataGridView.TYPE_STRING,"Filiere"),
                    new ColonneDataGridView("DateModification",ColonneDataGridView.TYPE_DATATIME,"Date de modification"),
            };
            Dictionary<string, string> Params = new Dictionary<string, string>();
            Params.Add("TitreGestion", "Gestion des groupes");
            Params.Add("TitrePageGrid", "Gestions");
            Params.Add("TitreButtonAjouter", "Ajouter un groupe");
            this.initParams(service, objetForm, ListeColonne, Params);
        }
    }
}
