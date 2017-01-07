using System;
using System.ComponentModel.DataAnnotations;

namespace EFlib.Entites
{
   public  class BaseEntity
    {
      
        public BaseEntity()
        {
            this.DateCreation = DateTime.Now;
            this.DateModification = DateTime.Now;
        }
        [Key]
        public Int64 Id { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }


        public virtual string GetNomObjet()
        {
            return "Information";
        }
        public virtual string GetNomObjets()
        {
            return "Informations";
        }
    }
}
