// File:    PrevisionSeance.cs
// Author:  ESSARRAJ
// Created: dimanche 28 décembre 2014 16:37:55
// Purpose: Definition of Class PrevisionSeance

using App.Formations;
using App.Modules;
using System;

namespace PrevisionSeances
{
   public class PrevisionSeance
   {
      private int id;
      private String titre;
      private String objectif;
      private int ordre;
      private int duree;
      
      public System.Collections.ArrayList activite;
    
      
     
      public CategogiesSalleFormation categogiesSalleFormation;
      
     
      public ContenuePrecision[] contenuePrecision;
      
      
      public Sequences sequences;
      
      /// <summary>
      /// Property for Squences.Sequences
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Sequences Sequences
      {
         get
         {
            return sequences;
         }
         set
         {
            this.sequences = value;
         }
      }
   
   }
}