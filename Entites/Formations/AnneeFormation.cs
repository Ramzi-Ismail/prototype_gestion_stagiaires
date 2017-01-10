// File:    AnneeFormation.cs
// Author:  ESSARRAJ
// Created: dimanche 28 décembre 2014 16:45:09
// Purpose: Definition of Class AnneeFormation

using App.WinForm.Annotation;
using System;

namespace App.Formations
{
    [AffichageGestion(Titre = "Gestion des Années de formation",
   TitrePageGridView = "Années de formation",
   TitreButtonAjouter = "Ajouter une année de formation")]
    public class AnneeFormation : BaseEntity
   {
        public override string ToString() => this.Titre;

        [AffichageFrom(Titre = "Titre", isGridView = true, isFormulaire = true, Ordre = 1, WidthColonne = 150)]
        public String Titre { set; get; }

        [AffichageFrom(Titre = "Début de la formation", isGridView = true, isFormulaire = true, Ordre = 2, WidthColonne = 150)]
        public DateTime DateDebut { set; get; }

        [AffichageFrom(Titre = "Fin de la formation", isGridView = true, isFormulaire = true, Ordre = 3, WidthColonne = 150)]
        public DateTime DateFin { set; get; }

    }
}