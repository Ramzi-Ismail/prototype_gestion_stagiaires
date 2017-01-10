using App.WinForm.Annotation;
using System;
using System.Collections.Generic;

namespace App.Modules
{
    [AffichageGestion(Titre = "Gestion des pr�cision",
       TitrePageGridView = "Pr�cision",
       TitreButtonAjouter = "Ajouter une pr�cision")]
    public class Precision : BaseEntity
   {
        public override string ToString() => this.Nom;

        [AffichageFrom(Titre = "Pr�cision", isGridView = true, isFormulaire = true, Ordre = 1, WidthColonne = 200)]
        public string Nom { set; get; }

        [AffichageFrom(Titre = "Dur�e", isGridView = true, isFormulaire = true, Ordre = 2, WidthColonne = 100)]
        public int Duree { set; get; }

        [AffichageFrom(Titre = "Description", isFormulaire = true, Ordre = 3,MultiLine = true)]
        public string Description { set; get; }
       

        [AffichageFrom(Titre = "Module",Relation = "ManyToOne", isGridView = true, isFormulaire = true, Ordre = 1, WidthColonne = 200)]
        public virtual Module Module { set; get; }


        private int Ordre { set; get; }

        public virtual List<Prealable> Prealables { set; get; }



    }
}