// File:    CategogiesSalleFormation.cs
// Author:  ESSARRAJ
// Created: dimanche 28 d�cembre 2014 16:36:10
// Purpose: Definition of Class CategogiesSalleFormation

using App.WinForm.Annotation;
using System;

namespace App.Formations
{
    [AffichageDansFormGestion(Titre = "Gestion des Cat�gogies salle de formation", TitrePageGridView = "Cat�gogies salle de formation",
       TitreButtonAjouter = "Ajouter une cat�gogie de salle de formation")]
    [AffichageClasse(Minuscule = "Cat�gogie salle de formation", Majuscule = "Cat�gogies salle de formation")]
    public class CategogiesSalleFormation : BaseEntity
   {

        public override string ToString() => this.Nom;


        [AffichagePropriete(Titre = "Cat�gorie de salle", isGridView = true, isFormulaire = true,
         Filtre = true, isOblegatoir = true, Ordre = 1, WidthColonne = 200)]
        public String Nom { set; get; }


        [AffichagePropriete(Titre = "Code", isGridView = true, isFormulaire = true,
         Filtre = true, isOblegatoir = true, Ordre = 2, WidthColonne = 80)]
        public String Code { set; get; }


        [AffichagePropriete(Titre = "Description", isFormulaire = true,
        MultiLine = true, Filtre = true, Ordre = 10)]
        public String Description { set; get; }

    }
}