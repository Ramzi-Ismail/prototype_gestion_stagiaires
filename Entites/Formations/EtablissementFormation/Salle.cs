// File:    Salle.cs
// Author:  ESSARRAJ
// Created: dimanche 28 décembre 2014 16:36:10
// Purpose: Definition of Class Salle

using System;

namespace App.Formations
{
   public class Salle
   {
      private int id;
      private String nom;
      private String code;
      private String description;
      
      public CategogiesSalleFormation categogiesSalleFormation;
      
      /// <summary>
      /// Property for CategogiesSalleFormation
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public CategogiesSalleFormation CategogiesSalleFormation
      {
         get
         {
            return categogiesSalleFormation;
         }
         set
         {
            this.categogiesSalleFormation = value;
         }
      }
   
   }
}