using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace App.GestionStagiaires
{
   public class Filiere : BaseEntity 
   {

      public String Titre { set; get; }
      public  String Code { set; get; }
      public String Description { set; get; }

        public override string ToString()
        {
            return this.Code;
        }
    }
}