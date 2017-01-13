using System;

namespace App.WinForm.Annotation
{
    public class AffichageDansFormGestionAttribute : Attribute
    {
        /// <summary>
        /// Indique si l'affichage des objet dans dataGrid se fait avec l'odre
        /// </summary>
        public bool siAffichageAvecOrdre { get; set; }
        public string Titre { get; set; }
        public string TitreButtonAjouter { get; set; }
        public string TitrePageGridView { get; set; }
    }
}