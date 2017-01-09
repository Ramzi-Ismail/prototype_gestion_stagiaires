using App.GestionStagiaires;
using App.Modules;
using System;

namespace App.Formations
{
   public class Formation
   {
      private int id;
      private String code;
      
      public AnneeFormation anneeFormation;
      
      /// <summary>
      /// Property for AnneeFormations.AnneeFormation
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public AnneeFormation AnneeFormation
      {
         get
         {
            return anneeFormation;
         }
         set
         {
            this.anneeFormation = value;
         }
      }
      public Groupe groupe;
      
     
      public Formateur formateur;
      
      /// <summary>
      /// Property for Formateurs.Formateur
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Formateur Formateur
      {
         get
         {
            return formateur;
         }
         set
         {
            this.formateur = value;
         }
      }
      public Module module;
      
      /// <summary>
      /// Property for Modules.Module
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Module Module
      {
         get
         {
            return module;
         }
         set
         {
            this.module = value;
         }
      }
   
   }
}