using App.Formations;
using App.Modules;
using App.WinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.GestionFormations
{
    public class PrevisionSeancesService : BaseRepository<PrevisionSeance>
    {
        //public PrevisionSeancesService():base()
        //{
        //}

        //public PrevisionSeancesService(ModelContext context) : base(context)
        //{
        //}

        public override void ValueChanged(object sender, BaseEntity entity)
        {
            Control control = (Control)sender;
            PrevisionSeance previsionSeance = (PrevisionSeance)entity;

            switch (control.Name)
            {
                case "Titre":
                    {

                    }
                    break;
                case "contenuePrecision":
                    {
                        IInputCollectionControle inputCollectionControle = control as IInputCollectionControle;
                         
                            
                        foreach (ContenuePrecision item in inputCollectionControle.Value)
                        {
                            previsionSeance.Objectif += item.Objectif + "\n";
                        }
                             

                    }
                    break;
                default: break;
            }
        }


        //public override int Save(PrevisionSeance item)
        //{
        //    // Calcule de l'ordre dans le cas d'insertoin
        //    if(item.Ordre == 0) { 
        //        int ordre = this.DbSet.Where(p => p.Module.Id == item.Module.Id).Count();
        //        item.Ordre = ++ordre;
        //    }
        //    return base.Save(item);
        //}

    }
}
