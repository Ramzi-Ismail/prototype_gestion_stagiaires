using App.WinForm.Annotation;
using System;
namespace App.Modules
{
    [AffichageDansFormGestion(Titre = "Gestion des contenues de precision", TitrePageGridView = "Contenues de precision",
     TitreButtonAjouter = "Ajouter un contenue de precision")]
    [AffichageClasse(Minuscule = "Contenue de precision", Majuscule = "Contenues de precision")]
    public class ContenuePrecision :BaseEntity
   {

        [AffichagePropriete(Titre = "Pr�cision", isGridView = true, isFormulaire = true,
  Relation = "ManyToOne", Filtre = true, isOblegatoir = true, Ordre = 1, WidthColonne = 100)]
        public Precision Precision { set; get; }


        [AffichagePropriete(Titre = "Objectif", isGridView = true, isFormulaire = true,
           Filtre =true, isOblegatoir = true, Ordre = 2, WidthColonne = 200)]
        public  string Objectif { set; get; }


        [AffichagePropriete(Titre = "Dur�e en minute", isGridView = true, isFormulaire = true,
  Unite = "min", isOblegatoir = true, Ordre = 3, WidthColonne = 80)]
        public int Duree { set; get; }



        [AffichagePropriete(Titre = "Description", isFormulaire = true,
      MultiLine = true, Ordre = 10)]
        public string Description { set; get; }

 


  


     

       
      
        public int Ordre { set; get; }

        



    }
}