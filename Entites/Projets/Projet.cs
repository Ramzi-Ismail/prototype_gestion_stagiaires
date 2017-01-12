using App.WinForm.Annotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.GestionProjets
{
    public class Projet  :BaseEntity
    {

        [AffichagePropriete(Titre = "Titre", Ordre = 1)]
        public string Titre { set; get; }

        [AffichagePropriete(Titre = "Description", Ordre = 2)]
        public string Description { set; get; }

        public virtual List<Tache> Taches { set; get; }

        public override string ToString()
        {
            return Titre;
        }

    }
}
