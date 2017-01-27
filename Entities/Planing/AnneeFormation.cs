// File:    AnneeFormation.cs
// Author:  ESSARRAJ
// Created: dimanche 28 d�cembre 2014 16:45:09
// Purpose: Definition of Class AnneeFormation

using App.WinForm.Annotation;
using System;

namespace App.Formations
{
    [AffichageDansFormGestion(Titre = "Gestion des Ann�es de formation",
   TitrePageGridView = "Ann�es de formation",
   TitreButtonAjouter = "Ajouter une ann�e de formation")]
    [AffichageClasse(Minuscule = "Ann�e de formation", Majuscule = "Ann�es de formation", DisplayMember = "Titre")]
    public class AnneeFormation : BaseEntity
   {

        public AnneeFormation() : base()
        {
            this.DateDebut = DateTime.Now;
            this.DateFin = DateTime.Now.AddYears(1);
        }


        public override string ToString() => this.Titre;

        [AffichagePropriete(Titre = "Titre", 
            isGridView = true, 
            isFormulaire = true, 
            Ordre = 1, 
            WidthColonne = 150)]
        public String Titre { set; get; }

        [AffichagePropriete(Titre = "D�but de la formation", 
            isGridView = true, 
            isFormulaire = true, 
            Ordre = 2, 
            WidthColonne = 150)]
        public DateTime DateDebut { set; get; }

        [AffichagePropriete(Titre = "Fin de la formation", 
            isGridView = true, 
            isFormulaire = true, Ordre = 3, WidthColonne = 150)]
        public DateTime DateFin { set; get; }

    }
}