using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{

    public interface IBaseRepository 
    {
        int SaveChanges();

        int Save(BaseEntity item);

        Object ToBindingList();
        void AddElement();

        string GetNomObjet();
        List<object> GetAllSansProxy();
        string GetNomObjets();

        List<Object> GetAll();
        void Supprimer(BaseEntity obj);

        /// <summary>
        /// Obtient le context 
        /// </summary>
        /// <returns></returns>
        ModelContext Context();
    }
}
