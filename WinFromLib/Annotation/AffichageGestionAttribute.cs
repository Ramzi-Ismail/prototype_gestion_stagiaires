using System;

namespace App.WinForm.Annotation
{
    public class AffichageDansFormGestionAttribute : Attribute
    {
        public string Titre { get; set; }
        public string TitreButtonAjouter { get; set; }
        public string TitrePageGridView { get; set; }
    }
}