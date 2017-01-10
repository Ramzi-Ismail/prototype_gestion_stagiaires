using System;

namespace App.Modules
{
   public class Prealable : BaseEntity
   {
    
      public string Nom { set; get; }
        public string Description { set; get; }
        public int Ordre { set; get; }

        public Precision Precision { set; get; }

    }
}