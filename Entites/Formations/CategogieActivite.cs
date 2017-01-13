// File:    CategogieActivite.cs
// Author:  ESSARRAJ
// Created: dimanche 28 d�cembre 2014 16:41:25
// Purpose: Definition of Class CategogieActivite

using App.WinForm.Annotation;
using System;

namespace App.Formations
{
    [AffichageDansFormGestion(Titre = "Gestion des cat�gories d'activit�s", TitrePageGridView = "Liste des cat�gories d'activit�",
        TitreButtonAjouter = "Ajouter une cat�gorie d'activit�")]
    [AffichageClasse(Minuscule = "Cat�gorie d'activit�", Majuscule = "Cat�gories d'activit�")]
    public class CategogieActivite : BaseEntity
    {

        public override string ToString() => this.Nom;

        [AffichagePropriete(Titre = "Nom de la cat�gorie", isGridView = true, isFormulaire = true,
          Filtre =true,  isOblegatoir = true, Ordre = 1, WidthColonne = 200)]
        public string Nom { set; get; }



        [AffichagePropriete(Titre = "Description", isFormulaire = true,
          MultiLine =true, Ordre = 10)]
        public String Description { set; get; }

    }
}