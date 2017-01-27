using App.WinForm.Annotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Individu : BaseEntity
    {

        public override string ToString() =>  this.Nom + " " + this.Prenom;


        // Etat Civil
        [AffichagePropriete(Titre = "Nom", isGridView = true, isFormulaire = true, Ordre = 1, 
            Filtre = true,
            WidthColonne = 100)]
        public String Nom { set; get; }

        [AffichagePropriete(Titre = "Prénom", isGridView = true, isFormulaire = true, Ordre = 2,
            Filtre = true,
            WidthColonne = 100)]
        public String Prenom { set; get; }

        [AffichagePropriete(Titre = "CIN", isFormulaire = true, Ordre = 3)]
        public String Cin { set; get; }

        [AffichagePropriete(Titre = "Date de naissance", isFormulaire = true, Ordre = 3)]
        public DateTime DateNaissance { set; get; }

    
        public bool Sexe { set; get; }
       
        public String ProfilImage { set; get; }

        // Coordonnées
        [AffichagePropriete(Titre = "E-mail", isFormulaire = true, Ordre = 10)]
        public String Email { set; get; }

        [AffichagePropriete(Titre = "Téléphone", isFormulaire = true, Ordre = 11)]
        public String Telephone { set; get; }

        [AffichagePropriete(Titre = "Adress", isFormulaire = true, Ordre = 12,MultiLine = true)]
        public String Adress { set; get; }

        public Individu()
        {
            this.DateNaissance = DateTime.Now.AddYears(-23);
        }
    }
}
