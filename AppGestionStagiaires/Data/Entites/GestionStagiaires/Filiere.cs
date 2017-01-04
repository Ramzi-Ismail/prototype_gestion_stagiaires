using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFlib.Entites;
namespace App.Entites
{
   public class Filiere : BaseEntity 
   {

      public String Titre { set; get; }
      public  String Code { set; get; }
      public String Description { set; get; }

    }
}