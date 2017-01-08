using System;
using System.ComponentModel.DataAnnotations;

namespace App
{
    
    public  class BaseEntity : IBaseEntity
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

        public override bool Equals(Object obj)
        {
            if (obj == DBNull.Value) return false;
            if (obj == null) return false;
            BaseEntity objet = (BaseEntity)obj;
            
            if (this.Id == objet.Id) return true;
            else return false;
           
        }
    }

   
}
