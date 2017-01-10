using System;

namespace App.WinForm.Annotation
{
    public class AffichageClasseAttribute : Attribute
    {
        public string Majuscule { get; set; }
        public string Minuscule { get; set; }
    }
}