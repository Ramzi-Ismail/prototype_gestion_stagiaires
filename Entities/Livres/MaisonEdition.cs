using App.WinForm.Annotation;

namespace App.Livres
{
    public class MaisonEdition : BaseEntity

    {
        public override string ToString() => this.Nom;

        [AffichagePropriete(Titre = "Nom", isGridView = true, isFormulaire = true, Ordre = 1, WidthColonne = 100)]
        public string Nom { set; get; }
        [AffichagePropriete(Titre = "Nom", isFormulaire = true, Ordre = 1,MultiLine =true)]
        public string Adresse { set; get; }
    }
}