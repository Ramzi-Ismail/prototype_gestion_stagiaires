using App.WinForm.Annotation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        [AffichagePropriete(DisplayMember = "Date de modification", 
            Titre = "Date de modification", 
            Ordre = 1000,
            WidthColonne = 150,
            isGridView = true)]
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

        public override string ToString()
        {

            return this.GetType().ToString();
        }

        ///// <summary>
        ///// Obiten l'objet Attribute de l'annotation
        ///// </summary>
        ///// <typeparam name="T">Type de l'objet</typeparam>
        ///// <param name="instance">Instance de l'objet</param>
        ///// <param name="propertyName">Le nom de la propriété</param>
        ///// <returns></returns>
        //public static T GetAttributeFrom<T>(this object instance, string propertyName) where T : Attribute
        //{
        //    var attrType = typeof(T);
        //    var property = instance.GetType().GetProperty(propertyName);
        //    return (T)property.GetCustomAttributes(attrType, false).First();
        //}
    }

   
}
