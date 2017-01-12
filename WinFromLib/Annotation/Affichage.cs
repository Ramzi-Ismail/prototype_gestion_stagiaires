using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WinForm.Annotation
{
    public class AffichageProprieteAttribute : Attribute
    {
        public static string RELATION_MANYTOONE = "ManyToOne";
        public static string RELATION_MANYTOMANY = "ManyToMany";

        /// <summary>
        /// Indique le nom à afficher
        /// </summary>
        public string Titre { set; get; }
        /// <summary>
        /// Indique la description à afficher
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        /// Indique l'ordre d'affichage dans le formulaire et dans le dataGrid 
        /// </summary>
        public int Ordre { set; get; }

        /// <summary>
        /// Indique le type de la relation, ManyToOne ou ManyToMany
        /// </summary>
        public string Relation { set; get; }

        /// <summary>
        /// Le nom de la propriété à afficher dans ComBoBox
        /// </summary>
        public string DisplayMember { get; set; }

        /// <summary>
        /// Indique si la propriété fait partie de la formulaire
        /// </summary>
        public bool isFormulaire { get; set; }
        /// <summary>
        /// Indique si la propriété fait partie de DataGrid
        /// </summary>
        public bool isGridView { set; get; }
        /// <summary>
        /// Indique la taille de la colonne dans DataGrid
        /// </summary>
        public int WidthColonne { get; set; }
        /// <summary>
        /// Indique si l'information est MultiLine dans la formulaire de saisie
        /// </summary>
        public bool MultiLine { get; set; }

        /// <summary>
        /// Indique si la proriété fait partie du filtre de recherhe 
        /// </summary>
        public bool Filtre { get; set; }
        public bool isValeurVide { get; set; }
    }
}
