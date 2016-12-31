using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Cplus.Entites
{ 
   public class Stagiaire : Utilisateur {

        // Etat Civil
        public String Nom { set; get; }
        public String Prenom { set; get; }
        public DateTime DateNaissance { set; get; }
        public bool Sexe { set; get; }
        public String Cin { set; get; }
        public String ProfilImage { set; get; }

        // Coordonnées
        public String Email { set; get; }
        public String Telephone { set; get; }
        public String Adress { set; get; }




        public int Etat { set; get; }

        // Affectation
        public virtual Groupe Groupe { set; get; }
        public virtual List<MiniGroupe> MiniGroupes { set; get; }
        public virtual Filiere Filiere { set; get; }


        // Gestion des tâches
        // un stagiaire peut avoir plusieurs tâches
        public virtual List<Tache> Taches { set; get; }


        public Stagiaire() : base()
        {
            this.DateNaissance = DateTime.Now;
        }

     
        public override string ToString()
        {
            return this.Nom + "," + this.Prenom;
        }
    }
}
  
