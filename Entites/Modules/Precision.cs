using System;
namespace App.Modules
{
   public class Precision
   {
      private int id;
      private string nom;
      private string description;
      private int duree;
      private int ordre;
      
      public Module module;
      
      /// <summary>
      /// Property for Module
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