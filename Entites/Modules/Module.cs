using App.GestionStagiaires;
using System;

namespace App.Modules
{
   public class Module
   {
      private int id;
      private String nom;
      private int duree;
      private string strategieEnseignement;
      private string apprentisage;
      private string evaluation;
      private string materiel;
      private string equipement;
      private string competence;
      private string presentation;
      private string description;
      
      public Filiere filiere;
      
      /// <summary>
      /// Property for Filieres.Filiere
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Filiere Filiere
      {
         get
         {
            return filiere;
         }
         set
         {
            this.filiere = value;
         }
      }
   
   }
}