using App.GestionProjets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace App.GestionStagiaires
{ 
   public class Stagiaire : Utilisateur {
 

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
  
