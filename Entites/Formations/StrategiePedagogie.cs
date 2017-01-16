// File:    StrategiePedagogie.cs
// Author:  ESSARRAJ
// Created: dimanche 28 d�cembre 2014 16:36:10
// Purpose: Definition of Class StrategiePedagogie

using App.WinForm.Annotation;
using System;

namespace App.Formations
{
    [AffichageDansFormGestion(Titre = "Gestion des strat�gies p�dagogique", TitrePageGridView = "Strat�gie p�dagogique",
    TitreButtonAjouter = "Ajouter une strat�gie p�dagogique")]
    [AffichageClasse(Minuscule = "Strat�gie p�dagogique", Majuscule = "Strat�gies p�dagogique")]
    public class StrategiePedagogie : BaseEntity
   {

        public override string ToString() => this.Titre;


        [AffichagePropriete(Titre = "Nom de la strat�gie", isGridView = true, isFormulaire = true,
             isOblegatoir = true, Ordre = 1, WidthColonne = 200)]


        public String Titre { set; get; }
        [AffichagePropriete(Titre = "Description", isGridView = true, isFormulaire = true,
          MultiLine =true,  Ordre = 2, WidthColonne = 400)]
        public String Description { set; get; }

    }
}