using System;
namespace App.Modules
{
   public class ContenuePrecision :BaseEntity
   {

      public  string Nom { set; get; }
        public string Description { set; get; }
        public int Duree { set; get; }
        public int Ordre { set; get; }

        public Precision Precision { set; get; }



    }
}