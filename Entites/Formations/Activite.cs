// File:    Activite.cs
// Author:  ESSARRAJ
// Created: dimanche 28 décembre 2014 16:37:55
// Purpose: Definition of Class Activite

using System;

namespace App.Formations
{
   public class Activite
   {
      private int id;
      private String objectif;
      private int duree;
      private String commentaire;
      
      public StrategiePedagogie strategiePedagogie;
      
      /// <summary>
      /// Property for StrategiePedagogie
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public StrategiePedagogie StrategiePedagogie
      {
         get
         {
            return strategiePedagogie;
         }
         set
         {
            this.strategiePedagogie = value;
         }
      }
      public CategogieActivite categogieActivite;
      
      /// <summary>
      /// Property for CategogieActivite
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public CategogieActivite CategogieActivite
      {
         get
         {
            return categogieActivite;
         }
         set
         {
            this.categogieActivite = value;
         }
      }
   
   }
}