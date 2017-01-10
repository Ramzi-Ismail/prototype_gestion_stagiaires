using App.WinForm.Annotation;
using System;
using System.Collections.Generic;
using System.Linq;
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

        string GetNomObjet();
        List<object> GetAllDetached();
        string GetNomObjets();

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
    }
}
