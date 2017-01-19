// File:    Seance.cs
// Author:  ESSARRAJ
// Created: dimanche 28 décembre 2014 16:56:52
// Purpose: Definition of Class Seance

using App.Formations;
using App.WinForm.Annotation;
using System;
using System.Collections.Generic;

namespace App.Formations
{
    [AffichageDansFormGestion(Titre = "Gestion des séances", TitrePageGridView = "Séances",
     TitreButtonAjouter = "Ajouter une séance")]
    [AffichageClasse(Minuscule = "Séance", Majuscule = "Séances")]
    public class Seance : BaseEntity
   {


        public Seance():base()
        {
            this.DateRealisation = DateTime.Now;
            this.heureDebut = DateTime.Now;
            this.heureFin = DateTime.Now;
        }
        public override string ToString() => this.Titre;


   

        [AffichagePropriete(Titre = "Prévision Séance", isFormulaire = true,
Relation = "ManyToOne", isOblegatoir = true, Ordre = 1)]
        public virtual PrevisionSeance PrevisionSeance { set; get; }


        [AffichagePropriete(Titre = "Date de séance", isGridView = true, isFormulaire = true,
      isOblegatoir = true, Ordre = 2, WidthColonne = 100)]
        public DateTime DateRealisation { set; get; }


        [AffichagePropriete(Titre = "Titre", isGridView = true, isFormulaire = true,
           Filtre = true, isOblegatoir = true, Ordre = 3, WidthColonne = 150)]
        public String Titre { set; get; }


        [AffichagePropriete(Titre = "Objectif", isGridView = true, isFormulaire = true,
      Filtre = true, MultiLine = true, isOblegatoir = true, Ordre =4, WidthColonne = 200)]
        public String Objectif { set; get; }

        [AffichagePropriete(Titre = "Durée", isGridView = true, isFormulaire = true,
Unite = "min", isOblegatoir = true, Ordre = 5, WidthColonne = 50)]
        public int Duree { set; get; }


        [AffichagePropriete(Titre = "Salle", isGridView = true, isFormulaire = true,
        Relation ="ManyToOne",  isOblegatoir = true, Ordre = 6, WidthColonne = 50)]
        public Salle Salle { set; get; }

        [AffichagePropriete(Titre = "Heure début", isGridView = true, isFormulaire = true,
Unite = "time", isOblegatoir = true, Ordre = 7, WidthColonne = 50)]
        public DateTime heureDebut { set; get; }

        [AffichagePropriete(Titre = "Heure fin", isGridView = true, isFormulaire = true,
        Unite = "time", isOblegatoir = true, Ordre = 8, WidthColonne = 50)]
        public DateTime heureFin { set; get; }



        public virtual List<Activite> Activites { set; get; }
 




        [AffichagePropriete(Titre = "Formation", isGridView = true, isFormulaire = true,
Relation = "ManyToOne", Filtre = true, isOblegatoir = true, Ordre = 10, WidthColonne = 100)]
        public virtual Formation Formation { set; get; }


        [AffichagePropriete(Titre = "Absence", isGridView = true, isFormulaire = true,
Relation = "ManyToMany", Ordre = 10, WidthColonne = 100)]

        public virtual List<Absence> Absences { set; get; }






    }
}