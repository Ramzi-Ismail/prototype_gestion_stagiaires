using App.WinForm.Annotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace App.GestionStagiaires
{
    [AffichageGestion(Titre = "Gestion des filieres",
TitrePageGridView = "Filiere",
TitreButtonAjouter = "Ajouter un filiere")]
    public class Filiere : BaseEntity 
   {

     [AffichageFrom(Titre = "Titre", isGridView = true, isFormulaire = true, Ordre = 1, WidthColonne = 150)]
      public String Titre { set; get; }
      public  String Code { set; get; }
      public String Description { set; get; }

        public override string ToString()
        {
            return this.Code;
        }
    }
}