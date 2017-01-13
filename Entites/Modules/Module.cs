using App.GestionStagiaires;
using App.WinForm.Annotation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Modules
{
    [AffichageDansFormGestion(Titre = "Gestion des modules",TitrePageGridView = "Modules",
        TitreButtonAjouter = "Ajouter un module")]
    [AffichageClasse(Minuscule="Module", Majuscule = "Modules")]
    public class Module : BaseEntity
    {

        [AffichagePropriete(Titre = "Nom du module", isGridView = true, isFormulaire = true,
            isOblegatoir = true,   Ordre = 1, WidthColonne = 200 )]
        public String Nom { set; get; }



        [AffichagePropriete(Titre = "Code", isGridView = true, isFormulaire = true,
           isOblegatoir = true, Ordre = 2, WidthColonne = 80)]
        public String Code { set; get; }



        /// <summary>
        /// La duré en Nombre d'heure
        /// </summary>
        [AffichagePropriete(Titre = "Durée en Heure", isGridView = true, isFormulaire = true,
          Unite ="h",  isOblegatoir = true, Ordre = 3,  WidthColonne = 40)]
        public int Duree{ set; get; }



        // Affectation
        [AffichagePropriete(Titre = "Filiere", isGridView = true, isFormulaire = true,
            isOblegatoir = true, Relation = "ManyToOne",DisplayMember = "Code",
            Filtre=true, WidthColonne = 80, Ordre = 4)]
        public virtual Filiere Filiere { set; get; }



        [AffichagePropriete(Titre = "Présentation", 
            isFormulaire = true, 
            Ordre = 5 , 
            MultiLine =true)]
        public string Presentation { set; get; }



        [AffichagePropriete(Titre = "Remarque", 
            isFormulaire = true,
            Ordre = 6, 
            MultiLine = true)]
        public string Description { set; get; }

      

      // Description pédagogique
      public string StrategieEnseignement{ set; get; } 
      public string Apprentisage{ set; get; } 
      public string Evaluation{ set; get; } 
      public string Materiel{ set; get; } 
      public string Equipement{ set; get; } 
      public string Competence{ set; get; }



      [AffichagePropriete(Titre = "Precisions",
         isGridView = true, Ordre = 20)]
      public virtual List<Precision> Precisions { set; get; }


      public override string ToString() => this.Nom;
    }
}