using System;

namespace App.WinForm.Annotation
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AffichageClasseAttribute : Attribute
    {
        /// <summary>
        /// Le nom de la propiété à afficher dans le ComboBox par exemple
        /// </summary>
        public string DisplayMember { get; set; }
        public string Majuscule { get; set; }
        public string Minuscule { get; set; }
    }
}