// File:    PrevisionSeance.cs
// Author:  ESSARRAJ
// Created: dimanche 28 décembre 2014 16:37:55
// Purpose: Definition of Class PrevisionSeance

using App.Formations;
using App.Modules;
using App.WinForm.Annotation;
using System;
using System.Collections.Generic;

namespace App.Formations
{
    [AffichageDansFormGestion(Titre = "Gestion des previsions séance", TitrePageGridView = "Previsions séance",
      TitreButtonAjouter = "Ajouter un revision séance")]
    [AffichageClasse(Minuscule = "Prevision Séance", Majuscule = "Previsions séance")]
    public class PrevisionSeance : BaseEntity
    {
        public override string ToString() => this.Titre;


        [AffichagePropriete(Titre = "Ordre", isGridView = true,
     Ordre = 1, WidthColonne = 40)]
        public int Ordre { set; get; }
 

        [AffichagePropriete(Titre = "Titre", isGridView = true, isFormulaire = true,
           Filtre =true, isOblegatoir = true, Ordre = 2, WidthColonne = 200)]
        public String Titre { set; get; }


        [AffichagePropriete(Titre = "Objectif", isGridView = true, isFormulaire = true,
             MultiLine = true,     Filtre = true, isOblegatoir = true, Ordre = 3, WidthColonne = 400)]
        public String Objectif { set; get; }


        [AffichagePropriete(Titre = "Durée en minute", isGridView = true, isFormulaire = true,
          Unite ="min", isOblegatoir = true, Ordre = 4, WidthColonne = 80)]
        public int Duree { set; get; }


        [AffichagePropriete(Titre = "Catégogie salle", isGridView = true, isFormulaire = true,
         Relation ="ManyToOne", isOblegatoir = true, Ordre = 5, WidthColonne = 100)]
        public virtual CategogiesSalleFormation categogiesSalleFormation { set; get; }
         

        public virtual List<ContenuePrecision>  contenuePrecision { set; get; }

        public virtual List<Activite> Activites { set; get; }



        [AffichagePropriete(Titre = "Module", isGridView = true, isFormulaire = true,
         Relation = "ManyToOne", Filtre = true, isOblegatoir = true, Ordre = 11, WidthColonne = 100)]
        public virtual Module Module { set; get; }



    }
}