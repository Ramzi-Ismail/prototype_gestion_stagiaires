// File:    Seance.cs
// Author:  ESSARRAJ
// Created: dimanche 28 décembre 2014 16:56:52
// Purpose: Definition of Class Seance

using App.Formations;
using PrevisionSeances;
using System;
using System.Collections.Generic;

namespace Seances
{
   public class Seance
   {
      private String titre;
      private int objectif;
      private int id;
      private DateTime duree;
      private DateTime dateRealisation;
      private DateTime heureFin;
      
      public Formation formation;
      public List<Activite> Activite;

      public Sequences Sequences;
     
      public Salle salle;
    
      public List<PrevisionSeance> previsionSeance;
       public List<PrevisionSeance> PrevisionSeance;
      
      
   
   }
}