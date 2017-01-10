using App.WinForm.Annotation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.GestionProjets
{
    [AffichageGestion (Titre="Gestion des tâches",
        TitrePageGridView="Tâches",
        TitreButtonAjouter="Ajouter une tâche")]
    public class Tache : BaseEntity 
    {

       

        [Required]
        [AffichageFrom(Titre = "Titre",
            WidthColonne = 200,
            Ordre = 1,isGridView = true,isFormulaire=true)]
        public string Titre { set; get; }


        [AffichageFrom(Titre = "Description", 
            Ordre = 3,
            WidthColonne = 200,
            isGridView = true, 
            isFormulaire = true)]
        public string Description { set; get; }

 
        [AffichageFrom( Relation = "ManyToOne", 
            DisplayMember ="Titre",
            Titre = "Projet", 
            Ordre = 3, 
            isGridView = true, 
            isFormulaire = true)]
        public virtual Projet Projet {set;get;}

        public override string ToString()
        {
            if (this.Titre == null) return "null";
            return this.Titre;
        }

    }
}
