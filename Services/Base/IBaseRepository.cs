using App.WinForm.Annotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App
{

    public interface IBaseRepository 
    {
          Type TypeEntity { set; get; } 
        int SaveChanges();

        int Save(BaseEntity item);

        Object ToBindingList();
        void AddElement();

        //string GetNomObjet();
        List<object> GetAllDetached();
        //string GetNomObjets();

        List<Object> Recherche(Dictionary<string, List<string>> dictionary,int startPage = 0, int itemsPerPage = 0);
        List<Object> Recherche(Dictionary<string, object> rechercheInfos, int startPage = 0, int itemsPerPage = 0);
        

        List<Object> GetAll();

        BaseEntity GetBaseEntityByID(Int64 id);

        void Supprimer(BaseEntity obj);

        /// <summary>
        /// Obtient le context 
        /// </summary>
        /// <returns></returns>
        ModelContext Context();

        /// <summary>
        /// Création d'une instance de l'objet T
        /// </summary>
        /// <returns></returns>
          object CreateInstanceObjet();
       AffichageDansFormGestionAttribute getAffichageDansFormGestionAttribute();

        /// <summary>
        /// Création d'une instance de de BaseRepositoty depuis le type de l'objet Entity
        /// </summary>
        /// <param name="TypeEntity">Le type de classe à utiliser dans BaseRepository</param>
        /// <returns></returns>
        IBaseRepository CreateInstance_Of_Service_From_TypeEntity(Type TypeEntity);
    }
}
