using App.WinForm.Annotation;
using System;
using System.Collections.Generic;

namespace App.Modules
{
    [AffichageDansFormGestion(Titre = "Gestion des pr�cision",
       TitrePageGridView = "Pr�cision",
       TitreButtonAjouter = "Ajouter une pr�cision")]
    public class Precision : BaseEntity
   {
        public override string ToString() => this.Nom;

        //
        // Nom
        //
        [AffichagePropriete(Titre = "Pr�cision", isGridView = true, isFormulaire = true, Ordre = 1, 
           isOblegatoir =true, WidthColonne = 200)]
        public string Nom { set; get; }

        //
        // Duree
        //
        [AffichagePropriete(Titre = "Dur�e", isGridView = true, isFormulaire = true, Ordre = 2,
           
            WidthColonne = 100)]
        public int Duree { set; get; }

        [AffichagePropriete(Titre = "Description", isFormulaire = true, Ordre = 3,MultiLine = true)]
        public string Description { set; get; }
       
        //
        // Module
        //
        [AffichagePropriete(Titre = "Module",Relation = "ManyToOne", isGridView = true, isFormulaire = true,
            isOblegatoir = true,
            Ordre = 1,Filtre =true, WidthColonne = 200)]
        public virtual Module Module { set; get; }


        private int Ordre { set; get; }

        public virtual List<Prealable> Prealables { set; get; }



    }
}