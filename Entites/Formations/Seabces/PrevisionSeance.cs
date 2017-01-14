// File:    PrevisionSeance.cs
// Author:  ESSARRAJ
// Created: dimanche 28 d�cembre 2014 16:37:55
// Purpose: Definition of Class PrevisionSeance

using App.Formations;
using App.Modules;
using App.WinForm.Annotation;
using System;
using System.Collections.Generic;

namespace App.Formations
{
    [AffichageDansFormGestion(Titre = "Gestion des previsions s�ance", TitrePageGridView = "Previsions s�ance",
      TitreButtonAjouter = "Ajouter un prevision s�ance")]
    [AffichageClasse(Minuscule = "Prevision S�ance", Majuscule = "Previsions s�ance")]
    public class PrevisionSeance : BaseEntity
    {
        public override string ToString() => this.Titre;



        [AffichagePropriete(Titre = "Titre", isGridView = true, isFormulaire = true,
           Filtre = true, isOblegatoir = true, Ordre = 2, WidthColonne = 200)]
        public String Titre { set; get; }



        [AffichagePropriete(Titre = "Objectif", isGridView = true, isFormulaire = true,
             MultiLine = true, Filtre = true, isOblegatoir = true, Ordre = 3, WidthColonne = 400)]
        public String Objectif { set; get; }



        [AffichagePropriete(Titre = "Dur�e en minute", isGridView = true, isFormulaire = true,
          Unite = "min", isOblegatoir = true, Ordre = 4, WidthColonne = 80)]
        public int Duree { set; get; }



        [AffichagePropriete(Titre = "Cat�gogie salle", isGridView = true, isFormulaire = true,
         Relation = "ManyToOne", isOblegatoir = true, Ordre = 5, WidthColonne = 100)]
        public virtual CategogiesSalleFormation categogiesSalleFormation { set; get; }



        [AffichagePropriete(Titre = "Contenue",
        Relation = "ManyToMany", isFormulaire = true, isGridView = true, Ordre = 20)]
        [SelectionCriteria(new Type[] { typeof(Module),typeof(Precision) })]
        public virtual List<ContenuePrecision> contenuePrecision { set; get; }

        [AffichagePropriete(Titre = "Activit�s",
        Relation = "ManyToMany", isGridView = true, Ordre = 21)]
        public virtual List<Activite> Activites { set; get; }



        [AffichagePropriete(Titre = "Module", isGridView = true, isFormulaire = true,
         Relation = "ManyToOne", Filtre = true, isOblegatoir = true, Ordre = 11, WidthColonne = 100)]
      
        public virtual Module Module { set; get; }



    }
}