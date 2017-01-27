using App.WinForm.Annotation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace App
{
    /// <summary>
    /// La classe de Base de toutes les entity
    /// </summary>
    public  class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            // Problème de EF avec DateTime
            this.DateCreation = DateTime.Now;
            this.DateModification = DateTime.Now;
        }

        [Key]
        public Int64 Id { get; set; }


        [AffichagePropriete(Titre = "Ordre", isGridView = true, Ordre = 1, WidthColonne = 50)]
        public int Ordre { set; get; }

        public DateTime DateCreation { get; set; }


        [AffichagePropriete(DisplayMember = "Date de modification", 
            Titre = "Date de modification", 
            Ordre = 1000,
            WidthColonne = 100,
            isGridView = true)]
        public DateTime DateModification { get; set; }



        public override bool Equals(Object obj)
        {
            if (obj == DBNull.Value) return false;
            if (obj == null) return false;
            BaseEntity objet = (BaseEntity)obj;
            
            if (this.Id == objet.Id) return true;
            else return false;
           
        }

        /// <summary>
        /// Trouver l'annotation AffichageClasseAttribute
        /// </summary>
        /// <param name="propertyType"></param>
        /// <returns></returns>
        public static AffichageClasseAttribute GetAffichageClasseAttribute(Type propertyType)
        {
            Attribute attribute = propertyType.GetCustomAttribute(typeof(AffichageClasseAttribute));
            if (attribute == null) throw new AffichageClasseAttributeNotExitException();
            return (AffichageClasseAttribute)attribute;
        }


        /// <summary>
        /// Généric ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            AffichageClasseAttribute AffichageClasse =(AffichageClasseAttribute) this.GetType().GetCustomAttributes(typeof(AffichageClasseAttribute),true)[0];
            string Titre =  this.GetType().GetProperty(AffichageClasse.DisplayMember).GetValue(this).ToString();
            if (Titre == string.Empty) return AffichageClasse.Minuscule;
            else  return Titre;
        }

        public AffichageClasseAttribute GetAffichageClasseAttribute()
        {
          return (AffichageClasseAttribute) this.GetType().GetCustomAttributes(typeof(AffichageClasseAttribute),true).First();
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

    [Serializable]
    internal class AffichageClasseAttributeNotExitException : Exception
    {
        public AffichageClasseAttributeNotExitException()
        {
        }

        public AffichageClasseAttributeNotExitException(string message) : base(message)
        {
        }

        public AffichageClasseAttributeNotExitException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AffichageClasseAttributeNotExitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
