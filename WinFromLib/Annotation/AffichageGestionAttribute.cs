using System;

namespace App.WinForm.Annotation
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AffichageDansFormGestionAttribute : Attribute
    {
        /// <summary>
        /// Le champs à utiliser pour le trie en ordre
        /// </summary>
        public string orderBy { get; set; }

        /// <summary>
        /// Indique si l'affichage des objet dans dataGrid se fait avec l'odre
        /// </summary>
        public bool siAffichageAvecOrdre { get; set; }
        public string Titre { get; set; }
        public string TitreButtonAjouter { get; set; }
        public string TitrePageGridView { get; set; }
    }
}