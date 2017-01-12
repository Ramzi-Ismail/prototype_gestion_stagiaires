
namespace App.WinForm
{
    public interface IBaseFormulaire
    {
        /// <summary>
        /// Afficher l'objet dans le formulaire
        /// </summary>
        void Afficher();

        /// <summary>
        /// Lire l'objet à partire du formulaire
        /// </summary>
        void Lire();

        /// <summary>
        /// Création d'une instance du form en cours
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        BaseFormulaire CreateInstance(IBaseRepository service);

        /// <summary>
        /// Créer d'une instance de l'objet en cours
        /// </summary>
        /// <returns></returns>
        BaseEntity CreateObjetInstance();
    }
}