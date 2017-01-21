using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WinForm.Annotation
{
    [AttributeUsage(AttributeTargets.Property,  AllowMultiple = false)]
    public class AffichageProprieteAttribute : Attribute
    {
        public static string RELATION_MANYTOONE = "ManyToOne";
        public static string RELATION_MANYTOMANY = "ManyToMany";


        public AffichageProprieteAttribute()
        {
            Enable = true;
            // Par défaut le nombre du ligne d'un champs MultiLigne = 1
            NombreLigne = 1;
        }

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
        /// l'attribut doit être dans DataGrid
        /// </summary>
        public bool Filtre { get; set; }

        /// <summary>
        /// Si la valeur est vide dans le filtre
        /// </summary>
        public bool isValeurFiltreVide { get; set; }

        /// <summary>
        /// Indique si la saisie de cette information est 
        /// </summary>
        public bool isOblegatoir { get; set; }
        /// <summary>
        /// Unité : min,h,annee, g, Kg
        /// </summary>
        public string Unite { get; set; }
        public List<string> CriteriaFilter { get; set; }

        /// <summary>
        /// Utilisation de filtre de selection pour le comboBox
        /// </summary>
        public bool FilterSelection { get; set; }

        /// <summary>
        /// si l'affichage est activté ou non
        /// La valeur par défaut est vrais
        /// </summary>
        public bool Enable { get; set; }


        /// <summary>
        /// En cas d'un champs multi-ligne, il détermine le nombre de ligne à utiliser
        /// </summary>
        public int NombreLigne { get; set; }
    }
}
